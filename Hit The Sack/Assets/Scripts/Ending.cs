using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject ending;
    public GameObject newFlash;

    public Animator flashAnimator;

    private void Start()
    {
        StartCoroutine(Credits());
    }

    IEnumerator Credits()
    {
        ending.SetActive(true);
        yield return new WaitForSeconds(5);
        flashAnimator.Play("FlashFadeOut");
        yield return new WaitForSeconds(4);
        Destroy(newFlash);
    }
}
