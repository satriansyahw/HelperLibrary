using System;
using System.Collections.Generic;
using System.Text;

namespace GenHelper.Compress
{
    class SampleHowToUseBhunkData
    {
        /* CLIENT
        static void GetCobaDownload()
        {
            HttpClient client = SetHttpClient();
            ChunkData hasil = new ChunkData();
            List<ChunkData> listChunk = new List<ChunkData>();
            List<RFIDTagStorage_Testing> result = new List<RFIDTagStorage_Testing>();
            paramData = "/GetCobaDownload?paramFields={\"param_labelID\":\"200000000295317\"}";
            HttpResponseMessage response = client.GetAsync(string.Format("{0}{1}", routeController, paramData)).Result;
            IEnumerable<string> headerValues = null;
            string checkRequestHeader = CompressObject.GetInstance.ChunkRequestDownloadHeader;
            if (response.IsSuccessStatusCode)
            {
                response.Headers.TryGetValues(CompressObject.GetInstance.ChunkRequestDownloadHeader, out headerValues);
                if (headerValues != null)
                {
                    checkRequestHeader = CompressObject.GetInstance.ChunkRequestDownloadHeader;
                    if (headerValues.ToList()[0] == CompressObject.GetInstance.ChunkRequestDownloadHeader)
                    {
                        // ada looping ya;
                        var retResponse = response.Content.ReadAsStringAsync().Result;
                        hasil = Newtonsoft.Json.JsonConvert.DeserializeObject<ChunkData>(retResponse);

                        if (hasil != null)
                        {
                            if (hasil.ChunkMaxCount > 0) listChunk.Add(hasil);
                            if (hasil.ChunkMaxCount > 1)
                            {
                                int maxLoop = hasil.ChunkMaxCount;
                                string chungKey = hasil.ChunkKey;

                                for (int i = 0; i < maxLoop; i++)
                                {
                                    string chungKeyCurrent = chungKey + "_" + (i + 1).ToString();
                                    client.DefaultRequestHeaders.Remove(CompressObject.GetInstance.ChunkRequestDownloadHeader);
                                    client.DefaultRequestHeaders.Add(CompressObject.GetInstance.ChunkRequestDownloadHeader, chungKeyCurrent);
                                    response = client.GetAsync(string.Format("{0}{1}", routeController, paramData)).Result;
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var retResponsePartial = response.Content.ReadAsStringAsync().Result;
                                        hasil = Newtonsoft.Json.JsonConvert.DeserializeObject<ChunkData>(retResponsePartial);
                                        listChunk.Add(hasil);
                                    }
                                }
                            }
                        }



                    }
                }
                else
                {
                    checkRequestHeader = "Not ChunkLoop";
                    var retResponse = response.Content.ReadAsStringAsync().Result;
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RFIDTagStorage_Testing>>(retResponse);
                }
                if (listChunk.Count > 0)
                {

                    ChunkDataResult chunkDataResult = CompressObject.GetInstance.ChunkDataResultClientVerify(listChunk);
                    if (chunkDataResult != null)
                        result = CompressObject.GetInstance.ConvertChunkDataResultToList<RFIDTagStorage_Testing>(chunkDataResult);
                }
                var resultQue = result;

            }
        }
        static void GetCobaDownloadImage()
        {
            HttpClient client = SetHttpClient();
            ChunkData hasil = new ChunkData();
            List<ChunkData> listChunk = new List<ChunkData>();
            byte[] result = null;
            paramData = "/GetCobaDownloadImage";
            HttpResponseMessage response = client.GetAsync(string.Format("{0}{1}", routeController, paramData)).Result;
            IEnumerable<string> headerValues = null;
            string checkRequestHeader = CompressObject.GetInstance.ChunkRequestDownloadHeader;
            string filename = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                response.Headers.TryGetValues(CompressObject.GetInstance.ChunkRequestDownloadHeader, out headerValues);
                if (headerValues != null)
                {
                    checkRequestHeader = CompressObject.GetInstance.ChunkRequestDownloadHeader;
                    if (headerValues.ToList()[0] == CompressObject.GetInstance.ChunkRequestDownloadHeader)
                    {
                        // ada looping ya;
                        var retResponse = response.Content.ReadAsStringAsync().Result;
                        hasil = Newtonsoft.Json.JsonConvert.DeserializeObject<ChunkData>(retResponse);

                        if (hasil != null)
                        {
                            if (hasil.ChunkMaxCount > 0) listChunk.Add(hasil);
                            if (hasil.ChunkMaxCount > 1)
                            {
                                int maxLoop = hasil.ChunkMaxCount;
                                string chungKey = hasil.ChunkKey;

                                for (int i = 0; i < maxLoop; i++)
                                {
                                    string chungKeyCurrent = chungKey + "_" + (i + 1).ToString();
                                    client.DefaultRequestHeaders.Remove(CompressObject.GetInstance.ChunkRequestDownloadHeader);
                                    client.DefaultRequestHeaders.Add(CompressObject.GetInstance.ChunkRequestDownloadHeader, chungKeyCurrent);
                                    response = client.GetAsync(string.Format("{0}{1}", routeController, paramData)).Result;
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var retResponsePartial = response.Content.ReadAsStringAsync().Result;
                                        hasil = Newtonsoft.Json.JsonConvert.DeserializeObject<ChunkData>(retResponsePartial);
                                        listChunk.Add(hasil);
                                    }
                                }
                            }
                        }



                    }
                }
                else
                {
                    checkRequestHeader = "Not ChunkLoop";
                    var retResponse = response.Content.ReadAsStringAsync().Result;
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<byte[]>(retResponse);
                }
                if (listChunk.Count > 0)
                {
                    ChunkDataResult chunkDataResult = CompressObject.GetInstance.ChunkDataResultClientVerify(listChunk);
                    if (chunkDataResult != null)
                        result = CompressObject.GetInstance.ConvertChunkDataResultToByteArray(chunkDataResult);
                }
                //string tempPath = @"D:\Makan\ImgTest_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc";//kecil
                string tempPath = @"D:\Makan\ImgTest_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";//besar
                try
                {
                    System.IO.File.WriteAllBytes(tempPath, result);
                }
                catch (Exception ex)
                {
                    _ = ex.Message.ToString();
                }
                var resultQue = result;

            }
        }
        static void PostCobaUploadImage()
        {
            HttpClient client = SetHttpClient();
            ChunkData hasil = new ChunkData();
            List<ChunkData> listChunk = new List<ChunkData>();
            paramData = "/PostCobaUploadImage";
            HttpResponseMessage response = client.GetAsync(string.Format("{0}{1}", routeController, paramData)).Result;
            IEnumerable<string> headerValues = null;
            string checkRequestHeader = CompressObject.GetInstance.ChunkRequestDownloadHeader;
            string filename = string.Empty;
            byte[] img = File.ReadAllBytes(@"D:\makan\daging3.doc");//kecil
                                                                    //byte[] img = File.ReadAllBytes(@"D:\makan\daging.jpg");//besar

            List<ChunkData> listPreparation = CompressObject.GetInstance.ChunkDataPreparation("MyChunkyBar", img);
            bool isMustChunked = false;
            client = SetHttpClient();
            if (CompressObject.GetInstance.ChunkIsAMust(listPreparation)) isMustChunked = true;
            if (isMustChunked)
            {
                string chunkKey = listPreparation[0].ChunkKey;
                string chungKeyCurrent = string.Empty;
                string valueItemPreparation = string.Empty;
                HttpContent contentPreparation = null;
                HttpResponseMessage responsePreparation = null;
                for (int i = 0; i < listPreparation.Count; i++)
                {
                    chungKeyCurrent = chunkKey + "_" + (i + 1).ToString();
                    client.DefaultRequestHeaders.Remove(CompressObject.GetInstance.ChunkResponseUploadHeader);
                    client.DefaultRequestHeaders.Add(CompressObject.GetInstance.ChunkResponseUploadHeader, chungKeyCurrent);

                    valueItemPreparation = JsonConvert.SerializeObject(listPreparation[i]);
                    contentPreparation = new StringContent(valueItemPreparation, Encoding.UTF8, "application/json");
                    responsePreparation = client.PostAsync(string.Format("{0}{1}", routeController, paramData), contentPreparation).Result;
                    if (responsePreparation.IsSuccessStatusCode)
                        _ = "Ok";
                    else
                        Console.WriteLine("{0} ({1})", (int)responsePreparation.StatusCode, responsePreparation.ReasonPhrase);
                }
                // For verification
                chungKeyCurrent = chunkKey + "_" + "complete";
                client.DefaultRequestHeaders.Remove(CompressObject.GetInstance.ChunkResponseUploadHeader);
                client.DefaultRequestHeaders.Add(CompressObject.GetInstance.ChunkResponseUploadHeader, chungKeyCurrent);
                valueItemPreparation = JsonConvert.SerializeObject(listPreparation[0]);
                contentPreparation = new StringContent(valueItemPreparation, Encoding.UTF8, "application/json");
                responsePreparation = client.PostAsync(string.Format("{0}{1}", routeController, paramData), contentPreparation).Result;
                if (responsePreparation.IsSuccessStatusCode)
                    _ = "Ok";
                else
                    Console.WriteLine("{0} ({1})", (int)responsePreparation.StatusCode, responsePreparation.ReasonPhrase);

            }
            else
            {

                string valueItemPreparation = JsonConvert.SerializeObject(img);
                HttpContent contentPreparation = new StringContent(valueItemPreparation, Encoding.UTF8, "application/json");
                HttpResponseMessage responsePreparation = client.PostAsync(string.Format("{0}{1}", routeController, paramData), contentPreparation).Result;
                if (responsePreparation.IsSuccessStatusCode)
                    _ = "Ok";

            }
        }
    */

