using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class WorkForFile
    {
        public static void OpenOrCreateFile(string path, string text)
        {
            using(var file = new StreamWriter(path, true))
                file.WriteLine(text);
        }
    }
}
