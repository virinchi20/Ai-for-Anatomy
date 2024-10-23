using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightMenu : MonoBehaviour
{
    public static GameObject canvas, weightMenu, confirmationBackplate;

    // Progress bar variables
    public PressableButton selectedWeight;
    public TextMeshProUGUI selectedWeightText;

    public List<PressableButton> weightGroup;
    private Dictionary<PressableButton, string> weightColorGroup = new Dictionary<PressableButton, string>();
    public PressableButton measurePatient, selectAge;


    public PressableButton confirmationButton;
    public TextMeshProUGUI weightConfirmationText, instructionsText, confirmText;

    public Color colorForText;
    private Coroutine flashCoroutine;

    public static string selectedWeightLb, selectedColorGroup;


    // Init canvas, menu, and buttons
    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        weightMenu = canvas.transform.Find("Weight Menu").gameObject;

        // Get the "Confirmation Backplate" child under the weight menu hierarchy
        if (weightMenu != null)
        {
            Transform childTransform = weightMenu.transform.Find("Confirmation Backplate");
            if (childTransform != null)
            {
                confirmationBackplate = childTransform.gameObject;
            }
        }

        // Add onHover  and onClick events for each weight group button
        if (weightGroup != null)
        {
            foreach (var lb in weightGroup)
            {
                lb.hoverEntered.AddListener(delegate { WeightGroupHovered(lb); });
                lb.OnClicked.AddListener(() => WeightGroupClicked(lb));

            }
        }

        // onClick for measure patient or select age options
        measurePatient.OnClicked.AddListener(() => MeasurePatientClicked(measurePatient));
        selectAge.OnClicked.AddListener(() => SelectAgeClicked(selectAge));

        // Assign each weight group its appropriate color through a dictionary
        string[] colors = { "GRAY", "PINK", "RED", "PURPLE", "YELLOW", "WHITE", "BLUE", "ORANGE", "GREEN", "BLACK" };
        for (int i = 0; i < weightGroup.Count; i++)
        {
            if (i < colors.Length)
            {
                weightColorGroup.Add(weightGroup[i], colors[i]);
            }
        }

    }

    // A weight group is being HOVERED over. Change the color of the text
    private void WeightGroupHovered(PressableButton button)
    {
        string currentWeight = button.name;
        string currentColor = "";

        // Hide the confirmation texts
        confirmationBackplate.gameObject.SetActive(false);
        confirmText.gameObject.SetActive(false);

        // Show the hovered weight group
        confirmationButton.gameObject.SetActive(true);
        weightConfirmationText.text = button.name + " lbs.";

        // Disable the confirmation button until a weight group is CLICKED.
        confirmationButton.enabled = false;


        // Retrieve the color group from the dictonary for the selected weight button
        if (weightColorGroup.ContainsKey(button))
        {
            currentColor = weightColorGroup[button];
            setWeightGroup(currentWeight, currentColor);
        }

        else
        {
            Debug.Log("ERROR: Not found in dictionary");
        }


        // Use the color of the weight group to change the text color.
        // Replace "gray" with "grey" and "pink" with "magenta" for valid colors
        string colorConversion = currentColor.Replace("GRAY", "GREY").Replace("PINK", "MAGENTA");
        if (ColorUtility.TryParseHtmlString(colorConversion, out colorForText))
        {
            weightConfirmationText.color = colorForText; // Set the text color
        }
        else
        {
            Debug.LogError("Invalid color string: " + currentColor);
        }

    }




    // A weight group was CLICKED
    public void WeightGroupClicked(PressableButton button)
    {
        // Enable the confirmation button
        confirmationButton.enabled = true;

        // Disable buttons once one is selected
        foreach (var lb in weightGroup)
        {
            lb.enabled = false;
        }

        // Show the confirmation texts
        confirmationBackplate.gameObject.SetActive(true);
        confirmText.gameObject.SetActive(true);
        StartFlashing(confirmText, colorForText);

        // Add this button to the list of all buttons clicked so far
        ButtonsClickedTracker.AddButtonClicked(button);

        string updateBtnName = button.name + " Weight Group";
        ButtonsClickedTracker.UpdateButtonClickedName(button, updateBtnName);
    }



    // Confirmation button clicked, assign values to the "selected bar" and go to the next menu
    public void CorrectButtonClicked()
    {
        selectedWeightText.text = selectedWeightLb + " lbs." + "\n" + selectedColorGroup;
        selectedWeight.gameObject.SetActive(true);

        // Add this button to the list of all buttons clicked so far
        ButtonsClickedTracker.AddButtonClicked(confirmationButton);

        SwitchMenus.ChangeMenu(Menu.MEDICATION_MENU, gameObject);
    }



    // Start flashing text from color <--> white
    public void StartFlashing(TextMeshProUGUI textToFlash, Color colorToFlash)
    {
        // Ensure that we don't start multiple instances of the coroutine
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        // If the color is white, flashing will show nothing. Flash a beige color instead
        if (colorToFlash == Color.white)
        {
            Color beige = new Color(1f, 1f, 186f / 255f);
            colorToFlash = beige;
        }

        flashCoroutine = StartCoroutine(FlashingConfirmation(textToFlash, colorToFlash));
    }

    // Flash each color for 0.5 seconds
    IEnumerator FlashingConfirmation(TextMeshProUGUI textToFlash, Color colorToFlash)
    {
        while (true)
        {
            textToFlash.color = colorToFlash;
            yield return new WaitForSeconds(0.5f);
            textToFlash.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }


    public void StopFlashing(TextMeshProUGUI textToFlash)
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            flashCoroutine = null; // Clear the reference

            // Reset the color to white
            textToFlash.color = UnityEngine.Color.white;
        }
    }

    void MeasurePatientClicked(PressableButton button)
    {
        // Add this button to the list of all buttons clicked so far
        ButtonsClickedTracker.AddButtonClicked(button);
        SwitchMenus.ChangeMenu(Menu.MEASURE_MENU, gameObject);
    }


    void SelectAgeClicked(PressableButton button)
    {
        // Add this button to the list of all buttons clicked so far
        ButtonsClickedTracker.AddButtonClicked(button);
        SwitchMenus.ChangeMenu(Menu.AGE_MENU, gameObject);
    }


    public static string getWeightGroup()
    {
        return selectedWeightLb;
    }

    private void setWeightGroup(string weightInLb, string colorGroup)
    {

        selectedWeightLb = weightInLb;
        selectedColorGroup = colorGroup;
    }



    // Re-enable all buttons and get rid of any confirmations
    public void ResetMenuState()
    {

        // Enable eight group buttons
        foreach (var lb in weightGroup)
        {
            lb.enabled = true;
        }

        // Hide the confirmation texts
        if(confirmationBackplate != null)
        {
            confirmationBackplate.gameObject.SetActive(false);
        }

        if(confirmText != null)
        {
            confirmText.gameObject.SetActive(false);
        }
        
        if(confirmationButton != null)
        {
            confirmationButton.gameObject.SetActive(false);
        }

        if(selectedWeight != null)
        {
            selectedWeight.gameObject.SetActive(false);
        }
    }
}