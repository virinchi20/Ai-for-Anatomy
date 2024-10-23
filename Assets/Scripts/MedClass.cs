using System.Collections.Generic;

namespace MedClass
{
    // Class storing information on possible treatment
    // New variables can be added as needed
    class Treatment
    {
        public string weight;
        public string name;
        public string dose;
        public string volume;
        public string color;
        public Treatment(string[] values)
        {
            weight = values[0];
            name = values[1];
            dose = values[2];
            volume = values[3];
            color = values[4];
        }
    }

    class TreatmentDictionary
    {
        // Returns medicine info as a dictionary 
        public static Dictionary<string, List<Treatment>> GetDictionary()
        {
            Dictionary<string, List<Treatment>> trtDictionary = new()
            {
                { "Seizure", new List<Treatment>() {
                    { new Treatment(new string[] { "6-12 lbs", "Midazolam IM", "0.5 mg", "0.1 mL IM", "Gray" }) },
                    { new Treatment(new string[] { "13-16 lbs", "Midazolam IM (5 mg/mL)", "1 mg", "0.2 mL", "Pink" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Midazolam IM (5mg/mL) Give first if no IV", "1 mg", "0.2 mL IM", "Red" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Midazolam IV (5mg/mL)", "0.5 ml", "0.1 mL", "Red" }) },
                    { new Treatment(new string[] { "21-25 lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "1 mg", "0.2 mL IM", "Purple" }) },
                    { new Treatment(new string[] { "21-25 lbs", "Midazolam IM (10 mg/mL) Give first if no IV", "1 mg", "0.2 mL IM", "Purple" }) },
                    { new Treatment(new string[] { "21-25 lbs", "Midazolam IV (5 mg/mL)", "0.5 mg", "0.1 mL", "Purple" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "1.5 mg", "0.3 mL IM", "Yellow" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Midazolam IV (5 mg/mL)", "1 mg", "0.2 mL", "Yellow" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "1.5 mg", "0.3 mL IM", "White" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Midazolam IV (5 mg/mL)", "1 mg", "0.2 mL", "White" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "2 mg", "0.4 mL IM", "Blue" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Midazolam IV (5 mg/mL)", "1 mg", "0.2 mL", "Blue" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "2.5 mg", "0.5 mL IM", "Orange" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Midazolam IV (5 mg/mL)", "1.5 mg", "0.3 mL", "Orange" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "3 mg", "0.6 mL IM", "Green" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Midazolam IV (5 mg/mL)", "1.5 mg", "0.3 mL", "Green" }) },
                    { new Treatment(new string[] { "80+ lbs", "Midazolam IM (5 mg/mL) Give first if no IV", "10 mg", "2 mL IM", "Black" }) },
                    { new Treatment(new string[] { "80+ lbs", "Midazolam IV (5 mg/mL)", "5 mg", "1 mL", "Black" }) }
                    }
                },


                { "Pain", new List<Treatment>() {
                    { new Treatment(new string[] { "6-12 lbs", "Acetaminophen PO (160 mg/5 mL)", "44.8 mg", "1.4 mL PO", "Gray" }) },
                    { new Treatment(new string[] { "13-16 lbs", "Acetaminophen PO (160 mg/5 mL)", "96 mg", "3 mL PO", "Pink" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Acetaminophen PO (160 mg/5 mL)", "128 mg", "4 mL PO", "Red" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Ibuprofen PO (100 mg/5 mL)", "80 mg", "4 mL PO", "Red" }) },
                    { new Treatment(new string[] { "21-25 lbs", "Acetaminophen PO (160 mg/5 mL)", "160 mg", "5 mL PO", "Purple" }) },
                    { new Treatment(new string[] { "21-25 lbs", "Ibuprofen PO (100 mg/5 mL)", "100 mg", "5 mL PO", "Purple" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Acetaminophen PO (160 mg/5 mL)", "192 mg", "6 mL PO", "Yellow" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Ibuprofen (100 mg/5 mL)", "120 mg", "6 mL PO", "Yellow" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Acetaminophen PO (160 mg/5 mL)", "224 mg", "7 mL PO", "White" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Ibuprofen PO (100 mg/5 mL)", "150 mg", "7.5 mL PO", "White" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Acetaminophen PO (160 mg/5 mL)", "288 mg", "9 mL PO", "Blue" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Ibuprofen PO (100 mg/5 mL)", "190 mg", "9.5 mL PO", "Blue" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Acetaminophen PO (160 mg/5 mL)", "384 mg", "12 mL PO", "Orange" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Ibuprofen PO (100 mg/5 mL)", "260 mg", "13 mL PO", "Orange" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Acetaminophen PO (160 mg/5 mL)", "480 mg", "15 mL", "Green" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Ibuprofen PO (100 mg/5 mL)", "300 mg", "15 mL", "Green" }) },
                    { new Treatment(new string[] { "80+ lbs", "Ibuprofen PO (100 mg/5 mL)", "600 mg", "30 mL PO", "Black" }) },
                    { new Treatment(new string[] { "80+ lbs", "Ibuprofen PO (100 mg/5 mL)", "800 mg", "25 mL PO", "Black" }) }
                    }
                },

                { "Hypoglycemia", new List<Treatment>() {
                    { new Treatment(new string[] { "6-12 lbs", "D12.5% (6.25 g/50 mL) 12.5 mL of D50% diluted with 37.5 mL Normal Saline = D12.5% Give slow IV", "2.5 g", "20 mL (D12.5%)", "Gray" }) },
                    { new Treatment(new string[] { "6-12 lbs", "Dextrose 10% (100mg/mL)", "2.5 g", "25 mL", "Gray" }) },
                    { new Treatment(new string[] { "6-12 lbs", "Glucagon IM/IN (1 mg/mL)", "0.5 mg", "0.5 mL IM/IN", "Gray" }) },
                    { new Treatment(new string[] { "13-16 lbs", "D25% (12.5 g/50 mL) 25 mL of D50% diluted with 25 mL of Normal Saline = D25% Give Slow IV", "3.25 g", "13 mL (D25%)", "Pink" }) },
                    { new Treatment(new string[] { "13-16 lbs", "Dextrose 10% (100mg/mL)", "3.3 g", "33 mL (D10%)", "Pink" }) },
                    { new Treatment(new string[] { "13-16 lbs", "Glucagon IM (1 mg/mL)", "0.5 mg", "0.5 mL IM", "Pink" }) },
                    { new Treatment(new string[] { "17-20 lbs", "D25% (12.5 g/50 mL) 25 mL of D50% diluted with 25 mL of Normal Saline = D25% Give Slow IV", "4.25 g", "17 mL (D25%)", "Red" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Dextrose 10% (100mg/mL)", "4.3 g", "43mL", "Red" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Glucagon IM (1 mg/mL)", "0.5 mg", "0.5 mL IM", "Red" }) },
                    { new Treatment(new string[] { "21-25 lbs ", "D25% (12.5 g/50 mL) 25 mL of D50% diluted with 25 mL of Normal Saline = D25% Give Slow IV", "5.0 g", "20 mL (D25%)", "Purple" }) },
                    { new Treatment(new string[] { "21-25 lbs ", "Dextrose 10% (100mg/mL)", "5.0 g", "50 mL", "Purple" }) },
                    { new Treatment(new string[] { "21-25 lbs ", "Glucagon IM (1 mg/mL)", "0.5 mg", "0.5 mL IM", "Purple" }) },
                    { new Treatment(new string[] { "26-31 lbs", "D25% (12.5 g/50 mL) 25 mL of D50% diluted with 25 mL of Normal Saline = D25% Give Slow IV", "6.25 g", "25 mL (D25%)", "Yellow" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Dextrose 10% (100mg/mL)", "6.25 g", "62.5 mL", "Yellow" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Glucagon IM (1 mg/mL)", "0.5 mg", "0.5 mL IM", "Yellow" }) },
                    { new Treatment(new string[] { "32-40 lbs", "D25% (12.5 g/50 mL) 25 mL of D50% diluted with 25 mL of Normal Saline = D25% Give Slow IV", "8 g", "32 mL (D25%)", "White" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Dextrose 10% (100mg/mL)", "8 g", "80 mL", "White" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Glucagon IM (1 mg/mL)", "0.5 mg", "0.5 mL IM", "White" }) },
                    { new Treatment(new string[] { "41-51 lbs", "D25% (12.5 g/50 mL) 25 mL of D50% diluted with 25 mL of Normal Saline = D25% Give Slow IV", "10 g", "40 mL (D25%)", "Blue" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Dextrose 10% (100mg/mL)", "10 g", "100 mL", "Blue" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Glucagon IM (1 mg/mL)", "1 mg", "1 mL IM", "Blue" }) },
                    { new Treatment(new string[] { "52-64 lbs", "D50% (25 g/50 mL) Give Slow IV", "12.5 g", "25 mL (D50%)", "Orange" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Dextrose 10% (100mg/mL)", "12.5 g", "125 mL", "Orange" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Glucagon IM (1 mg/mL)", "1 mg", "1 mL IM", "Orange" }) },
                    { new Treatment(new string[] { "65-79 lbs", "D50% (25 g/50 mL) Give Slow IV", "15 g", "30 mL (D50%)", "Green" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Dextrose 10% (100mg/mL)", "15 g", "150 mL", "Green" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Glucagon IM (1 mg/mL)", "1 mg", "1 mL IM", "Green" }) },
                    { new Treatment(new string[] { "80+ lbs", "D50% (25 g/50 mL) Give Slow IV", "25 g", "50 mL (D50%)", "Black" }) },
                    { new Treatment(new string[] { "80+ lbs", "D10% (25 g/250 mL)", "25 g", "250 mL", "Black" }) },
                    { new Treatment(new string[] { "80+ lbs", "Glucagon IM (1 mg/mL)", "1 mg", "1 mL IM", "Black" }) }
                    }
                },

                { "Cardiac Arrest", new List<Treatment>() {
                    { new Treatment(new string[] { "6-12 lbs", "Epinephrine (1mg/10ml)", "0.05 mg", "0.5 mL", "Gray" }) },
                    { new Treatment(new string[] { "13-16 lbs", "Epinephrine (1mg/10ml)", "0.1 mg", "1 mL", "Pink" }) },
                    { new Treatment(new string[] { "17-20 lbs", "Epinephrine (1mg/10ml)", "0.1 mg", "1 mL", "Red" }) },
                    { new Treatment(new string[] { "21-25 lbs", "Epinephrine (1mg/10ml)", "0.1 mg", "1 mL", "Purple" }) },
                    { new Treatment(new string[] { "26-31 lbs", "Epinephrine (1mg/10ml)", "0.15 mg", "1.5 mL", "Yellow" }) },
                    { new Treatment(new string[] { "32-40 lbs", "Epinephrine (1mg/10ml)", "0.2 mg", "2 mL", "White" }) },
                    { new Treatment(new string[] { "41-51 lbs", "Epinephrine (1mg/10ml)", "0.2 mg", "2 mL", "Blue" }) },
                    { new Treatment(new string[] { "52-64 lbs", "Epinephrine (1mg/10ml)", "0.3 mg", "3 mL", "Orange" }) },
                    { new Treatment(new string[] { "65-79 lbs", "Epinephrine (1mg/10ml)", "0.3 mg", "3 mL", "Green" }) },
                    { new Treatment(new string[] { "80+ lbs", "Epinephrine (1mg/10ml)", "1 mg", "10 mL", "Black" }) }
                    }
                }
            };
            return trtDictionary;
        }
    }
}