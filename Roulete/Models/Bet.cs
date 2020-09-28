using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulete_.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int UserId { get; set; }

        public string Colour { get; set; }
    }
}
