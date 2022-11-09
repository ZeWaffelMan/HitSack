using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDistance : MonoBehaviour
{
    [SerializeField] private Transform target;
    public static float distance = 10;

    private void Update()
    {
        distance = (target.transform.position.x - transform.position.x);
    }
}
