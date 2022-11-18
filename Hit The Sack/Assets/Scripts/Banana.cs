using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 lastVelocity;
    public GameObject floatingPoints;

    Smacking smacking;
    bool isRunning = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;

        if (isRunning == false)
        {
            StartCoroutine(Clicks());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    IEnumerator Clicks()
    {
        isRunning = true;
        yield return new WaitForSeconds(5);
        smacking.clicks += 109;
        smacking.clicksText.text = smacking.clicks.ToString();
        Instantiate(floatingPoints, transform.position, Quaternion.identity);
        isRunning = false;
    }
}
