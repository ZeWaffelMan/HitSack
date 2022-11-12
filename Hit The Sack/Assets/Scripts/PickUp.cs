using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static bool Pressed = false;

    private void OnMouseDown()
    {
        Pressed = true;
    }
    private void OnMouseUp()
    {
        Pressed = false;
    }

    private void Update()
    {
        if (Pressed)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
