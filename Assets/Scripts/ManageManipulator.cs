using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageManipulator : MonoBehaviour
{
    public GameObject obj;
    public bool isMoveable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveManipulator()
    {
        if (obj != null)
        {
            BoxCollider col = obj.GetComponent<BoxCollider>();
            ObjectManipulator man = obj.GetComponent<ObjectManipulator>();
            Destroy(col);
            Destroy(man);
        }
        else
        {
            Debug.Log("Game Object was not Given");
        }
    }

    public void AddManipulator()
    {
        if (obj != null)
        {
            BoxCollider newCollider = GetComponent<BoxCollider>();
            newCollider = obj.AddComponent<BoxCollider>();
            ObjectManipulator newManipulator = GetComponent<ObjectManipulator>();
            newManipulator = obj.AddComponent<ObjectManipulator>();

            if (!isMoveable)
            {
                newManipulator.AllowedManipulations = 0;
            }
        }
        else
        {
            Debug.Log("Game Object was not given");
        }
    }
}
