using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomRotate : MonoBehaviour
{

    public GameObject obj, continueButton, buttonGroup;
    public TextMeshProUGUI correctText;

    // Start is called before the first frame update
    void Start()
    {
        // Get random integers 0-360 for xyz cordinates
        var rand = new System.Random();
        int x = rand.Next(0, 360);
        int y = rand.Next(0, 360);
        int z = rand.Next(0, 360);

        // Set random xyz integers to obj rotation
        obj.transform.Rotate(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(obj.transform.rotation.eulerAngles);
        // If heart is close to natural position (+= 10 degrees), activate correct button
        // Else deactivate correct button
        if ((obj.transform.rotation.eulerAngles.x % 360.0 <= 10.0 || obj.transform.rotation.eulerAngles.x % 360.0 >= 350.0)
            && (obj.transform.rotation.eulerAngles.y % 180.0 <= 10.0 || obj.transform.rotation.eulerAngles.y % 180.0 >= 170.0)
            && (obj.transform.rotation.eulerAngles.z % 360.0 <= 10.0 || obj.transform.rotation.eulerAngles.z % 360.0 >= 350.0))
        {
            buttonGroup.SetActive(true);
            continueButton.SetActive(true);
            correctText.text = "<size=8>Correct Placement</size>";
            correctText.color = Color.green;
        }
        else
        {
            buttonGroup.SetActive(false);
            continueButton.SetActive(false);
            correctText.text = "<size=8>Incorrect Placement</size>";
            correctText.color = Color.red;
        }
    }
}
