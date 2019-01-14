using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_sheet_demo 
{
    /// <summary>
    /// A Generic Character Class that can be extended to include any set of
    /// attributes for a character from a variety of systems.
    /// </summary>
    
    [Serializable]
    class Character
    {
        /// <summary>
        /// Auto properties for this object.
        /// </summary>
       
        // Profile
        public Dictionary<string, string> Profile;

        // Stats
        public Dictionary<string, int> Stats;

        // Skills
        public Dictionary<string, Dictionary<string, int>> Skills;

        //Rescources
        public Int16 LifeForce;
        public Int16 Cosmosis;

    }
}
