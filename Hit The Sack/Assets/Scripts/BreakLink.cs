using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLink : MonoBehaviour
{
    public bool isBroken = false;

    private void Update()
    {
        if (isBroken == true)
        {
            GetComponent<BreakLink>().enabled = false;
            Destroy(gameObject);
        }
    }
}
