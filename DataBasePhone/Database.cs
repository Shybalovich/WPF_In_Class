using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

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

        private string[] separator = new string[] { "\",\"\r\n", "\",\"", "\""};

        public readonly static Database Instance = new Database();
        public string pathToDatabase = @"../../database.txt";            // файл с данными
        public string pathToLineIndexes = @"../../LineIndexes.txt";      // файл с номерами позиций начала строк
        public string pathToLineIndexesPosition = @"../../LineIndexesPosition.txt";      // файл с номерами позиций начала строк

        private Database()
        {
        }

        //private int getListNumberInOrder()
        //{
        //    int n = 0;
        //    using(StreamReader file = new StreamReader(pathToDatabase))
        //    {
        //        string line = "";
        //        while (file.Peek() != -1)
        //        {
        //            line = file.ReadLine();
        //        }
        //        if (line != "")
        //        {
        //            string[] arrString = line.Split(separator, StringSplitOptions.None);
        //            n = Convert.ToInt32(arrString[0]);
        //        }
        //    }
        //    return n;
        //}

        public void Add(Record record)
        {
            // 1. открыть файл, перемотать в конец
            // 2. узнать позицию курсока
            // 3. записать запись
            // 4. закрыть
            // 5. записать в другой файл позицию курсора
            using(StreamWriter writeFile = new StreamWriter(pathToDatabase, true, Encoding.Unicode))
            {               
                writeFile.BaseStream.Seek(0, SeekOrigin.End);
                int numberInOrder = -1;
                long position = writeFile.BaseStream.Position;
                using(BinaryWriter positionFile = new BinaryWriter(File.OpenWrite(pathToLineIndexes)))
                {
                    positionFile.Seek(0, SeekOrigin.End);
                    positionFile.Write(position);
                }
                using (FileStream indexFile = new FileStream(pathToLineIndexes, FileMode.OpenOrCreate))
                {
                   byte[] index = new byte[4];
                   if(indexFile.Length != 0)
                   {
                       indexFile.Seek(-4, SeekOrigin.End);
                       indexFile.Read(index, 0, 4);
                       numberInOrder = BitConverter.ToInt32(index, 0);
                   }
                }
                ++numberInOrder;
                string line = "\"" + numberInOrder + "\",\"" + record.ID + "\",\"" + record.LastName + "\",\"" + record.FirstName + "\"\r\n";
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
                Record newRecord = new Record();
                int maxIndex = -1;
                using (BinaryReader indexFile = new BinaryReader(File.OpenRead(pathToLineIndexes)))
                {
                    if(indexFile.BaseStream.Length > 0)
                    {
                        indexFile.BaseStream.Seek(-4, SeekOrigin.End);
                        maxIndex = indexFile.ReadInt32();
            }
        }
                if (LineNumber >= 0 && LineNumber <= maxIndex)
        {
                    long position = 0;
                    using (BinaryReader posiFile = new BinaryReader(File.OpenRead(pathToLineIndexesPosition)))
            {
                        if (posiFile.BaseStream.Length > 0)
                {
                            posiFile.BaseStream.Seek(8 * LineNumber, SeekOrigin.Begin);
                            position = posiFile.ReadInt64();
                }
            }
                    using(StreamReader writeFile = new StreamReader(pathToDatabase, Encoding.Unicode))
            {
                        writeFile.BaseStream.Seek(position, SeekOrigin.Begin);
                        string line = writeFile.ReadLine();
                        string[] arrString = line.Split(separator, StringSplitOptions.None);
                        newRecord.ID = Convert.ToInt32(arrString[1]);
                        newRecord.LastName = arrString[2];
                        newRecord.FirstName = arrString[3];
            }
            }
                return newRecord;
            }

        }
        
        public void deleteAllFile()
        {
            File.Delete(pathToDatabase);
            File.Delete(pathToLineIndexes);
            File.Delete(pathToLineIndexesPosition);

            File.Create(pathToDatabase).Dispose();
            File.Create(pathToLineIndexes).Dispose();
            File.Create(pathToLineIndexesPosition).Dispose();
        }
        
    }
}
