﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenMcdf.Extensions.OLEProperties
{
    public class DictionaryEntry
    {
        int codePage;
        public DictionaryEntry(int codePage)
        {
            this.codePage = codePage;
        }

        public uint PropertyIdentifier { get; set; }
        public int Length { get; set; }
        public String Name { get { return GetName(); } }

        private byte[] nameBytes;

       

        public void Read(BinaryReader br)
        {
            PropertyIdentifier = br.ReadUInt32();
            Length = br.ReadInt32();
            nameBytes = br.ReadBytes(Length);
            int m = Length % 4;

            if (m > 0)
                br.ReadBytes(m);
        }

        private string GetName()
        {
            return Encoding.GetEncoding(this.codePage).GetString(nameBytes);
        }


    }
}