using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextText : MonoBehaviour
{
    public GameObject nextText;
    public int time = 3;

    private void Start()
    {
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(time);
        nextText.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
