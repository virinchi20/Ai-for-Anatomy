using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class AgeMenu : MonoBehaviour
{
    public static GameObject canvas, ageMenu, confirmationBackplate;

    // Progress bar variables
    public TextMeshProUGUI previousMenuProgressBar, currentMenuProgressBar;
    public PressableButton selectedAge;
    public TextMeshProUGUI selectedAgeText;

    public List<PressableButton> ageGroup;
    private Dictionary<PressableButton, string> ageColorGroup = new Dictionary<PressableButton, string>();
    private Dictionary<PressableButton, string> weightGroup = new Dictionary<PressableButton, string>();

    public PressableButton confirmationButton;
    public TextMeshProUGUI ageConfirmationText, instructionsText, confirmText;

    public Color colorForText;
    private Coroutine flashCoroutine;

    public static string selectedWeight, selectedColorGroup;


    // Init canvas, menu, and buttons
    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        ageMenu = canvas.transform.Find("Age Menu").gameObject;

        // Change the color of "weight" to orange on the progress bar
        ProgressBarController.changeProgressColor("Weight");

        // Get the "Confirmation Backplate" child under the weight menu hierarchy
        if (ageMenu != null)
        {
            Transform childTransform = ageMenu.transform.Find("Confirmation Backplate");
            if (childTransform != null)
            {
                confirmationBackplate = childTransform.gameObject;
            }
        }

        // Assign each weight group its appropriate color through a dictionary
        string[] colors = { "GRAY", "PINK", "RED", "PURPLE", "YELLOW", "WHITE", "BLUE", "ORANGE", "GREEN", "BLACK" };
        string[] weights = { "6-12", "13-16", "17-20", "21-25", "26-31", "32-40", "41-51", "52-64", "65-79", "80+" };
        for (int i = 0; i < colors.Length; i++)
        {
            if (i < colors.Length)
            {
                ageColorGroup.Add(ageGroup[i], colors[i]);
                weightGroup.Add(ageGroup[i], weights[i]);
            }



            // Add onHover  and onClick events for each weight group button
            if (ageGroup != null)
            {
                foreach (var age in ageGroup)
                {
                    age.hoverEntered.AddListener(delegate { AgeGroupHovered(age); });
                    age.OnClicked.AddListener(() => AgeGroupClicked(age));

                }
            }
        }

    }

    // A weight group is being HOVERED over. Change the color of the text
    private void AgeGroupHovered(PressableButton button)
    {
        string currentAge = button.name;
        string currentColor = "";
        string currentWeight = "";

        // Hide the confirmation texts
        confirmationBackplate.gameObject.SetActive(false);
        //instructionsText.gameObject.SetActive(false);
        confirmText.gameObject.SetActive(false);

        // Show the hovered weight group
        confirmationButton.gameObject.SetActive(true);
        ageConfirmationText.text = button.name;

        // Disable the confirmation button until a weight group is CLICKED.
        confirmationButton.enabled = false;


        // Retrieve the color group from the dictonary for the selected weight button
        if (ageColorGroup.ContainsKey(button))
        {
            currentColor = ageColorGroup[button];
            currentWeight = weightGroup[button];

            setWeightGroup(currentWeight, currentColor);
        }

        else
        {
            Debug.Log("ERROR: Not found in dictionary");
        }


        // Use the color of the weight group to change the text color.
        // Replace "gray" with "grey" and "pink" with "magenta" for valid colors
        string test = currentColor.Replace("GRAY", "GREY").Replace("PINK", "MAGENTA");
        if (ColorUtility.TryParseHtmlString(test, out colorForText))
        {
            ageConfirmationText.color = colorForText; // Set the text color
        }
        else
        {
            Debug.LogError("Invalid color string: " + currentColor);
        }

    }




    // A weight group was CLICKED
    public void AgeGroupClicked(PressableButton button)
    {
        // Disable hovering of other buttons once something is clicked
        foreach (var age in ageGroup)
        {
            age.enabled = false;
        }

        // Enable the confirmation button
        confirmationButton.enabled = true;

        // Show the confirmation texts
        confirmationBackplate.gameObject.SetActive(true);
        confirmText.gameObject.SetActive(true);
        StartFlashing(confirmText, colorForText);

        // add to the list of all buttons clicked so far
        ButtonsClickedTracker.AddButtonClicked(button);
    }



    // Confirmation button clicked, assign values to the "selected bar" and go to the next menu
    public void CorrectButtonClicked()
    {
        selectedAgeText.text = selectedWeight + " lbs." + "\n" + selectedColorGroup;
        selectedAge.gameObject.SetActive(true);

        // add to the list of all buttons clicked so far
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


    public static string getWeightGroup()
    {
        return selectedWeight;
    }

    private void setWeightGroup(string weightInLb, string colorGroup)
    {

        selectedWeight = weightInLb;
        selectedColorGroup = colorGroup;
    }



    // Re-enable all buttons and get rid of any confirmations
    public void ResetMenuState()
    {

        // Enable eight group buttons
        foreach (var age in ageGroup)
        {
            age.enabled = true;
        }

        // Hide the confirmation texts
        confirmationBackplate.gameObject.SetActive(false);
        confirmText.gameObject.SetActive(false);
        confirmationButton.gameObject.SetActive(false);
        selectedAge.gameObject.SetActive(false);
    }
}