using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;

    public static bool hitWall = false;

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
        if (hitWall == true)
        {
            animator.Play("Walk Right");
            StartCoroutine(MoveRight(stepWait));
        }
        else if (hitWall == false)
        {
            animator.Play("Walk Left");
            StartCoroutine(MoveLeft(stepWait));
        }
        else
        {
            animator.Play("Idle");
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
}
