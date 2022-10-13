using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minthaZH.Entities
{
    class OlympicResults
    {
        public int Year { get; set; }
        public string Country { get; set; }
        public int[] Medals { get; set; }               //egész számokból álló tömb
        public int Position { get; set; }
    }  

}
