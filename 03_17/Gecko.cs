using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_17
{
    public class Gecko
    {
        public string name { get; set; }
        public string weight { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return $"Név: {name}, {weight}, {age}";
        }
    }
}
