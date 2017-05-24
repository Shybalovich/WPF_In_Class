﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataBasePhone
{
    class Database
    {
        public class Record
        {
            public int ID;
            public string LastName;
            public string FirstName;
        }


        public readonly static Database Instance = new Database();
        private string pathToDatabase = "../../database.txt";
        private string pathToLineIndexes = "../../LineIndexes.txt";
        private Database()
        {

        }
        public void Add(Record record)
        {
            // 1. открыть файл, перемотать в конец
            // 2. узнать позицию курсока
            // 3. записать запись
            // 4. закрыть
            // 5. записать в другой файл позицию курсора
            using (FileStream write = new FileStream(pathToDatabase, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                write.Seek(0, SeekOrigin.End);
                long index = write.Position;
                string line = "" + record.ID + "," + record.LastName + "," + record.FirstName + "\r\n";
                Byte[] byteArr = Encoding.Unicode.GetBytes(line);
                int count = byteArr.Length;
                write.Write(byteArr, 0, count);
                using(FileStream fileIndex = new FileStream(pathToLineIndexes, FileMode.OpenOrCreate))
                {
                    Byte[] indexByte = BitConverter.GetBytes(index);
                    fileIndex.Write(indexByte, 0, indexByte.Length);
                } 
            }
        }

        public Record this[int LineNumber]
        {
            get
            {
                // открыть файл с построчным индексом
                // найти запись номер LineNumber, прочитали в offset
                // открыли основной файл, перемотали на offest
                // прочитали запись 
                return new Record();
            }

        }

        
    }
}
