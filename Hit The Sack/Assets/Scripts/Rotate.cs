using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    public bool canSpinFaster = false;

    public bool isStopped = false;

    public GameObject stopButton;

    public GameObject _shopManager;
    public GameObject _audioManager;

    AudioManager audioManager;
    Rotate rotate;
    RotateOtherWay rotateOtherWay;
    ShopManager shopManager;

    public Animator facesAnim;

    private void Awake()
    {
        audioManager = _audioManager.GetComponent<AudioManager>();
        shopManager = _shopManager.GetComponent<ShopManager>();
        rotateOtherWay = GetComponent<RotateOtherWay>();
        rotate = GetComponent<Rotate>();
    }

    private void Update()
    {
        // Spin
        if(shopManager.boughtRotate == true)
        {
            if(_rotation.z == 1)
            {
                //audioManager.Play("Turnning");
            }
            if (canSpinFaster == true && _rotation.z < 200)
            {
                StartCoroutine(Spin());
            }
            transform.Rotate(_rotation * Time.deltaTime);
        }

        if(_rotation.z == 200)
        {
            stopButton.SetActive(true);
        }

        if(_rotation.z > 100)
        {
            facesAnim.Play("Dizzy");
        }
        if (_rotation.z > 20 && _rotation.z < 100)
        {
            facesAnim.Play("Neutral");
        }
        // Stop Spinning
        if (isStopped == true)
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
