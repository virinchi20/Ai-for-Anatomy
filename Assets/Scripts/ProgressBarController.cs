using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    // List of all the menus in the scene
    public List<GameObject> menus;

    // Progress bar variables
    public List<PressableButton> progressBarButtons;
    public List<TextMeshProUGUI> progressBarTexts;
    private static Dictionary<PressableButton, TextMeshProUGUI> buttonTextMap = new Dictionary<PressableButton, TextMeshProUGUI>();

    // Init function
    private void Awake()
    {
        // Populate a dictionary with the texts in each progress bar button (Foramt--> Progress Button: "Condition")
        // and add onclick events for each button
        if (progressBarButtons != null && progressBarTexts != null && 
            progressBarButtons.Count == progressBarTexts.Count)
        {
            for (int i = 0; i < progressBarButtons.Count; i++)
            {
                PressableButton currentButton = progressBarButtons[i];
                buttonTextMap.Add(currentButton, progressBarTexts[i]);
                currentButton.OnClicked.AddListener(() => progressBarClicked(currentButton));
            }
        }
    }


    // A progress button bar was clicked, change to the appropriate menu.
    private void progressBarClicked(PressableButton button)
    {
        string currentStep = "";
        GameObject currentActiveStep = gameObject;

        // Get the text of the selected button
        if (buttonTextMap.TryGetValue(button, out TextMeshProUGUI buttonText))
        {
            currentStep = buttonText.text;
        }


        // Determine which menu is currently active
        foreach(GameObject obj in menus)
        {
            if (obj.activeSelf)
            {
                currentActiveStep = obj;
            }
        }

        // Switch to the selected menu, close the current active one
        switch (currentStep)
        {
            case "Condition":
                SwitchMenus.ChangeMenu(Menu.MAIN_MENU, currentActiveStep);
                break;

            case "Weight":
                SwitchMenus.ChangeMenu(Menu.WEIGHT_MENU, currentActiveStep);
                break;

            case "Medication":
                SwitchMenus.ChangeMenu(Menu.MEDICATION_MENU, currentActiveStep);
                break;

            case "Dose":
                SwitchMenus.ChangeMenu(Menu.BARCODE_MENU, currentActiveStep);
                break;

            case "Administer":
                SwitchMenus.ChangeMenu(Menu.ADMINISTER_MENU, currentActiveStep);
                break;
        }


        
    }

    // Highlight the color of the current step in the progress bar.
    public static void changeProgressColor(string stepToSwitchTo)
    {
        // Iterate through all progress bar buttons
        foreach (KeyValuePair<PressableButton, TextMeshProUGUI> pair in buttonTextMap)
        {
            // Get the current button and its associated text
            PressableButton button = pair.Key;
            TextMeshProUGUI text = pair.Value;
            
            // Define a Hexcode for the color orange
            Color orange;
            ColorUtility.TryParseHtmlString("#FF8004", out orange);

            // Change the color of the selected step to be orange, everything else white
            //text.color = text.text == stepToSwitchTo ? orange : Color.white;


            // Change the text color of the previous step to white
            if (text.text != stepToSwitchTo)
            {
                text.color = Color.white;
            }

            // Change the current step to be orange 
            else
            {
                Debug.Log(stepToSwitchTo + " SHOULD BE ORANGE");
                text.color = orange;
            }
        }
    }
}
