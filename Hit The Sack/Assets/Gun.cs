using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Gun : MonoBehaviour
{
    public static bool Pressed = false;
    private bool canShoot = false;

    public float reloadTime = 1;
    public int ammo = 1;

    public float rotateSpeed =  20;

    public Transform target;

    public GameObject snapAudio;

    public Animator gunAnimator;

    AudioManager audioManager;
    Smacking smacking;

    public float fieldofImpact;
    public float force;
    public static bool hit = false;

    public LayerMask layerToHit;

    private void Awake()
    {
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnMouseDown()
    {
        //audioManager.Play("Pick");
        Pressed = true;
    }

    private void Update()
    {
        if(Pressed == true)
        {
            snapAudio.SetActive(true);
            StartCoroutine(CanShoot());
        }

        if (Pressed && canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                if(smacking.clicks > 0)
                {
                    if (ammo > 0)
                    {
                        StartCoroutine(WaitImpact());
                        smacking.clicks--;
                        smacking.clicksText.text = smacking.clicks.ToString();
                        ammo--;
                        StartCoroutine(Reload());
                        Shoot();
                    }
                }
            }
        }

        if (Pressed)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;

            if(ChangeText.isDead == false)
            {
                Vector2 direction = target.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            }
            else
            {
                gunAnimator.Play("GunFade");
                DestroyGun();
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Shot");
        CameraShaker.Instance.ShakeOnce(1f, 4f, .1f, 1f);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        ammo = 1;
    }

    IEnumerator DestroyGun()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }

    IEnumerator WaitImpact()
    {
        yield return new WaitForSeconds(0.01f);
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            //CameraShaker.Instance.ShakeOnce(.2f, .4f, .1f, .5f);
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
}
