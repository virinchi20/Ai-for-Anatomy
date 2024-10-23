using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdministerMenuUpdated : MonoBehaviour
{

    public static GameObject canvas, confirmationBackplate;
    public TextMeshProUGUI volumeButtonText, syringeButtonText, administerBlinkText, selectedCondition;

    public PressableButton syringeButton, volumeButton;

    public GameObject administerBlink, redose, steps;

    public TextMeshProUGUI redoseButtonText;
    public PressableButton redoseButton;

    public int doseCount = 1;
    public string doseText = "";

    private bool syringeButtonToggled = false;
    private bool volumeButtonToggled = false;


    private Coroutine flashCoroutine;

    // Progress bar variables
    public PressableButton administerProgress;
    public TextMeshProUGUI timerText;


    // Start is called before the first frame update
    public void Start()
    {
        // Subscribe to the button clicked events
        syringeButton.OnClicked.AddListener(OnSyringeButtonPressed);
        volumeButton.OnClicked.AddListener(OnVolumeButtonPressed);
        steps.SetActive(true);

    }

    // Update is called once per frame
    void Awake()
    {
        redoseButton.OnClicked.AddListener(() => redoseButtonClicked(redoseButton));
    }


    void OnEnable()
    {
        // code runs each time the GameObject is enabled (set active).
        ShowAdministerMenu();
    }

    private void UpdateTimeText()
    {
        string currentTime = DateTime.Now.ToString("HH:mm");
        doseText += "Dose " + doseCount + ": " + currentTime + "\n";
        for(int i = 0; i <= doseCount; i++){ 
            timerText.text = doseText;
        }

    }

    private void OnSyringeButtonPressed()
    {
        // Toggle the state of the syringe button
        syringeButtonToggled = !syringeButtonToggled;
        CheckButtonsToggled();

        // Add btn to the list of all buttons clicked in the program
        ButtonsClickedTracker.AddButtonClicked(syringeButton);
    }

    private void OnVolumeButtonPressed()
    {
        // Toggle the state of the volume button
        volumeButtonToggled = !volumeButtonToggled;
        CheckButtonsToggled();

        // Add btn to the list of all buttons clicked in the program
        ButtonsClickedTracker.AddButtonClicked(volumeButton);
    }

    public void CheckButtonsToggled()
    {
        if (syringeButtonToggled && volumeButtonToggled)
        {
            // if seizure route, check BP
            if(selectedCondition.text == "Seizure")
            {
                administerProgress.gameObject.SetActive(true);
                UpdateTimeText();
                SwitchMenus.ChangeMenu(Menu.BLOOD_SUGAR_LEVEL_MENU, gameObject);
            }
            else
            {
                administerProgress.gameObject.SetActive(true);
                steps.SetActive(false);
                redose.SetActive(true);
                administerBlink.SetActive(true);
                StartFlashing(administerBlinkText);
                UpdateTimeText();
            }

            doseCount += 1;
        }

        else
        {
            redose.SetActive(false);
            administerBlink.SetActive(false);
            // Optionally stop flashing the administerBlinkText if needed
            StopFlashing(administerBlinkText);
        }
    }

    public void redoseButtonClicked(PressableButton button)
    {
        redose.SetActive(false);

        // Add btn to the list of all buttons clicked in the program
        ButtonsClickedTracker.AddButtonClicked(button);

        SwitchMenus.ChangeMenu(Menu.MEDICATION_MENU, gameObject);


    }

    public void ShowAdministerMenu()
    {
        // activate the administer menu/page GameObject
        gameObject.SetActive(true);

        // ensure the steps menu is visible
        steps.SetActive(true);

        redose.SetActive(false);
        administerBlink.SetActive(false);

        // reset toggle states to default state
        syringeButtonToggled = false;
        volumeButtonToggled = false;

    }

    // Start flashing text
    public void StartFlashing(TextMeshProUGUI textToFlash)
    {
        // Ensure that we don't start multiple instances of the coroutine
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashingConfirmation(textToFlash));
    }

    IEnumerator FlashingConfirmation(TextMeshProUGUI textToFlash)
    {
        Color orangeColor;
        // Try to parse the hex string (add a '#' prefix to the hex code)
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

            // Optionally reset the color or perform any other cleanup
            textToFlash.color = Color.white; // Reset to white or any default color
        }
    }
}