        /*WEB SERVER API*/
        /*
        [Microsoft.AspNetCore.Mvc.HttpGet("GetCobaDownload")]
        public async Task<object> GetCobaDownload([FromUri]  string paramFields)
        {
            object result = null;
            var RequestHeaders = this.Request.Headers;
            StringValues ChunkKeyCurrent = "";
            if (RequestHeaders.Keys.Contains(compress.ChunkRequestDownloadHeader))
            {
                RequestHeaders.TryGetValue(compress.ChunkRequestDownloadHeader, out ChunkKeyCurrent);
            }
            if (!string.IsNullOrEmpty(ChunkKeyCurrent))
            {
                result = MemoryCacher.GetInstance.GetValue(ChunkKeyCurrent);
                if (result != null)
                    return (ChunkData)result;
                return null;
            }
            JObject item = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(paramFields);
            decimal labelID = (decimal)item["param_labelID"];
            List<RFIDTagStorage_Testing> contoh = (List<RFIDTagStorage_Testing>)await dalRFIDTagStorageTesting.ListDataAsync(new List<SearchField>());

            if (!CompressObject.GetInstance.ChunkIsAMust(contoh))
            {
                result = contoh;
            }
            else
            {

                this.Response.Headers.TryAdd(compress.ChunkRequestDownloadHeader, compress.ChunkRequestDownloadHeader);
                ChunkData hasil = await compress.ChunkDataDownload("Misal", contoh);
                result = hasil;
            }
            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("GetCobaDownloadImage")]
        public async Task<object> GetCobaDownloadImage()
        {
            object result = null;
            var RequestHeaders = this.Request.Headers;
            StringValues ChunkKeyCurrent = "";
            if (RequestHeaders.Keys.Contains(compress.ChunkRequestDownloadHeader))
            {
                RequestHeaders.TryGetValue(compress.ChunkRequestDownloadHeader, out ChunkKeyCurrent);
            }
            if (!string.IsNullOrEmpty(ChunkKeyCurrent))
            {
                result = MemoryCacher.GetInstance.GetValue(ChunkKeyCurrent);
                if (result != null)
                    return (ChunkData)result;
                return null;
            }

            byte[] contoh = System.IO.File.ReadAllBytes(@"D:\makan\Nasi.jpg");// yg besar
                                                                              // byte[] contoh = System.IO.File.ReadAllBytes(@"D:\makan\makan.doc");//yang kecil
            if (!CompressObject.GetInstance.ChunkIsAMust(contoh))
            {
                result = contoh;
            }
            else
            {

                this.Response.Headers.TryAdd(compress.ChunkRequestDownloadHeader, compress.ChunkRequestDownloadHeader);
                ChunkData hasil = await compress.ChunkDataDownload("Misal", contoh);
                result = hasil;
            }
            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("PostCobaUploadImage")]
        public async Task PostCobaUploadImage([Microsoft.AspNetCore.Mvc.FromBody] object imgku)
        {
            bool IsChunkData = compress.IsChunkData(imgku.ToString());
            byte[] dataByte = null;
            ChunkData dataChunk = null;
            if (IsChunkData)
            {
                dataChunk = Newtonsoft.Json.JsonConvert.DeserializeObject<ChunkData>(imgku.ToString());
                var RequestHeaders = this.Request.Headers;
                StringValues ChunkKeyCurrent = "";
                if (RequestHeaders.Keys.Contains(compress.ChunkResponseUploadHeader))
                {
                    RequestHeaders.TryGetValue(compress.ChunkResponseUploadHeader, out ChunkKeyCurrent);
                }
                if (!string.IsNullOrEmpty(ChunkKeyCurrent))
                {
                    string[] checkChunk = ChunkKeyCurrent.ToString().Split("_");
                    string key1 = string.Empty;
                    string key2 = string.Empty;
                    if (checkChunk.Count() > 1)
                    {
                        key1 = checkChunk[0];
                        key2 = checkChunk[1];
                        if (key2.ToString().ToLower() == "complete")
                        {
                            ChunkDataInfo dataInfo = new ChunkDataInfo
                            {
                                ChunkKey = key1,
                                ChunkMaxCount = dataChunk.ChunkMaxCount
                            };
                            ChunkDataResult result = CompressObject.GetInstance.ChunkDataUploadSvrVerify(dataInfo);
                            dataByte = CompressObject.GetInstance.ConvertChunkDataResultToByteArray(result);
                        }
                        else
                        {
                            await CompressObject.GetInstance.ChunkDataUploadSvr(dataChunk);
                            MemoryCacher.GetInstance.AddMinutes(ChunkKeyCurrent.ToString(), dataChunk, dataChunk.ChunkTimeMinutes);
                        }
                    }
                }
            }
            else
            {
                dataByte = Convert.FromBase64String(imgku.ToString());
            }


            if (dataByte != null)
            {
                string tempPath = @"D:\Makan\ImgTest_daging" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc";//kecil
                //string tempPath = @"D:\Makan\ImgTest_daging" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";//besar
                try
                {
                    System.IO.File.WriteAllBytes(tempPath, dataByte);
                }
                catch (Exception ex)
                {
                    _ = ex.Message.ToString();
                }

            }
            string a = string.Empty;
            // await CompressObject.GetInstance.ChunkDataUploadSvr(myChunkyBar);
        }
        */
    }
}
