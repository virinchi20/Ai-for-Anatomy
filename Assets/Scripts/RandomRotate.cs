using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{

    public GameObject obj;

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
        
    }
}
