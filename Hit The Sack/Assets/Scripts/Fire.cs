using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Smacking smacking;
    bool isRunning = false;
    public GameObject pointsPopup;
    public GameObject pointsPos;

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
        smacking.clicks += 5;
        smacking.clicksText.text = smacking.clicks.ToString();
        Instantiate(pointsPopup, pointsPos.transform.position, Quaternion.identity);
        isRunning = false;
    }
}
