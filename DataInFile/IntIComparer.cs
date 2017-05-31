using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataInFile
{
    class IntIComparer : AbstrComparer, IComparer<long>
    {
        public IntIComparer(Data data, StreamReader file, int numberSubstring = 0)
        {
            this.data = data;
            this.file = file;
            this.numberSubstring = numberSubstring;
        }

        public int Compare(long p1, long p2)
        {
            int num1 = Convert.ToInt32(data.getSubstring(file, p1, numberSubstring));
            int num2 = Convert.ToInt32(data.getSubstring(file, p2, numberSubstring));
            if (num1 > num2)
                return 1;
            else if (num1 < num2)
                return -1;
            else
                return 0;
        }
    }
}
