using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Smacking : MonoBehaviour
{
    public float fieldofImpact;
    public float force;

    public GameObject oneFloatingPoints;
    public GameObject twoFloatingPoints;
    public GameObject fourFloatingPoints;

    public GameObject hitEffect;

    public int clicks = 1;
    public Text clicksText;
    AudioManager audioManager;
    public int cursorClicks = 1;

    public LayerMask layerToHit;

    public GameObject Sack;

    public Animator facesAnim;

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
                    if(clicks < 99999)
                    {
                        clicks += cursorClicks;
                    }
                    audioManager.Play("Tap");
                    if(cursorClicks == 1)
                    {
                        Instantiate(oneFloatingPoints, transform.position, Quaternion.identity);
                    }
                    if (cursorClicks == 2)
                    {
                        Instantiate(twoFloatingPoints, transform.position, Quaternion.identity);
                    }
                    if (cursorClicks == 4)
                    {
                        Instantiate(fourFloatingPoints, transform.position, Quaternion.identity);
                    }
                    clicksText.text = clicks.ToString();
                    Impact();
                }
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
