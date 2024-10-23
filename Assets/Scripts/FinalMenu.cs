using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using TMPro;

public class FinalMenu : MonoBehaviour
{
    public TextMeshProUGUI btnsClickedText, timeStampText;
    private string listOfBtnsClicked = "";
    private string timeStamps = "";

    public GameObject progressBar, selectedBar;

    public List<ButtonClickedData> allBtnsClicked;

    // For all buttons that were clicked throughout the entire program,
    // Print the name and its timestamp
    void Awake()
    {
        progressBar.SetActive(false);
        selectedBar.SetActive(false);

        allBtnsClicked = ButtonsClickedTracker.GetAllButtonsClicked();

        for (int i = 0; i < allBtnsClicked.Count; i++)
        {
            listOfBtnsClicked += allBtnsClicked[i].btnName + " Button" + "\n\n";
            timeStamps += "\t\t Clicked at: " + allBtnsClicked[i].timestamp + "\n\n";
        }

        // Set the text and center-align it
        btnsClickedText.text = listOfBtnsClicked;
        btnsClickedText.alignment = TextAlignmentOptions.Left;

        timeStampText.text = timeStamps;
        timeStampText.alignment = TextAlignmentOptions.Right;
    }

}
