using System;
using System.Collections.Generic;
using System.Text;

namespace GenHelper
{
    public class ChunkData
    {
        public string DataChunk { get; set; }
        public int ChunkMaxCount { get; set; }
        public int ChunkCurrent { get; set; }
        public string ChunkKey { get; set; }
        public bool CompleteChunk { get; set; }
        public string FileName { get; set; }
        public double ChunkTimeMinutes { get; set; }

    }
    public class ChunkDataFileProcess
    {
     
        public byte[] DataChunk { get; set; }
        public bool IsCompleteProcess { get; set; }
        public bool IsError { get; set; }
        public string FileNameWithExt { get; set; }

    }
    public class ChunkDataResult
    {
        public string FileNameWithExt { get; set; }
        public byte[] DataChunk { get; set; }
    }
    public class ChunkDataInfo
    {
        public int ChunkMaxCount { get; set; }
        public string ChunkKey { get; set; }

    }
}
