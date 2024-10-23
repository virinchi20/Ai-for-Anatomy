using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using MixedReality.Toolkit.UX;
using System;
using MixedReality.Toolkit;
using UnityEditor;

public class EndCaseScript : MonoBehaviour
{
    public PressableButton endCaseButton, yesButton, noButton;
    public TextMeshProUGUI endCaseText;

    // List of all the menus in the scene
    public List<GameObject> menus;


    void Awake()
    {
        // Start is called before the first frame update
        endCaseButton.OnClicked.AddListener(endCaseClicked);
        yesButton.OnClicked.AddListener(yesButtonClicked);
        noButton.OnClicked.AddListener(noButtonClicked);
    }



    // End case button clicked, show the yes or no options for confirmation
    private void endCaseClicked()
    {
        endCaseText.text = "End Case?";
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }


    // yes clicked, go to final end menu
    private void yesButtonClicked()
    {
        GameObject currentActiveStep = gameObject;

        // Determine which menu is currently active
        foreach (GameObject obj in menus)
        {
            if (obj.activeSelf)
            {
                currentActiveStep = obj;
            }
        }

        // Change to final menu, close the current active one
        SwitchMenus.ChangeMenu(Menu.FINAL_MENU, currentActiveStep);
    }


    // no clicked, collapse the "yes" and "no" option buttons
    private void noButtonClicked()
    {
        endCaseText.text = "End Case";
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }


}
