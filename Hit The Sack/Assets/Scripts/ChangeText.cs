using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public float time = 3;

    bool isDone = false;

    bool canPlay = true;

    public static bool isDead = false;

    public Text talkingText;

    public GameObject handGun;
    public GameObject gun;

    public GameObject _audioManager;
    public GameObject _smackingManager;
    public GameObject ending;

    public GameObject deathEffect;
    public GameObject letters;

    AudioManager audioManager;
    Smacking smacking;

    public Animator gunAnimator;

    IEnumerator coStage1;
    IEnumerator coStage2;

    private void Awake()
    {
        coStage1 = Stage1();
        coStage2 = Stage2();

        smacking = _smackingManager.GetComponent<Smacking>();
        audioManager = _audioManager.GetComponent<AudioManager>();
    }

    private void Start()
    {
        StartCoroutine(coStage1);
    }

    private void Update()
    {
        if (Gun.Pressed == true && smacking.clicks == 1 && isDone == true)
        {
            isDone = false;
            StartCoroutine(coStage2);
        } else if (Gun.Pressed == true && smacking.clicks == 0 && canPlay == true)
        {
            canPlay = false;
            deathEffect.SetActive(true);
            letters.SetActive(true);
            ending.SetActive(true);
            isDead = true;
            Destroy(this.gameObject);
        }
    }

    IEnumerator Stage1()
    {
        yield return new WaitForSeconds(1);
        talkingText.text = "SAY GOODBYE";
        handGun.SetActive(true);
        yield return new WaitForSeconds(1);
        audioManager.Play("Chuck");
        gunAnimator.Play("Shake");
        yield return new WaitForSeconds(0.06f);
        gunAnimator.Play("Idle");
        yield return new WaitForSeconds(2);
        talkingText.text = "huh";
        yield return new WaitForSeconds(2);
        talkingText.text = "brooo";
        yield return new WaitForSeconds(2);
        talkingText.text = "theres no ammo";
        yield return new WaitForSeconds(2);
        talkingText.text = "*sigh*";
        handGun.SetActive(false);
        gun.SetActive(true);
        isDone = true;
        yield return new WaitForSeconds(1);
        talkingText.text = "what ever";
        yield return new WaitForSeconds(2);
        talkingText.text = "...";
    }

    IEnumerator Stage2()
    {
        yield return new WaitForSeconds(1);
        talkingText.text = "wait";
        yield return new WaitForSeconds(0.5f);
        talkingText.text = "what are you doing";
        yield return new WaitForSeconds(2f);
        talkingText.text = "please dont point that at me";
        yield return new WaitForSeconds(5f);
        talkingText.text = "...";
    }
}
