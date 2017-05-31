using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataInFile
{
    class StringIComparer : AbstrComparer, IComparer<long>
    {
        public StringIComparer(Data data, StreamReader file, int numberSubstring = 0)
        {
            this.data = data;
            this.file = file;
            this.numberSubstring = numberSubstring;
        }

        public int Compare(long p1, long p2)
        {
            string substring1 = data.getSubstring(file, p1, numberSubstring);
            string substring2 = data.getSubstring(file, p2, numberSubstring);
            return substring1.CompareTo(substring2);
        }
    }
}
