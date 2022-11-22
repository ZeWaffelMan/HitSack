using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    Smacking smacking;
    public Animator clicksAnimator;

    public GameObject nine;
    public GameObject colorGrading;

    private bool isMax = false;

    private void Awake()
    {
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
    }

    private void Start()
    {
        clicksAnimator.Play("Shake");
    }

    private void Update()
    {
        if (smacking.clicks < 99999)
        {
            smacking.clicks += 50;
            smacking.clicksText.text = smacking.clicks.ToString();
        }

        if (smacking.clicks > 99999)
        {
            isMax = true;
            nine.SetActive(true);
            smacking.clicks = 99999;
            smacking.clicksText.text = smacking.clicks.ToString();
        }

        if (isMax == true)
        {
            StartCoroutine(Flash());
        }
    }
    IEnumerator Flash()
    {
        isMax = false;
        yield return new WaitForSeconds(1);
        colorGrading.SetActive(true);
        yield return new WaitForSeconds(1);
        colorGrading.SetActive(false);
        isMax = true;
    }
}
