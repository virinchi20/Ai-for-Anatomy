using System.Collections.Generic;

namespace BarClass
{
    // Class storing individual medicine info
    // New variables can be added as needed
    class Medication
    {
        public string name;
        public Medication(string[] values)
        {
            name = values[0];
        }
    }

    class MedicineDictionary
    {
        // Returns medicine info as a dictionary 
        public static Dictionary<string, Medication> GetDictionary()
        {
            Dictionary<string, Medication> medDictionary = new()
            {
                { "0100304094911342", new Medication(new string[] { "Atropine Sulfate" }) },
                { "664113311004", new Medication(new string[] { "Epinephrine" }) },
                { "0100304091323056", new Medication(new string[] { "LIDOCAINE HCI" }) },
                { "664113369371", new Medication(new string[] { "Midazolam" }) },
                { "664113311196", new Medication(new string[] { "Adenosin" }) },
                { "664113369388", new Medication(new string[] { "Fentanl Citrat" }) },
                { "664113931080", new Medication(new string[] { "Amiodron" }) }
            };
            return medDictionary;
        }
    }
}
