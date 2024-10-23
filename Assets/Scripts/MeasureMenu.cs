using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeasureMenu : MonoBehaviour
{
    public static GameObject mainMenu, canvas, selectedBar;

    public static string selectedWeight;
    public static string selectedColor;

    private string inputColor;

    public TextMeshProUGUI scanLengthBarCodeText, scanAgainText;

    private Dictionary<string, Weight> WeightList;

    // Progress bar vars
    public PressableButton selectedWeightBtn;
    public TextMeshProUGUI selectedWeightText;

    Color colorToFlash = new Color(1.0f, 0.5f, 0.0f, 1.0f);
    private Coroutine flashCoroutine;

    public GameObject confirmationBackplate;
    public PressableButton confirmationButton;
    public TextMeshProUGUI colorConfirmationText, confirmText;

    public class Weight
    {
        public string[] Ranges { get; private set; }

        public Weight(string[] ranges)
        {
            Ranges = ranges;
        }
    }

    void Awake()
    {

        inputColor = "";

        WeightList = new Dictionary<string, Weight>();
        WeightList.Add("GREY", new Weight(new string[] { "6-12" }));
        WeightList.Add("PINK", new Weight(new string[] { "13-16" }));
        WeightList.Add("RED", new Weight(new string[] { "17-20" }));
        WeightList.Add("PURPLE", new Weight(new string[] { "21-25" }));
        WeightList.Add("YELLOW", new Weight(new string[] { "26-31" }));
        WeightList.Add("WHITE", new Weight(new string[] { "32-40" }));
        WeightList.Add("BLUE", new Weight(new string[] { "41-51" }));
        WeightList.Add("ORANGE", new Weight(new string[] { "52-64" }));
        WeightList.Add("GREEN", new Weight(new string[] { "65-79" }));
        WeightList.Add("BLACK", new Weight(new string[] { "80+" }));


        StartFlashing(scanLengthBarCodeText, colorToFlash);
    }

    void Update()
    {
        // Accumulate color name input from the user
        foreach (char c in Input.inputString)
        {
            if (c != '\r' && c != '\n') // Ignore carriage returns and new lines
            {
                inputColor += c;
            }
        }

        // Check if the Enter key was pressed, indicating the end of input
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("inputColor: " + inputColor);

            // Check if the input color exists in the WeightList dictionary
            if (WeightList.ContainsKey(inputColor))
            {
                CorrectColorScanned(inputColor);
            }
            else
            {
                InvalidColorScanned();
            }
            inputColor = ""; // Reset the input color for the next scan
        } 
    }

    public void CorrectColorScanned(string color)
    {
        // Store the scanned color
        selectedColor = color;  


        // Use the color of the weight group to change the text color.
        // Replace "gray" with "grey" and "pink" with "magenta" for valid colors
        string colorConversion = selectedColor.Replace("GRAY", "GREY").Replace("PINK", "MAGENTA");
        if (ColorUtility.TryParseHtmlString(colorConversion, out colorToFlash))
        {
            colorConfirmationText.color = colorToFlash; // Set the text color
 
        }


        // Retrieve and store the weight range for the scanned color
        if (WeightList.TryGetValue(color, out Weight weightInfo))
        {
            selectedWeight = weightInfo.Ranges.Length > 0 ? weightInfo.Ranges[0] : "Weight not found";
        }


        // Enable the confirmation button and display the scanned color and weight
        confirmationButton.gameObject.SetActive(true);
        colorConfirmationText.text = selectedColor + "\n" + selectedWeight;

        // Show the confirmation texts
        confirmationBackplate.gameObject.SetActive(true);
        confirmText.gameObject.SetActive(true);
        StartFlashing(confirmText, colorToFlash);

    }

    void InvalidColorScanned()
    {
        scanAgainText.gameObject.SetActive(true);
        StartFlashing(scanAgainText, colorToFlash);
    }


    public void ColorConfimred()
    {
        // Progress bar updates
        selectedWeightText.text = selectedWeight + " lbs." + "\n" + selectedColor;
        selectedWeightBtn.gameObject.SetActive(true);


        // Switch to next menu
        SwitchMenus.ChangeMenu(Menu.MEDICATION_MENU, gameObject);
    }




    // Start flashing text from color <--> white
    public void StartFlashing(TextMeshProUGUI textToFlash, Color colorToFlash)
    {
       
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

}