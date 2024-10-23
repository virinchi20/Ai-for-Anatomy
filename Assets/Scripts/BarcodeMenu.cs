using BarClass;
using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarcodeMenu : MonoBehaviour
{
    public PressableButton unableToScanBtn;
    public TextMeshProUGUI scanMedText, scanAgainText;
    public string medicineName;
    private string barcode;
    private Dictionary<string, Medication> medDictionary;
    private Coroutine flashCoroutine;


    // Progress bar variables
    public PressableButton selectedDose;
    public TextMeshProUGUI selectedDoseText;

    void Awake()
    {

        // Start by flashing the "SCAN MED" text
        StartFlashing(scanMedText);

        barcode = "";
        medDictionary = MedicineDictionary.GetDictionary();
        medicineName = MedicationMenu.getCorrectMed().Split()[0];
    }


    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c != '\r' && c != '\n')
            {
                barcode += c;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (medDictionary.ContainsKey(barcode) && medDictionary[barcode].name == medicineName)
            {
                CorrectBarcode();
            }
            else
            {
                BadBarcode();
            }
            barcode = "";
        }
    }


    // Bad barcode scanned
    public void BadBarcode()
    {
        scanAgainText.gameObject.SetActive(true);
        StartFlashing(scanAgainText);
    }


    // Correct barcode was scanned, update dosage info and go to the next menu
    public void CorrectBarcode()
    {

        // Update dosage amount on the progress bar
        selectedDose.gameObject.SetActive(true);
        string dosage = MedicationMenu.getCorrectDose();
        selectedDoseText.text = dosage;

        SwitchMenus.ChangeMenu(Menu.ADMINISTER_MENU, gameObject);
    }



    // Start flashing text
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


    // Go to the unable to scan menu
    public void UnableToScan()
    {
        // Add the "unable to scan" button to the global list of buttons that have been clicked
        ButtonsClickedTracker.AddButtonClicked(unableToScanBtn);

        SwitchMenus.ChangeMenu(Menu.UNABLE_TO_SCAN_MENU, gameObject);
    }

}
