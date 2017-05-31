using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataInFile
{
    enum Substring
    {
        ID,
        Name,
    }

    class Data
    {
        private string pathHederFile;
        private string pathPositionFile;
        private string pathSortPositionFile;
        private string[] seporator;
        private int index;

        public Data()
        {
            pathHederFile = @"../../HederFile.txt";
            pathPositionFile = @"../../PositionFile.txt";
            pathSortPositionFile = @"../../SortPositionFile.txt";
            seporator = new string[] { "\",\"", ",\"", "\"" };
            createAllFile();
            index = getStartIndex();
        }

        private void createAllFile()
        {
            File.Open(pathHederFile, FileMode.OpenOrCreate).Dispose();
            File.Open(pathPositionFile, FileMode.OpenOrCreate).Dispose();
            File.Open(pathSortPositionFile, FileMode.OpenOrCreate).Dispose();
        }

        private void deleteAllFile()
        {
            File.Delete(pathHederFile);
            File.Delete(pathPositionFile);
            File.Delete(pathSortPositionFile);
        }

        public void ClearFile()
        {
            deleteAllFile();
            createAllFile();
            index = 0;
        }

        private int getStartIndex()
        {
            int count;
            using(FileStream file = File.Open(pathPositionFile, FileMode.OpenOrCreate))
            {
                count = (int)(file.Length / 8);
            }
            return count;
        }
        
        public void Add(string myName)
        {
            long position;
            using(StreamWriter file = new StreamWriter(pathHederFile, true))
            {
                position = file.BaseStream.Position;
                string s = "" + index + ",\"" + myName + "\"";
                file.WriteLine(s);
                ++index;
            }
            using(BinaryWriter positionFile = new BinaryWriter(File.OpenWrite(pathPositionFile)))
            {
                var z = positionFile.Seek(0, SeekOrigin.End);
                positionFile.Write(position);
            }

            using (BinaryWriter sortPositionFile = new BinaryWriter(File.OpenWrite(pathSortPositionFile)))
            {
                sortPositionFile.Seek(0, SeekOrigin.End);
                sortPositionFile.Write(position);
            }
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
                        positionFile.BaseStream.Seek(i * 8, SeekOrigin.Begin);
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
        public string getSubstring(StreamReader file, long position, int numberSubstring = 1)
        {
            string[] arrSugstring = getAllSubstringLine(file, position);
            return arrSugstring.Length >= numberSubstring && numberSubstring >= 0 ? arrSugstring[numberSubstring] : "Не верный индекс";
        }

        // возвращает подстроку из потока файла 
        // position - начало строки в файлу,
        public string[] getAllSubstringLine(StreamReader file, long position)
        {
            file.BaseStream.Seek(position, SeekOrigin.Begin);
            return file.ReadLine().Split(seporator, StringSplitOptions.None);
        }

        private List<long> getListPosition(string pathPositionFile)
        {
            List<long> listPosition = new List<long>();
            using (BinaryReader positionFile = new BinaryReader(File.OpenRead(pathPositionFile)))
            {
                while (positionFile.PeekChar() != -1 )
                listPosition.Add(positionFile.ReadInt64());
            }
            return listPosition;
        }

        public List<long> getListPosition(Substring sub = Substring.ID)
        {
            List<long> listPosition = new List<long>();
            switch (sub)
            {
                case Substring.ID:
                    listPosition = getListPosition(pathPositionFile);
                    break;
                case Substring.Name:
                    listPosition = getListPosition(pathSortPositionFile);
                    break;
                default:
                    break;
            }
            return listPosition;
        }

        public void Sort(Substring sub = Substring.ID)
        {
            List<long> list = getListPosition(sub);
            string pathFile = "";
            using (StreamReader file = new StreamReader(pathHederFile))
            {
                switch (sub)
                {
                    case Substring.ID:
                        pathFile = pathPositionFile;
                        list.Sort(new IntIComparer(this, file, 0));
                        break;
                    case Substring.Name:
                        pathFile = pathSortPositionFile;
                        list.Sort(new StringIComparer(this, file, 1));
                        // перезаписали файл
                        using (BinaryWriter positionFile = new BinaryWriter(File.OpenWrite(pathFile)))
                        {
                            foreach (long position in list)
                            {
                                positionFile.Write(position);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }

        public StreamReader getStreamReaderHederFile()
        {
            return new StreamReader(pathHederFile);
        }
    }
}
