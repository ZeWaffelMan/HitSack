using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sack : MonoBehaviour
{
    bool isChild = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            collision.gameObject.transform.SetParent(this.transform);
            isChild = true;
        }
        else
        {
            isChild = false;
        }
    }
}
