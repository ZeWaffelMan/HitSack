using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private void Update()
    {
        if(ShopManager.boughtRotate == true)
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }
    }
}
