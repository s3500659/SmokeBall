using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IFileReader
    {
        string ReadAllText(string path);
    }

    public class FileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
