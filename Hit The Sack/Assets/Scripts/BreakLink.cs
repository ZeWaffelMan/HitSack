using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLink : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Debug.Log("pooooo");
            Destroy(GetComponent<HingeJoint2D>());
        }
    }
}
