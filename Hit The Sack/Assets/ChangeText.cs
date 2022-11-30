using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public float time = 3;

    bool isDone = false;
    bool hasShot = false;

    bool canPlay = true;

    public static bool isDead = false;

    public Text talkingText;

    public GameObject handGun;
    public GameObject gun;

    public GameObject _audioManager;
    public GameObject _smackingManager;

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
        if (Gun.Pressed == true && smacking.clicks == 6 && isDone == true)
        {
            isDone = false;
            StartCoroutine(coStage2);
        } else if (Gun.Pressed == true && smacking.clicks == 5 && canPlay == true)
        {
            canPlay = false;
            StopCoroutine(coStage2);
            deathEffect.SetActive(true);
            letters.SetActive(true);
            isDead = true;
            Destroy(this.gameObject);
        }
    }

    IEnumerator Stage1()
    {
        yield return new WaitForSeconds(1);
        talkingText.text = "SAY GOODBYE";
        handGun.SetActive(true);
        audioManager.Play("Bop");
        yield return new WaitForSeconds(1);
        audioManager.Play("Chuck");
        gunAnimator.Play("Shake");
        yield return new WaitForSeconds(0.06f);
        gunAnimator.Play("Idle");
        yield return new WaitForSeconds(2);
        talkingText.text = "huh?";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(2);
        talkingText.text = "poop";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(2);
        talkingText.text = "*sigh*";
        audioManager.Play("Bop");
        handGun.SetActive(false);
        gun.SetActive(true);
        isDone = true;
        yield return new WaitForSeconds(1);
        talkingText.text = "what's the point";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(2);
        talkingText.text = "...";
        audioManager.Play("Bop");
    }

    IEnumerator Stage2()
    {
        yield return new WaitForSeconds(1);
        talkingText.text = "wait";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(0.5f);
        talkingText.text = "what are you doing with that?";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(3f);
        talkingText.text = "it doesn't have any ammo lol";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(2f);
        talkingText.text = "ummmm";
        audioManager.Play("Bop");
        yield return new WaitForSeconds(5f);
        talkingText.text = "...";
        audioManager.Play("Bop");
    }
}
