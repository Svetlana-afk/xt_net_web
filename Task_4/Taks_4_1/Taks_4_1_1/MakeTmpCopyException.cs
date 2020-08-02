using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Taks_4_1_1
{
    public class MakeTmpCopyException : Exception
    {
        public MakeTmpCopyException()
        {
        }

        public MakeTmpCopyException(string message)
            : base(message)
        {
        }

        public MakeTmpCopyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}