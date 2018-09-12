using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_sheet_demo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterRoot character = new CharacterRoot();
            character.Add("Profile", new Dictionary<string, string>());
            character.Add("Stats", new Dictionary<string, int>());
            character.Add("Skills", new Dictionary<string, Dictionary<string, int>>());
            character.Add("Traits", new List<Dictionary<string, string>>());
            character.Add("Other", new Dictionary<string, int>());

            // Add the profile to the character.
            // Assigning a variable to the element you want in the object
            // collection/graph can save you typing and make the code more
            // readable. This is only done for the profile in this example.
            // All other examples are verbose to demonstrate navigating the 
            // character sheet using code.
            var profile = character.Get<Dictionary<string, string>>("Profile");
            // Add the character profile to the test character.
            profile.Add("Name", "Scarlett Cooper");
            profile.Add("Affiliation", "Aether");
            profile.Add("Species", "Aetherian(H)");
            profile.Add("Profession", "Student");
            profile.Add("Age", "17");
            profile.Add("Class", "Viscountess");
            profile.Add("Sex", "Female");
            profile.Add("Concept", "Impetuous Noble Girl");

            // Add the character stats to the character
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Agility", 2);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Fortitude", 2);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Strength", 2);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Magnetism", 3);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Alertness", 3);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Intellect", 2);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Persuasion", 2);
            character.Get<Dictionary<string, int>>("Stats")
                .Add("Instinct", 4);

            // Add the subcategories to the skills.
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                .Add("Academic", new Dictionary<string, int>());
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                .Add("Combat", new Dictionary<string, int>());
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                .Add("Awareness", new Dictionary<string, int>());
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                .Add("Talent", new Dictionary<string, int>());
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                .Add("Somatic", new Dictionary<string, int>());
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                .Add("Charm", new Dictionary<string, int>());

            // Add the skills to the categories
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Academic"].Add("Politics", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Academic"].Add("Schooled", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Awareness"].Add("Keen Sense", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Awareness"].Add("Psychology", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Awareness"].Add("Research", 1);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Talent"].Add("Cosmology", 1);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Talent"].Add("Performance", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Talent"].Add("Seneschal", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Somatic"].Add("Athletics", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Somatic"].Add("Mount Riding", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Somatic"].Add("Resolve", 2);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Charm"].Add("Allure", 3);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Charm"].Add("Artistry", 3);
            character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Charm"].Add("Espionage", 1);

            // Add trait values
            // First create each trait, this will be a dictionary of values for that trait.
            character.Get<List<Dictionary<string, string>>>("Traits")
                .Add(new Dictionary<string, string>());
            character.Get<List<Dictionary<string, string>>>("Traits")
                .Add(new Dictionary<string, string>());
            character.Get<List<Dictionary<string, string>>>("Traits")
                .Add(new Dictionary<string, string>());
            character.Get<List<Dictionary<string, string>>>("Traits")[0]
                .Add("Name", "Spirit Connection");
            character.Get<List<Dictionary<string, string>>>("Traits")[0]
                .Add("Cost", "2");
            character.Get<List<Dictionary<string, string>>>("Traits")[0]
                .Add("Type", "Spiritual");
            character.Get<List<Dictionary<string, string>>>("Traits")[0]
                .Add("Perk",
                "Through your connection you gain various bonuses.");
            character.Get<List<Dictionary<string, string>>>("Traits")[0]
                .Add("Drawback",
                "When stressed or upset roll int+resolve to not suffer a "
                + "vision.");
            character.Get<List<Dictionary<string, string>>>("Traits")[1]
                .Add("Name", "Spiritual Sensitivity");
            character.Get<List<Dictionary<string, string>>>("Traits")[1]
                .Add("Cost", "2");
            character.Get<List<Dictionary<string, string>>>("Traits")[1]
                .Add("Type", "Spiritual");
            character.Get<List<Dictionary<string, string>>>("Traits")[1]
                .Add("Perk", "+1 dice to all Cosmosis rolls.");
            character.Get<List<Dictionary<string, string>>>("Traits")[1]
                .Add("Drawback",
                "Must roll int+resolve to not succumb to ghost's torment.");
            character.Get<List<Dictionary<string, string>>>("Traits")[2]
                .Add("Name", "Brazen");
            character.Get<List<Dictionary<string, string>>>("Traits")[2]
                .Add("Cost", "1");
            character.Get<List<Dictionary<string, string>>>("Traits")[2]
                .Add("Type", "Personal");
            character.Get<List<Dictionary<string, string>>>("Traits")[2]
                .Add("Perk",
                "-1 TN to charm rolls that require bravery.");
            character.Get<List<Dictionary<string, string>>>("Traits")[2]
                .Add("Drawback",
                "+1 TN to reading others with psychology.");

            // Add the other attributes. For this demonstration we're using 
            // array-like syntax to retrieve the other dictionary from the
            // object. Since the ChracterRoot object is storing everything as
            // an object, the Dictionary<string,int> needs to be unboxed before
            // we can use it.
            var other = (Dictionary<string, int>)character["Other"];
            other.Add("Life Force", 0);
            other.Add("Cosmosis", 6);

            /// This section is where we will output the character information
            ///  to the console to test accessing the information from the data 
            ///  object.

            StringBuilder sb = new StringBuilder();
            sb.Append("===================================================\n"
                + "Character Sheet Retrieval Test"
                + "\n===================================================");
            // Output the profile information
            sb.Append("\n Profile:\n");
            foreach (KeyValuePair<string, string> pair
                in character.Get<Dictionary<string, string>>("Profile"))
            {
                sb.Append("\t" + pair.Key + ": " + pair.Value + '\n');
            }

            // Output stats
            sb.Append(" Stats:\n");
            foreach (KeyValuePair<string, int> pair
                in character.Get<Dictionary<string, int>>("Stats"))
            {
                sb.Append("\t" + pair.Key + ": " + pair.Value + '\n');
            }
            // Output skills.
            sb.Append("\n Skills:\n");
            // For each skill subset.
            foreach (KeyValuePair<string, Dictionary<string, int>> skillSet
                in character.Get<Dictionary<string, Dictionary<string, int>>>("Skills"))
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
            // Output traits
            sb.Append("\n Traits:\n");
            // For this loop we're going to access these by getting the list of
            // dictionaries from the character.
            var traits = character.Get<List<Dictionary<string, string>>>("Traits");
            for (int i = 0; i < traits.Count; ++i)
            {
                foreach (KeyValuePair<string, string> pair
                    in traits[i])
                {
                    sb.Append("\t\t" + pair.Key + ": " + pair.Value + '\n');
                }
                if (i < traits.Count - 1)
                    sb.Append('\n');
            }
            // Output other items.
            foreach (KeyValuePair<string, int> pair
                in character.Get<Dictionary<string, int>>("Other"))
            {
                sb.Append(" " + pair.Key + ": "
                    + pair.Value.ToString() + '\n');
            }
            Console.WriteLine(sb.ToString());

            /// In this section we will test the damage and heal functions
            /// of the CharacterRoot class. Technically speaking these functions
            /// could be in another class since they take arguments independently
            /// of the CharacterRoot class.
            /// There might be a better way to navigate to the end value we want
            /// to manipulate using just the data in the set.

            // Output the current value
            Console.WriteLine("{0}'s current allure: {1}", 
                character.Get<Dictionary<string, string>>("Profile")["Name"], 
                character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Charm"]["Allure"].ToString());
            // Damage the value
            Console.WriteLine("\n\nDealing 1 point of damage to {0}'s allure.", 
                character.Get<Dictionary<string, string>>("Profile")["Name"]);
            character.Damage(
                character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Charm"], "Allure", 1);
            // Check that the value was changed in the character sheet.
            Console.WriteLine("{0}'s allure after damage: {1}", 
                character.Get<Dictionary<string, string>>("Profile")["Name"], 
                character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                    ["Charm"]["Allure"].ToString());
            // Heal the value
            Console.WriteLine("\n{0}'s allure has increased!", 
                character.Get<Dictionary<string, string>>("Profile")["Name"]);
            character.Heal(
                character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                ["Charm"], "Allure", 3);
            Console.WriteLine("{0}'s allure after healing: {1}", 
                character.Get<Dictionary<string, string>>("Profile")["Name"],
                character.Get<Dictionary<string, Dictionary<string, int>>>("Skills")
                    ["Charm"]["Allure"].ToString());

            Console.WriteLine("\n\n\nTests Complete! Press any key to exit...");
            Console.ReadKey();

        }
    }
}
