using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;
    Rigidbody2D leftArmRB;
    Rigidbody2D rightArmRB;

    public static bool canThrow = false;

    public Animator animator;

    [SerializeField] float speed = 1.5f;
    [SerializeField] float stepWait = .5f;

    private void Start()
    {
        leftArmRB = leftArm.GetComponent<Rigidbody2D>();
        rightArmRB = rightArm.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Run Towards
        Debug.Log(TheDistance.distance);
        if (TheDistance.distance > 4)
        {
            animator.Play("ClimbRight");
            StartCoroutine(MoveRight(stepWait));
        }
        else if (TheDistance.distance < -4)
        {
            animator.Play("ClimbLeft");
            StartCoroutine(MoveLeft(stepWait));
        }
        else if (canThrow == false)
        {
            StartCoroutine(BlowUp());
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    IEnumerator MoveRight(float seconds)
    {
        leftArmRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightArmRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightArmRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftArmRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator BlowUp()
    {
        yield return new WaitForSeconds(1);
        canThrow = true;
    }
}
