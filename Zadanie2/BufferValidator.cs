﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class BufferValidator
    {
        public bool Validate(string buffer)
        {
            return buffer.StartsWith("GET");
        }
    }
}
