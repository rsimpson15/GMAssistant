using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_sheet_demo_2
{
    class CharacterRoot
    {
        // This is a dictionary that stores any object.
        public Dictionary<string, object> DataSet = new Dictionary<string, object>();
        // Here you can add the object to the data set.
        public void Add<T>(string key, T value) where T: class
        {
            DataSet.Add(key, value);
        }
        // Here we can get the object unboxed to a specified type.
        public T Get<T>(string key) where T : class
        {
            return DataSet[key] as T;
        }
        // This allows the selection of objects in the data set using
        // array-like notation. However, the item returned will be an
        // object. To use it as an array, list, or dictionary it will
        // need to be unboxed.
        public object this [string index]
        {
            get { return DataSet[index]; }
            set { DataSet[index] = value; }
        }
        /// <summary>
        /// Take the passed in Dictionary containing the stat that should
        /// be enhanced/improved/healed and adds to that stat.
        /// </summary>
        /// <param name="valueSet">The dictionary containing that stat.</param>
        /// <param name="key">The key that contains the value to be manipulated.</param>
        /// <param name="healing">The value to heal the stat. </param>
        public void Heal(Dictionary<string, int> valueSet, string key, int healing)
        {
            valueSet[key] += healing;
        }
        /// <summary>
        ///  Takes the passed in Dictionary containing the stat that should
        ///  be damaged and deals damage to that stat.
        /// </summary>
        /// <param name="valueSet">The dictionary that contains the stat to damage</param>
        /// <param name="key">The key that contains the value being manipulated.</param>
        /// <param name="damage">The damage value.</param>
        public void Damage(Dictionary<string, int> valueSet,string key, int damage)
        {
            valueSet[key] -= damage;
            
        }
    }
}
