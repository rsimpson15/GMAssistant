using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_sheet_demo
{
    internal class Trait 
    {

        // Name of Trait
        public String Name;

        //Type of Trait
        public String Type;

        //Cost of Trait
        public Int16 Cost;

        //The Traits Perk
        public Dictionary<string, Int16> Perk;

        //The Traits Drawback
        public Dictionary<string, Int16> Drawback;

    }
}
