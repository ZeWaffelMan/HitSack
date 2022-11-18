using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(BlowUp());
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    IEnumerator BlowUp()
    {
        yield return new WaitForSeconds(5);
    }
}
