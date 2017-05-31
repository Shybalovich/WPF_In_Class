using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataInFile
{
    class Data
    {
        private string pathHederFile = @"../../HederFile.txt";
        private string pathPositionFile = @"../../PositionFile.txt";
        private string pathSortPositionFile = @"../../SortPositionFile.txt";

        private string[] seporator = new string[] { "\",\"", ",\"", "\""};

        public static int index = 0;
        
        public void Add(string myName)
        {
            long position;
            using(StreamWriter file = new StreamWriter(pathHederFile, true))
            {
                position = file.BaseStream.Position;
                file.BaseStream.Seek(0, SeekOrigin.End);
                position = file.BaseStream.Position;
                string s = "" + index + ",\"" + myName + "\"";
                file.WriteLine(s);
                ++index;
            }
            using(BinaryWriter positionFile = new BinaryWriter(File.OpenWrite(pathPositionFile)))
            {
                positionFile.Seek(0, SeekOrigin.End);
                positionFile.Write(position);
            }
        }

        // очистка файлов
        public void ClearFile()
        {
            File.Delete(pathHederFile);
            File.Create(pathHederFile).Dispose();
            File.Delete(pathPositionFile);
            File.Create(pathPositionFile).Dispose();
            index = 0;
        }

        // получение имя по номеру по порядку
        public string this[int i]
        {
            get
            {
                string substring = "";
                using (BinaryReader positionFile = new BinaryReader(File.Open(pathPositionFile, FileMode.OpenOrCreate)))
                {
                    int count =(int)((positionFile.BaseStream.Length) / 8);
                    if(i >= 0 && i < count)
                    {
                        positionFile.BaseStream.Seek(i + 8, SeekOrigin.Begin);
                        long newPosition = positionFile.ReadInt64();
                        using(StreamReader file = new StreamReader(pathHederFile))
                        {
                            substring = getSubstring(file, newPosition, 1);
                        }
                    }
                }
                return substring;
            }
        }

        // возвращает подстроку из потока файла 
        // position - начало строки в файлу,
        // numberSubstring - номер подстроки в строке
        private string getSubstring(StreamReader file, long position, int numberSubstring = 1)
        {
            file.BaseStream.Seek(position, SeekOrigin.Begin);
            string[] arrSugstring = file.ReadLine().Split(seporator, StringSplitOptions.None);
            return arrSugstring.Length >= numberSubstring && numberSubstring >= 0 ? arrSugstring[numberSubstring] : "Не верный индекс";
        }
    }

}
