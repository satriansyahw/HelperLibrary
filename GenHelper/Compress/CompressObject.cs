using GenHelper.Cache;
using Jil;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace GenHelper.Compress
{
    public class PropertyComparer<T> : IEqualityComparer<T>
    {
        private PropertyInfo _PropertyInfo;

        /// <summary>
        /// Creates a new instance of PropertyComparer.
        /// </summary>
        /// <param name="propertyName">The name of the property on type T 
        /// to perform the comparison on.</param>
        public PropertyComparer(string propertyName)
        {
            //store a reference to the property info object for use during the comparison
            _PropertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type { 1 }.", propertyName, typeof(T)));
            }
        }

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            //get the current value of the comparison property of x and of y
            object xValue = _PropertyInfo.GetValue(x, null);
            object yValue = _PropertyInfo.GetValue(y, null);

            //if the xValue is null then we consider them equal if and only if yValue is null
            if (xValue == null)
                return yValue == null;

            //use the default comparer for whatever type the comparison property is.
            return xValue.Equals(yValue);
        }

        public int GetHashCode(T obj)
        {
            //get the value of the comparison property out of obj
            object propertyValue = _PropertyInfo.GetValue(obj, null);

            if (propertyValue == null)
                return 0;

            else
                return propertyValue.GetHashCode();
        }

        #endregion
    }
    public class CompressObject
    {
        private static CompressObject instance;
        private readonly MemoryCacher cacher = MemoryCacher.GetInstance;
        private readonly int MaxSizeStrToSplit = 100000;//100kb
        //private readonly int ChunkWaitTime = 30000;// wait fo 30 seconds
        public CompressObject()
        {

        }
        public static CompressObject GetInstance
        {
            get
            {
                if (instance == null) instance = new CompressObject();
                return instance;
            }
        }
        
        public byte[] CompressedData(object data)
        {
            string json = string.Empty;
            byte[] result = null;
            using (var output = new StringWriter())
            {
                JSON.SerializeDynamic(data, output);
                json = output.ToString();
            }

            byte[] inputBytes = Encoding.UTF8.GetBytes(json);
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    gZipStream.Write(inputBytes, 0, inputBytes.Length);

                var outputBytes = outputStream.ToArray();
                result = outputBytes;

            }
            return result;
        }
        public string DeCompressedData(byte[] data)
        {
            string result = string.Empty;
            if (data != null)
            {
                using (var inputStream = new MemoryStream(data))
                using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                using (var outputStream = new MemoryStream())
                {
                    gZipStream.CopyTo(outputStream);
                    var outputBytes = outputStream.ToArray();

                    string decompressed = Encoding.UTF8.GetString(outputBytes);
                    result = decompressed;
                }
            }
            return result;
        }
        public string DeCompressedData(string database64string)
        {
            string result = string.Empty;
            if (database64string != null)
            {
                using (var inputStream = new MemoryStream(Convert.FromBase64String(database64string)))
                using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                using (var outputStream = new MemoryStream())
                {
                    gZipStream.CopyTo(outputStream);
                    var outputBytes = outputStream.ToArray();

                    string decompressed = Encoding.UTF8.GetString(outputBytes);
                    result = decompressed;
                }
            }
            return result;
        }
        public List<ChunkData> ChunkDataPreparation(string fileNameWithExt,object dataChuncked)
        {
            ChunkData chunk = null;
            string chunkKey = "chunk_"+(Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddhhmmss")).Replace("-", "");
            List<ChunkData> listResult = new List<ChunkData>();
            byte[] byteChunked = this.CompressedData(dataChuncked);
            string strChunked = Convert.ToBase64String(byteChunked);
            int lenStrChunked = strChunked.Length;
            if(lenStrChunked > 0)
            {
                int countLoop = lenStrChunked / MaxSizeStrToSplit;
                int tempCount = countLoop * MaxSizeStrToSplit;
                if (tempCount < lenStrChunked) countLoop++;

                if(countLoop  > 0)
                {
                    int startLoop = 0;
                    int endLoop = 0;
                    string strToTransferred = string.Empty;
                    for (int i = 0; i < countLoop; i++)
                    {
                        chunk = new ChunkData();
                        startLoop = i * MaxSizeStrToSplit;
                        endLoop = (i + 1) * MaxSizeStrToSplit;
                        if (endLoop > lenStrChunked) endLoop = lenStrChunked;

                        strToTransferred = strChunked.Substring(startLoop, endLoop);
                        chunk.DataChunk = strToTransferred;
                        chunk.ChunkMaxCount = countLoop;
                        chunk.ChunkCurrent = (i + 1);
                        chunk.FileName = fileNameWithExt;
                        chunk.ChunkKey = chunkKey;
                        chunk.CompleteChunk = i >= (countLoop-1)?true: false;
                        listResult.Add(chunk);

                    }
                }
                else
                {
                    chunk = new ChunkData();
                    chunk.DataChunk = strChunked;
                    chunk.ChunkMaxCount = 1;
                    chunk.ChunkCurrent = 1;
                    chunk.FileName = fileNameWithExt;
                    chunk.ChunkKey = chunkKey;
                    chunk.CompleteChunk = true;
                    listResult.Add(chunk);
                }
            }
            return listResult;
        }
        public async Task<ChunkData> ChunkDataDownload(string fileNameWithExt, object dataChuncked)
        {
            List<ChunkData> listResult = new List<ChunkData>();
            ChunkData result = new ChunkData();
            await Task.Run(() =>
            {
                listResult = this.ChunkDataPreparation(fileNameWithExt, dataChuncked);
                if (listResult.Count > 0)
                {
                    result = listResult[0];
                    string chunkKey = listResult[0].ChunkKey;
                    for (int i = 0; i < listResult.Count; i++)
                    {
                        cacher.AddMinutes(chunkKey + "_" + (i + 1), listResult[i], listResult[i].ChunkTimeMinutes);
                    }
                }
            });
            return result;

        }
        public async Task<ChunkDataResult> ChunkDataResultClientVerify(List<ChunkData> listChunk)
        {
            ChunkDataResult dataResult = new ChunkDataResult();
            await Task.Run(() =>
            {
                byte[] byteData = null;
                IEqualityComparer<ChunkData> customComparer =
                       new PropertyComparer<ChunkData>("ChunkCurrent");
                IEnumerable<ChunkData> distinctChunkData = listChunk.Distinct(customComparer);
                if (distinctChunkData.Count() > 0)
                {
                    string strChunked64Base = string.Empty;
                    foreach (var item in distinctChunkData)
                    {
                        strChunked64Base += item.DataChunk;
                    }
                    if (!string.IsNullOrEmpty(strChunked64Base))
                    {
                        string tempForByte = this.DeCompressedData(strChunked64Base);
                        byteData = Convert.FromBase64String(tempForByte);
                    }
                    dataResult.FileNameWithExt = listChunk[0].FileName;
                    dataResult.DataChunk = byteData;
                }
            });
            return dataResult;
        }
        public async Task<ChunkDataResult> ChunkDataUploadSvrVerify(ChunkDataInfo chunk)
        {
            // if you want to call this methode... just make sure all your loop ChunkDataUploadSvrAsync has been finished
            ChunkDataResult dataResult = new ChunkDataResult();
            await Task.Run(() =>
            {
                string chunkKey = chunk.ChunkKey;
                int chunkCount = chunk.ChunkMaxCount;
                byte[] byteData = null;
                List<ChunkData> listChunk = new List<ChunkData>();
                int tryTimes = 0;
                int maxTryTimes = 6;// max 1 minute for waiting
                while (true)
                {
                    tryTimes++;
                    for (int i = 0; i < chunkCount; i++)
                    {
                        object obj = cacher.GetValue(chunkKey + "_" + (i + 1).ToString());
                        if (obj != null)
                            listChunk.Add((ChunkData)obj);
                    }
                    if (listChunk.Count == chunkCount) break;
                    if (tryTimes == maxTryTimes) break;
                    listChunk = new List<ChunkData>();
                    Task.Delay(10000);
                }
                if(listChunk.Count > 0)
                {
                    string strChunked64Base = string.Empty;//it's str64base
                    foreach (var item in listChunk.OrderBy(a=>a.ChunkCurrent).ToList())
                    {
                        strChunked64Base = strChunked64Base + item.DataChunk;
                    }
                    if(!string.IsNullOrEmpty(strChunked64Base))
                    {
                         string tempForByte = this.DeCompressedData(strChunked64Base);
                         byteData = Convert.FromBase64String(tempForByte);
                    }
                    dataResult.FileNameWithExt = listChunk[0].FileName;
                    dataResult.DataChunk = byteData;
                }

            });
            return dataResult;
        }
        public async Task ChunkDataUploadSvr(ChunkData chunk)
        {
            await Task.Run(() =>
            {
                string chunkKey = chunk.ChunkKey;
                string chunkKeyNumber = chunk.ChunkCurrent.ToString();
                double minutes = chunk.ChunkTimeMinutes;
                chunkKey = chunkKey + "_" + chunkKeyNumber;
                cacher.Delete(chunkKey);//make sure only one key on cacher
                cacher.AddMinutes(chunkKey, chunk, minutes);
            });
        }
        public ChunkData ChunkDataUploadSvr1(ChunkData chunk)
        {
            MemoryCacher cacher = new MemoryCacher();
            ChunkData result = new ChunkData();
            string savedchunk = string.Empty;
            object checkchunk = null;
            //check apakah ada data chunk         
            checkchunk = cacher.GetValue(chunk.ChunkKey);
            result.ChunkCurrent = chunk.ChunkCurrent;
            result.ChunkKey = chunk.ChunkKey;
            result.ChunkMaxCount = chunk.ChunkMaxCount;
            result.FileName = chunk.FileName;
            if (checkchunk != null)
            {
                //resultchunk =jika ada, data chunk lama + data terbaru
                savedchunk = (string)checkchunk;
                result.DataChunk = savedchunk + chunk.DataChunk;
            }
            else
            {
                //resultchunk =jika tidak ada, data terbaru
                result.DataChunk = chunk.DataChunk;
            }
            //menghapus data chace
            cacher.Delete(chunk.ChunkKey);
            if (chunk.ChunkMaxCount == chunk.ChunkCurrent)
            {
                result.CompleteChunk = true;
            }
            else
            {
                result.CompleteChunk = false;
                //membuat chache data chace

                cacher.AddMinutes(result.ChunkKey, result.DataChunk, chunk.ChunkTimeMinutes);
            }
            return result;
        }
    }
   
}
