using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static GameObject mainMenu, canvas, selectedBar;

    public static string symptom;
    public PressableButton seizure, pain, cardiac, hypoglycemia;

    // Progress bar variables
    public PressableButton selectedCondition;
    public TextMeshProUGUI selectedConditionText;


    // Initalize the canvas and buttons
    public void Start()
    {
        canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("Main Menu").gameObject;

        selectedBar = canvas.transform.Find("Selected Bar").gameObject;
        

        // Check that the buttons are assigned; add onClick events
        if (seizure != null)
        {
            seizure.OnClicked.AddListener(() => SymptomButtonClicked(seizure));
            pain.OnClicked.AddListener(() => SymptomButtonClicked(pain));
            cardiac.OnClicked.AddListener(() => SymptomButtonClicked(cardiac));
            hypoglycemia.OnClicked.AddListener(() => SymptomButtonClicked(hypoglycemia));
        }

    }

 
    // A button was clicked, assign it to the symptom variable and go to the next menu
    private void SymptomButtonClicked(PressableButton button)
    {

        symptom = button.name;
        ButtonsClickedTracker.AddButtonClicked(button);

        // A button was clicked, save the selected condition then go to the weight menu
        selectedConditionText.text = symptom;
        selectedCondition.gameObject.SetActive(true);
        SwitchMenus.ChangeMenu(Menu.WEIGHT_MENU, gameObject);
    }

 

    // Return the name of the symptom that was clicked
    public static string getSymptomName()
    {
        return symptom;
    }

    public static void setSymptomName(String symptomToSet)
    {
        symptom = symptomToSet;
    }

}