using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class PathParser
    {
        private string _servingDirectory;
        private string _file;
        private string _buffer;

        public PathParser(string servingDirectory, string buffer)
        {
            _servingDirectory = servingDirectory;
            _buffer = buffer;
        }

        private void ParseGivenPath()
        {
            var splitted = _buffer.Split(' ');
            _file = splitted[1];

            if(_servingDirectory == null)
            {
                _servingDirectory = "";
                _file = _file.TrimStart('/');
            }

            if(_file == "/" || _file == "")
            {
                _file += "index.html";
            }
        }

        public string getPath()
        {
            ParseGivenPath();
            return _servingDirectory + _file;
        }
    }
}
