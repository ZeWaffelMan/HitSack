using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float force;
    public GameObject target;
    Rigidbody rb;
    bool isDone = false;

    private void Update()
    {
        if (Movement.canThrow == true && isDone == false)
        {
            StartCoroutine(Impact());
        }
    }
    IEnumerator Impact()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position) * force);
        yield return new WaitForSeconds(0.01f);
        isDone = true;
    }
}
