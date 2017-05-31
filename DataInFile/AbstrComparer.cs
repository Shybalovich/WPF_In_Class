using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataInFile
{
    abstract class AbstrComparer
    {
        protected StreamReader file;
        protected int numberSubstring;
        protected Data data;
    }
}
