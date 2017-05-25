using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace DataBasePhone
{
    class experimentFile
    {
        private string pathFile = @"..\..\tmp.txt";

        public static string getLengsInfFile(String fileName)
        {
            string s = "";
            long lengthFile0, lengthFile1, start, end;
            using(BinaryReader file = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                lengthFile0 = file.BaseStream.Length;
                start = file.BaseStream.Position;
                file.BaseStream.Seek(0, SeekOrigin.End);
                end = file.BaseStream.Position;
                lengthFile1 = file.BaseStream.Length;
                s += "Начало: " + lengthFile0 + "(" + start + ")" + " конец:" + lengthFile1 + "(" + end + ")";
            }
            return s;
        }
        public string printInFile()
        {
            //long content1 = 1;
            string content2 = "\n\r";

            string s = "";
            long lengthFile0, lengthFile1, start, end;
            //using(FileStream file = new FileStream(pathFile, FileMode.Create))
            //{
            //    lengthFile0 = file.Length;
            //    start = file.Position;
            //    byte[] arr = BitConverter.GetBytes(content1);
            //    file.Write(arr, 0, arr.Length);
            //    lengthFile1 = file.Length;
            //    end = file.Position;
            //}

            using (FileStream file = new FileStream(pathFile, FileMode.Create))
            {
                lengthFile0 = file.Length;
                start = file.Position;
                byte[] arr = Encoding.Unicode.GetBytes(content2);
                file.Write(arr, 0, arr.Length);
                lengthFile1 = file.Length;
                end = file.Position;
                s += "Начало: " + lengthFile0 + "(" + start + ")" + " конец:" + lengthFile1 + "(" + end + ")";
            }

            using(BinaryReader file = new BinaryReader(File.Open( pathFile, FileMode.OpenOrCreate)))
            {
                lengthFile0 = file.BaseStream.Length;
                start = file.BaseStream.Position;
                file.BaseStream.Seek(0, SeekOrigin.End);
                end = file.BaseStream.Position;
                lengthFile1 = file.BaseStream.Length;
                s += "Начало: " + lengthFile0 + "(" + start + ")" + " конец:" + lengthFile1 + "(" + end + ")";
            }
            return s;

        }
        public long getArrIndex(String fileName)
        {
            BinaryReader file = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate));
            long length = file.BaseStream.Length;
            return length;
        }
    }
}
