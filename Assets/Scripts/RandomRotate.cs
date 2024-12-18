using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomRotate : MonoBehaviour
{

    public GameObject obj, continueButton;
    public TextMeshProUGUI correctText;

    // Start is called before the first frame update
    void OnEnable()
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
        if ((obj.transform.rotation.eulerAngles.x <= 20.0 || obj.transform.rotation.eulerAngles.x >= 340.0)
            && (obj.transform.rotation.eulerAngles.y <= 200.0 && obj.transform.rotation.eulerAngles.y >= 160.0)
            && (obj.transform.rotation.eulerAngles.z <= 20.0 || obj.transform.rotation.eulerAngles.z >= 340.0))
        {
            continueButton.SetActive(true);
            correctText.text = "<size=8>Correct Placement</size>";
            correctText.color = Color.green;
        }
        else
        {
            continueButton.SetActive(false);
            correctText.text = "<size=8>Incorrect Placement</size>";
            correctText.color = Color.red;
        }
    }
}
