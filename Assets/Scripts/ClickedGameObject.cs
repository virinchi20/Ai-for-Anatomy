using MixedReality.Toolkit;
using MixedReality.Toolkit.SpatialManipulation;
using TMPro;
using UnityEngine;

public class ClickedGameObject : MonoBehaviour
{
    public ObjectManipulator manipulator;  // Manipulator of correct game object
    public ObjectManipulator[] manipulators; // Manipulators of incorrect game obejects

    public TextMeshProUGUI answerText;
    public GameObject buttonGroup;

    private void Update()
    {
        // Check if correct game object was clicked
        if (manipulator != null)
        {
            if (manipulator.IsGrabSelected == true)
            {
                CorrectClick();
            }
        }

        // Check if an incorrect gameobject was clicked
        foreach (ObjectManipulator m in manipulators)
        {
            if (m != null)
            {
                if (m.IsGrabSelected == true)
                {
                    IncorrectClick();
                }
            }
        }
    }

    private void CorrectClick()
    {
        // Change answerText to "Correct"
        answerText.text = "<color=green>Correct</color>";
        buttonGroup.SetActive(true);

    }
    private void IncorrectClick()
    {
        // Change answerText to "Incorrect"
        answerText.text = "<color=red>Incorrect</color>";
        buttonGroup.SetActive(false);
    }
}