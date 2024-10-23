using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonsClickedTracker : MonoBehaviour
{
    public static ButtonsClickedTracker instance; 

    // Make a list of "ButtonClickedData" class from the .cs file
    public static List<ButtonClickedData> allBtnsClicked = new List<ButtonClickedData>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
    }

    // Add a clicked button along with its timestamp
    public static void AddButtonClicked(PressableButton button)
    {
        ButtonClickedData clickData = new ButtonClickedData(button, DateTime.Now);
        allBtnsClicked.Add(clickData);
    }

    // Update the button's name
    public static void UpdateButtonClickedName(PressableButton button, string name)
    {
        foreach (ButtonClickedData data in allBtnsClicked)
        {
            if (data.button == button)
            {
                data.btnName = name;
                return; 
            }
        }
    }

    // Clear all buttons clicked.
    public static void ResetBtnsClicked()
    {
        allBtnsClicked.Clear();
    }


    public static List<ButtonClickedData> GetAllButtonsClicked()
    {
        return allBtnsClicked;
    }
}
