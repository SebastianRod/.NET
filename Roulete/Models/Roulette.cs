using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulete_.Models
{
    public class Roulette
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public List<Bet> Bet{get; set;}
    }
}
