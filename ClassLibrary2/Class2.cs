using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class2 : IClass2
    {
        public string GetName()
        {
            return $"It is {DateTime.Now} and my name is John Doe";
        }
    }
}
