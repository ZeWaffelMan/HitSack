using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMan : MonoBehaviour
{
    public float force;
    public GameObject target;
    Rigidbody rb;
    bool isDone = false;
    public static bool unlink = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sack")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void Start()
    {
        if(isDone == false)
        {
            StartCoroutine(Impact());
        }
    }
    IEnumerator Impact()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position) * force);
        yield return new WaitForSeconds(0.01f);
        isDone = true;
    }
}
