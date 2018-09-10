using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_sheet_demo
{
    /// <summary>
    /// This program is a test application that will create a Json character
    /// sheet and save it to disk, then de-serialize that Json to an object.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // create the test character.
            Console.Write("Creating test character...");
            Character character = new Character();
            // Initialize the properties in the Character class.
            character.Profile = new Dictionary<string, string>();
            character.Stats = new Dictionary<string, int>();
            character.Skills = new Dictionary<string, Dictionary<string, int>>();
            character.Traits = new List<Dictionary<string, string>>();
            character.Other = new Dictionary<string, int>();
            // Add the character profile to the test character.
            character.Profile.Add("Name", "Scarlett Cooper");
            character.Profile.Add("Affiliation", "Aether");
            character.Profile.Add("Species", "Aetherian(H)");
            character.Profile.Add("Profession", "Student");
            character.Profile.Add("Age", "17");
            character.Profile.Add("Class", "Viscountess");
            character.Profile.Add("Sex", "Female");
            character.Profile.Add("Concept", "Impetuous Noble Girl");

            // Add the character stats to the character
            character.Stats.Add("Agility", 2);
            character.Stats.Add("Fortitude", 2);
            character.Stats.Add("Strength", 2);
            character.Stats.Add("Magnetism", 3);
            character.Stats.Add("Alertness", 3);
            character.Stats.Add("Intellect", 2);
            character.Stats.Add("Persuasion", 2);
            character.Stats.Add("Instinct", 4);

            // Add the subcategories to the skills.
            character.Skills.Add("Academic", new Dictionary<string, int>());
            character.Skills.Add("Combat", new Dictionary<string, int>());
            character.Skills.Add("Awareness", new Dictionary<string, int>());
            character.Skills.Add("Talent", new Dictionary<string, int>());
            character.Skills.Add("Somatic", new Dictionary<string, int>());
            character.Skills.Add("Charm", new Dictionary<string, int>());

            // Add the skills to the categories
            character.Skills["Academic"].Add("Politics", 2);
            character.Skills["Academic"].Add("Schooled", 2);
            character.Skills["Awareness"].Add("Keen Sense", 2);
            character.Skills["Awareness"].Add("Psychology", 2);
            character.Skills["Awareness"].Add("Research", 1);
            character.Skills["Talent"].Add("Cosmology", 1);
            character.Skills["Talent"].Add("Performance", 2);
            character.Skills["Talent"].Add("Seneschal", 2);
            character.Skills["Somatic"].Add("Athletics", 2);
            character.Skills["Somatic"].Add("Mount Riding", 2);
            character.Skills["Somatic"].Add("Resolve", 2);
            character.Skills["Charm"].Add("Allure", 3);
            character.Skills["Charm"].Add("Artistry", 3);
            character.Skills["Charm"].Add("Espionage", 1);

            // Add trait values
            character.Traits.Add(new Dictionary<string, string>());
            character.Traits.Add(new Dictionary<string, string>());
            character.Traits.Add(new Dictionary<string, string>());
            character.Traits[0].Add("Name", "Spirit Connection");
            character.Traits[0].Add("Cost", "2");
            character.Traits[0].Add("Type", "Spiritual");
            character.Traits[0].Add("Perk", 
                "Through your connection you gain various bonuses.");
            character.Traits[0].Add("Drawback", 
                "When stressed or upset roll int+resolve to not suffer a " 
                + "vision.");
            character.Traits[1].Add("Name", "Spiritual Sensitivity");
            character.Traits[1].Add("Cost", "2");
            character.Traits[1].Add("Type", "Spiritual");
            character.Traits[1].Add("Perk", "+1 dice to all Cosmosis rolls.");
            character.Traits[1].Add("Drawback",
                "Must roll int+resolve to not succumb to ghost's torment.");
            character.Traits[2].Add("Name", "Brazen");
            character.Traits[2].Add("Cost", "1");
            character.Traits[2].Add("Type", "Personal");
            character.Traits[2].Add("Perk", 
                "-1 TN to charm rolls that require bravery.");
            character.Traits[2].Add("Drawback", 
                "+1 TN to reading others with psychology.");

            // Add other values
            character.Other.Add("Life Force", 0);
            character.Other.Add("Cosmosis", 6);
            Console.Write(" Done.\n\nCreating Json Object...");

            // Serialize to JSON using Newtonsoft Json.
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter("json.txt"))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                serializer.Serialize(jw, character);
            }
            Console.Write(" Done.\n\nConsuming Json Object to C# Object...");
            
            // read the json text to a string.
            string jsonString = File.ReadAllText("json.txt");
            // Deserialize the Json to an object.
            Character deserializedCharacter = 
                JsonConvert.DeserializeObject<Character>(jsonString);
            Console.Write(" Done.\n\n");
            // Start demonstrating the character information output.
            Console.WriteLine(
                "===================================================\n"
                + "Character Sheet Test"
                + "\n===================================================");
            // Since we'll be printing a lot of information a string builder
            // will be faster than a set of console writes.
            StringBuilder sb = new StringBuilder();
            // Profile
            sb.Append("\n Profile:\n");
            foreach (KeyValuePair<string, string> pair 
                in deserializedCharacter.Profile){
                sb.Append("\t" + pair.Key + ": " + pair.Value + '\n');
            }
            // Stats
            sb.Append(" Stats:\n");
            foreach (KeyValuePair<string, int> pair 
                in deserializedCharacter.Stats)
            {
                sb.Append("\t" + pair.Key + ": " + pair.Value + '\n');
            }
            // Skills
            sb.Append("\n Skills:\n");
            // For each skill subset.
            foreach(KeyValuePair<string, Dictionary<string, int>> skillSet 
                in deserializedCharacter.Skills)
            {
                // Print the skill subset name.
                sb.Append("\t" + skillSet.Key + ":\n");
                
                // If there are skills in that subset.
                if (skillSet.Value.Count > 0)
                {
                    // Print the skills in that subset.
                    foreach (KeyValuePair<string, int> skill in skillSet.Value)
                    {
                        sb.Append("\t\t" + skill.Key + ": " 
                            + skill.Value.ToString() + '\n');
                    }
                }
                // Otherwise, print none.
                else
                    sb.Append("\t\tNone\n");
                
            }
            // Traits
            sb.Append("\n Traits:\n");
            for(int i = 0; i < deserializedCharacter.Traits.Count; ++i)
            {
                foreach (KeyValuePair<string, string> pair 
                    in deserializedCharacter.Traits[i])
                {
                    sb.Append("\t\t" + pair.Key + ": " + pair.Value + '\n');
                }
                if (i < deserializedCharacter.Traits.Count - 1)
                    sb.Append('\n');
            }
            // Other
            foreach (KeyValuePair<string, int> pair
                in deserializedCharacter.Other)
            {
                sb.Append(" " + pair.Key + ": " 
                    + pair.Value.ToString() + '\n');
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}
