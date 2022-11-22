using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOtherWay : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private bool canSpinFaster = true;

    public static bool isStopped = false;


    public GameObject target;
    public GameObject rotateAudio;
    //public GameObject _audioManager;
    //AudioManager audioManager;
    

    public Animator sackAnimator;

    Transform _transform;

    RotateOtherWay rotateOtherWay;

    private void Awake()
    {
        //audioManager = _audioManager.GetComponent<AudioManager>();
        _transform = GetComponent<Transform>();
        rotateOtherWay = GetComponent<RotateOtherWay>();
    }

    private void Start()
    {
        rotateAudio.SetActive(true);
    }

    private void Update()
    {
        // Spin
        if (ShopManager.boughtRotate == true)
        {
            if (canSpinFaster == true && _rotation.z > -400)
            {
                StartCoroutine(Spin());
            }
            transform.Rotate(_rotation * Time.deltaTime);
        }

        if (_rotation.z <= -400)
        {
            isStopped = true;
        }

        // Stop Spinning
        if (isStopped == true)
        {
            canSpinFaster = false;
            _rotation.z = 0;
            Destroy(rotateAudio);
            transform.rotation = target.transform.rotation;
        }
    }

    // Spins the camera
    IEnumerator Spin()
    {
        canSpinFaster = false;
        yield return new WaitForSeconds(0.01f);
        _rotation.z--;
        canSpinFaster = true;
    }
}
