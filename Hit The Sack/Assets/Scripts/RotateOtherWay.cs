using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RotateOtherWay : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private bool canSpinFaster = true;

    public static bool isStopped = false;


    public GameObject target;
    public GameObject black;
    public GameObject backgroundRotater;

    public GameObject smoke;

    public GameObject stopButton;
    public GameObject _audioManager;
    public GameObject music;
    public GameObject yesButton;

    AudioManager audioManager;
    

    public Animator sackAnimator;

    Transform _transform;

    RotateOtherWay rotateOtherWay;

    private void Awake()
    {
        audioManager = _audioManager.GetComponent<AudioManager>();
        _transform = GetComponent<Transform>();
        rotateOtherWay = GetComponent<RotateOtherWay>();
    }

    private void Update()
    {
        // Spin
        if (ShopManager.boughtRotate == true)
        {
            if (canSpinFaster == true && _rotation.z > -1000)
            {
                StartCoroutine(Spin());
            }
            transform.Rotate(_rotation * Time.deltaTime);
        }

        if (_rotation.z <= -1000)
        {
            isStopped = true;
        }

        // Stop Spinning
        if (isStopped == true)
        {
            StartCoroutine(NextPart());
            canSpinFaster = false;
            _rotation.z = 0;
            transform.rotation = target.transform.rotation;
        }
    }

    // Spins the camera
    IEnumerator Spin()
    {
        canSpinFaster = false;
        yield return new WaitForSeconds(0.01f);
        _rotation.z--;
        _rotation.z--;
        canSpinFaster = true;
    }

    IEnumerator NextPart()
    {
        black.SetActive(true);
        music.SetActive(false);
        isStopped = false;

        Destroy(stopButton);
        Destroy(backgroundRotater);
        sackAnimator.Play("SackIdle");

        audioManager.Play("Crash");

        smoke.SetActive(true);
        yield return new WaitForSeconds(1);
        black.SetActive(false);
        yield return new WaitForSeconds(10);
        yesButton.SetActive(true);
    }
}
