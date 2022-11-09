using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public bool isAbleToThrow = false;

    private void Update()
    {
        if (Movement.canThrow == true)
        {
            foreach (Transform eachChild in transform)
            {
                if (eachChild)
                {
                    Debug.Log("Child found. Mame: " + eachChild.name);
                    eachChild.transform.SetParent(null);
                }
            }
        }
    }
}
