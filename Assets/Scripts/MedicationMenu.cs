using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using MixedReality.Toolkit.UX;
using MedClass;
using System;
using MixedReality.Toolkit;
using System.Runtime.CompilerServices;

public class MedicationMenu : MonoBehaviour
{
    public string symptom;
    public string weight;
    private readonly Dictionary<string, List<Treatment>> trtDictionary = TreatmentDictionary.GetDictionary();
    private List<Treatment> availableTreatments = new();

    public List<PressableButton> BtnGroup;
    public List<TextMeshProUGUI> BtnText;
    private Dictionary<PressableButton, TextMeshProUGUI> buttonTextMap = new();


    // Progress bar variables
    public PressableButton selectedMed;
    public TextMeshProUGUI selectedMedText;

    public static string correctMed, correctDose, correctVolume;


    void OnEnable()
    {
        ResetMenu();
        Init();
    }


    // Init function
    public void Init()
    {

        symptom = MainMenu.getSymptomName();
        weight = WeightMenu.getWeightGroup() + " lbs";

        GetTreatments();


        // Add onClick events to each medication option button. 
        // buttons are defiend as "Btn 1, 2, 3..." and medication names are assigned dynamically to ea button.
        // We need a way to map the name to the buttons
        if (BtnGroup != null && BtnText != null && BtnGroup.Count == BtnText.Count)
        {
            // Populate a dictionary with the name of the medication (Foramt: Btn #: medication name)
            for (int i = 0; i < BtnGroup.Count; i++)
            {
                PressableButton currentButton = BtnGroup[i]; // Create a local variable inside the loop

                buttonTextMap.Add(currentButton, BtnText[i]);
                currentButton.OnClicked.AddListener(() => BtnGroupClicked(currentButton));
            }
        }
    }

    public void ResetMenu()
    {
        // Empty the dictionary and lists that hold the correct information
        buttonTextMap = new Dictionary<PressableButton, TextMeshProUGUI>();
        availableTreatments.Clear();

        // Remove onclick events for the buttons
        for (int i = 0; i < BtnGroup.Count; i++)
        {
            PressableButton currentButton = BtnGroup[i]; // Create a local variable inside the loop
            currentButton.OnClicked.RemoveAllListeners();
            currentButton.gameObject.SetActive(false);
        }

    }


    // A medication was clicked, set the name of the option and go to the next menu.
    private void BtnGroupClicked(PressableButton button)
    {
      
        if (buttonTextMap.TryGetValue(button, out TextMeshProUGUI buttonText))
        {
            selectedMed.gameObject.SetActive(true);
            string currentMed = buttonText.text;
            selectedMedText.text = currentMed;

            int medIndex = new();

            // index is the btn # that was selected.
            foreach (Treatment trt in availableTreatments)
            {
                if (trt.name == currentMed)
                {
                    medIndex = availableTreatments.IndexOf(trt);
                
                    break;
                }
            }

            // Add the button that was clicked to the global list of buttons that have been clicked
            ButtonsClickedTracker.AddButtonClicked(button);
            ButtonsClickedTracker.UpdateButtonClickedName(button, currentMed);


            setCorrectMed(currentMed, medIndex);
            GoToBarcodeMenu();
        }  

    }


    // Read in the CSV file and add to medicineFromCSV list
    private void GetTreatments()
    {
        foreach (Treatment trt in trtDictionary[symptom]) {
            if (trt.weight.ToString() == weight.ToString())
            {
                availableTreatments.Add(trt);
            }
        }
        updateMedicationMenu();
    }


    // Update the list of appropriate medication options
    public void updateMedicationMenu() {
        int numMeds = availableTreatments.Count;
        for (int i = 0; i < numMeds; i++)
        {
            BtnGroup[i].gameObject.SetActive(true);
            BtnText[i].text = availableTreatments[i].name;

        }
    }




    // Set the correct medication, dose, and volume
    private void setCorrectMed(string selectedMedication, int selectedIndex)
    {
        correctMed = selectedMedication;
        setCorrectDose(selectedIndex);
        setCorrectVol(selectedIndex);

    }
    private void setCorrectDose(int index)
    {
        correctDose = availableTreatments[index].dose;
    }

    private void setCorrectVol(int index)
    {
        correctVolume = availableTreatments[index].volume;
    }


    // Getters for the correct medication info.
    public static string getCorrectMed()
    {
        return correctMed;
    }

    public static string getCorrectDose()
    {
        return correctDose;
    }

    public static string getCorrectVol()
    {
        return correctVolume;
    }




    // Go to the next menu
    public void GoToBarcodeMenu()
    {
        
        SwitchMenus.ChangeMenu(Menu.BARCODE_MENU, gameObject);
    }

   
}





