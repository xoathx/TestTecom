using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestTecom
{
    class Candidate
    {     
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public float Vision { get; set; }
        public List<string> Diseases { get; set; }   
    }
}
