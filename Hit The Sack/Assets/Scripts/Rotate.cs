using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    public static bool canSpinFaster = false;

    public static bool isStopped = false;

    public GameObject stopButton;

    public Animator sackAnimator;

    Rotate rotate;
    RotateOtherWay rotateOtherWay;

    private void Awake()
    {
        rotateOtherWay = GetComponent<RotateOtherWay>();
        rotate = GetComponent<Rotate>();
    }

    private void Update()
    {
        // Spin
        if(ShopManager.boughtRotate == true)
        {
            if (canSpinFaster == true && _rotation.z < 150)
            {
                StartCoroutine(Spin());
            }
            transform.Rotate(_rotation * Time.deltaTime);
        }

        if(_rotation.z == 150)
        {
            stopButton.SetActive(true);
        }

        // Stop Spinning
        if(isStopped == true)
        {
            rotateOtherWay.enabled = true;
            rotate.enabled = false;
        }
    }

    // Spins the camera
    IEnumerator Spin()
    {
        canSpinFaster = false;
        yield return new WaitForSeconds(0.1f);
        _rotation.z++;
        canSpinFaster = true;
    }
}
