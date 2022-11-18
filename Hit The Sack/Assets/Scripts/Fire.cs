using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Smacking smacking;
    public static int fireAmount = 5;
    bool isRunning = false;

    public GameObject pointsPos;

    public GameObject floatingPoints;
    public GameObject upgradeFloatingPoints;


    private void Awake()
    {
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
    }
    private void Update()
    {
        if(isRunning == false)
        {
            StartCoroutine(Clicks());
        }
    }

    IEnumerator Clicks()
    {
        isRunning = true;
        yield return new WaitForSeconds(1);
        smacking.clicks += fireAmount;
        smacking.clicksText.text = smacking.clicks.ToString();
        if(fireAmount == 5)
        {
            Instantiate(floatingPoints, pointsPos.transform.position, Quaternion.identity);
        }else if (fireAmount == 10)
        {
            Instantiate(upgradeFloatingPoints, pointsPos.transform.position, Quaternion.identity);
        }
        isRunning = false;
    }
}
