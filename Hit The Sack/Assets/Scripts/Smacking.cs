using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Smacking : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public static bool hit = false;

    public GameObject hitEffect;

    public int clicks = 1;
    public Text clicksText;
    AudioManager audioManager;
    public int cursorClicks = 1;

    private bool isRunning = false;

    public LayerMask layerToHit;

    public GameObject Sack;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Impact()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            //CameraShaker.Instance.ShakeOnce(.2f, .4f, .1f, .5f);
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = mousePos;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject == Sack)
                {
                    clicks += cursorClicks;
                    clicksText.text = clicks.ToString();
                    Debug.Log("Slap");
                    Impact();
                    if(isRunning == false)
                    {
                        //StartCoroutine(Switch());
                    }
                }
            }
        }
    }
    /*
    IEnumerator Switch()
    {
        hit = true;
        isRunning = true;
        yield return new WaitForSeconds(0.3f);
        isRunning = false;
        hit = false;
    }
    */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
