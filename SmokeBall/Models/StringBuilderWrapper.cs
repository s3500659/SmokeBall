using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IStringBuilderWrapper
    {
        void Append(string value);
        void Remove(int startIndex, int length);
        string ToString();
        int GetLength();
    }
    public class StringBuilderWrapper : IStringBuilderWrapper
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public void Append(string value)
        {
            _sb.Append(value);
        }

        public void Remove(int startIndex, int length)
        {
            _sb.Remove(startIndex, length);
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        public int GetLength()
        {
            return _sb.Length;
        }
    }
}
