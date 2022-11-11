using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Animator buttonAnim;

    private void OnMouseDown()
    {
        buttonAnim.Play("ButtonOut");
    }
}
