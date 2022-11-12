using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Smacking smacking;
    bool isRunning = false;

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
        isRunning = false;
    }
}
