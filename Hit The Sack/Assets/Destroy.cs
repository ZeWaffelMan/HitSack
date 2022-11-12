using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
}