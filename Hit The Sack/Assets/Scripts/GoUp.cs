using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
