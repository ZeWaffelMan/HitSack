using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    private void Update()
    {
        if (Movement.canThrow == true)
        {
            foreach (Transform child in transform)
            {
                if (child)
                {
                    child.transform.SetParent(null);
                    child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }
}
