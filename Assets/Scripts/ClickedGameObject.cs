using JetBrains.Annotations;
using MixedReality.Toolkit;
using MixedReality.Toolkit.SpatialManipulation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClickedGameObject : MonoBehaviour
{
    // public ObjectManipulator manipulator;  // Manipulator of correct game object
    // public ObjectManipulator[] manipulators; // Manipulators of incorrect game obejects

    public GameObject obj;
    public GameObject[] objs;

    public MeshRenderer meshRenderer;
    public MeshRenderer[] meshRenderers;

    public Material selectedMaterial;
    public Material initialMaterial;

    public TextMeshProUGUI answerText;
    public GameObject button;

    private void OnEnable()
    {
        // Set answerText to starting text
        answerText.text = "<color=orange><size=9>Select With Finger</size></color>";

        SetListener();
    }

    private void CorrectClick()
    {
        // Change answerText to "Correct"
        answerText.text = "<color=green>Correct</color>";
        button.SetActive(true);

        // Highlight the selected obj
        meshRenderer.material = selectedMaterial;
        foreach (MeshRenderer mr in  meshRenderers)
        {
            mr.material = initialMaterial;
        }
    }
    private void IncorrectClick(ObjectManipulator man)
    {
        // Change answerText to "Incorrect"
        answerText.text = "<color=red>Incorrect</color>";
        button.SetActive(false);

        // Highlight the selected obj
        GameObject selectedobj = man.gameObject;
        foreach (MeshRenderer mr in meshRenderers)
        {
            if (mr.gameObject == selectedobj)
            {
                mr.material = selectedMaterial;
            }
            else
            {
                mr.material = initialMaterial;
            }
        }
        meshRenderer.material = initialMaterial;
    }

    // Gets ObjectManipulator components for given objects,
    // adding event listeners to OnClicked functions
    public void SetListener()
    {
        ObjectManipulator manipulator = obj.GetComponent<ObjectManipulator>();

        ObjectManipulator[] manipulators = new ObjectManipulator[objs.Length];

        int num = 0;
        foreach (GameObject o in objs)
        {
            ObjectManipulator m = o.GetComponent<ObjectManipulator>();
            manipulators[num] = m;
            num++;
        }

        if (manipulator.OnClicked.GetPersistentEventCount().Equals(0))
        {
            manipulator.OnClicked.AddListener(CorrectClick);

        }

        foreach (ObjectManipulator m in manipulators)
        {
            if (manipulator.OnClicked.GetPersistentEventCount().Equals(0))
            {
                m.OnClicked.AddListener(() => IncorrectClick(m));
            }
        }
    }
}