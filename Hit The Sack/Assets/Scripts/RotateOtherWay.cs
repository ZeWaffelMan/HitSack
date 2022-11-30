using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RotateOtherWay : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private bool canSpinFaster = true;

    public bool isStopped = false;


    public GameObject target;
    public GameObject black;
    public GameObject backgroundRotater;
    public GameObject ceiling;

    public GameObject stopButton;
    public GameObject music;
    public GameObject yesButton;

    public GameObject globalVolume2;

    public GameObject _shopManager;
    public GameObject _audioManager;
    public GameObject breakAbleLink;

    AudioManager audioManager;
    ShopManager shopManager;

    public Animator faceAnim;

    Transform _transform;

    RotateOtherWay rotateOtherWay;
    BreakLink breakLink;



    private void Awake()
    {
        shopManager = _shopManager.GetComponent<ShopManager>();
        audioManager = _audioManager.GetComponent<AudioManager>();
        breakLink = breakAbleLink.GetComponent<BreakLink>(); 

        _transform = GetComponent<Transform>();
        rotateOtherWay = GetComponent<RotateOtherWay>();
    }

    private void Update()
    {
        // Spin
        if (shopManager.boughtRotate == true)
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
        music.SetActive(false);
        Destroy(stopButton);
        Destroy(backgroundRotater);
        faceAnim.Play("Sad");

        audioManager.Play("Crash");
        yield return new WaitForSeconds(0.1f);
        globalVolume2.SetActive(true);

        breakLink.isBroken = true;
        Destroy(ceiling);
        yield return new WaitForSeconds(1);
        black.SetActive(false);
        yield return new WaitForSeconds(10);
        yesButton.SetActive(true);
    }
}
