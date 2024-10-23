using MixedReality.Toolkit;
using MixedReality.Toolkit.UX;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// Manager class that holds information on the button that was clicked and its timestamp
// Interacts with "ButtonsClickedTracker.cs"
public class ButtonClickedData : MonoBehaviour
{
    public PressableButton button;
    public String timestamp;
    public String btnName;

    public ButtonClickedData(PressableButton button, DateTime timestamp)
    {
        this.button = button;
        this.timestamp = timestamp.ToString("HH:mm");
        this.btnName = button.name;
    }
}
