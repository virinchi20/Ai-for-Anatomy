using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BloodSugarLevelMenu : MonoBehaviour
{
    private Coroutine flashCoroutine;
    public TextMeshProUGUI textToFlash;

    public GameObject redoseBackplate;
    public TextMeshProUGUI redoseButtonText;
    public PressableButton lessThan59Btn, moreThan59Btn, redoseButton;

    // Progress bar
    public PressableButton administerProgress, conditionProgress;
    public TextMeshProUGUI timerText, selectedCondition;



    public int doseCount = 2;
    public string doseText = "";

    private void OnEnable()
    {
        StartFlashing(textToFlash);
    }

    public void StartFlashing(TextMeshProUGUI textToFlash)
    {
        flashCoroutine = StartCoroutine(FlashingConfirmation(textToFlash));
    }

    IEnumerator FlashingConfirmation(TextMeshProUGUI textToFlash)
    {
        Color orangeColor;
        // Parse the hex string for orange 
        ColorUtility.TryParseHtmlString("#FF8004", out orangeColor);

        while (true)
        {
            textToFlash.color = orangeColor;
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
            textToFlash.color = Color.white; // Reset to white or any default color
        }
    }

    // Take the Hypoglycemia route
    public void lessThan59()
    {
        // Add time stamp
        UpdateTimeText();

        // Change the selected condition, go back to medication menu
        selectedCondition.text = "Hypoglycemia";
        MainMenu.setSymptomName("Hypoglycemia");

        // Add btn to the list of all buttons clicked in the program
        ButtonsClickedTracker.AddButtonClicked(lessThan59Btn);

        SwitchMenus.ChangeMenu(Menu.MEDICATION_MENU, gameObject);
    }

    // Normal BP, proceed normally with seizure route
    public void moreThan59()
    {
        // Add time stamp
        UpdateTimeText();

        administerProgress.gameObject.SetActive(true);
        redoseBackplate.SetActive(true);

        // Add btn to the list of all buttons clicked in the program
        ButtonsClickedTracker.AddButtonClicked(moreThan59Btn);
    }


    private void UpdateTimeText()
    {
        string currentTime = DateTime.Now.ToString("HH:mm");
        doseText += "Dose " + doseCount + ": " + currentTime + "\n";
        for (int i = 0; i <= doseCount; i++)
        {
            timerText.text = doseText;
        }

    }

    // redose button clicked, update dose timestamp, go back to medication menu
    public void redoseButtonClicked()
    {
        doseCount += 1;
        redoseBackplate.SetActive(false);
        SwitchMenus.ChangeMenu(Menu.MEDICATION_MENU, gameObject);
    }




}
