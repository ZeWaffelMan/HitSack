using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;

    public static bool canThrow = false;

    public Animator animator;

    [SerializeField] float speed = 1.5f;
    [SerializeField] float stepWait = .5f;

    private void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Run Towards
        Debug.Log(TheDistance.distance);
        if (TheDistance.distance > 6)
        {
            animator.Play("CrabWalkRight");
            StartCoroutine(MoveRight(stepWait));
        }
        else if (TheDistance.distance < -6)
        {
            animator.Play("CrabWalkLeft");
            StartCoroutine(MoveLeft(stepWait));
        }
        else if (canThrow == false)
        {
            StartCoroutine(Throw());
            animator.Play("IdleCrab");
        }
        else
        {
            animator.Play("IdleCrab");
        }
    }

    IEnumerator MoveRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator Throw()
    {
        yield return new WaitForSeconds(1);
        canThrow = true;
    }
}
