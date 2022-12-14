using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[10, 10];

    //Stuff
    public GameObject fire;
    public GameObject banana;
    public GameObject chain;
    public GameObject backgroundRotater;
    public GameObject objects;
    public GameObject allGone;
    public GameObject machineGun;
    public GameObject flash;
    public GameObject newFlash;
    public GameObject chainBase;
    public GameObject sack;
    public GameObject deadSack;
    public GameObject newWalls;
    public GameObject music;
    public GameObject square;
    public GameObject top;

    //Text
    public GameObject bruhText;
    public GameObject nextText;

    //Effects
    public GameObject explosion;
    public GameObject spinParticleEffect;
    public GameObject globalVolume2;

    //Buttons
    public GameObject fireButton;
    public GameObject cursorButton;
    public GameObject bananaButton;
    public GameObject glassesButton;
    public GameObject magicButton;
    public GameObject rotateButton;

    //Animators
    public Animator sackAnimator;
    public Animator facesAnimator;
    public Animator cameraAnimator;
    public Animator clicksAnimator;


    private bool boughtFire = false;
    private bool boughtBanana = false;
    public bool boughtRotate = false;

    public GameObject _rotate;

    Smacking smacking;
    AudioManager audioManager;
    Rotate rotate;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
        rotate = _rotate.GetComponent<Rotate>();
    }

    private void Start()
    {
        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;
        shopItems[1, 8] = 8;
        shopItems[1, 9] = 9;



        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 250;
        shopItems[2, 3] = 502;
        shopItems[2, 4] = 1000;
        shopItems[2, 5] = 1700;
        shopItems[2, 6] = 0;
        shopItems[2, 7] = 0;
        shopItems[2, 8] = 0;
        shopItems[2, 9] = 0;


    }

    private void Update()
    {
        if (boughtFire == true && boughtBanana == true)
        {
            glassesButton.SetActive(true);
        }
    }

    public void Clicked()
    {
        smacking.clicksText.text = smacking.clicks.ToString();
        audioManager.Play("Slap");
        CameraShaker.Instance.ShakeOnce(2f, 4f, .1f, 1f);
    }

    // Cursor
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();

            ButtonRef.SetActive(false);
            smacking.cursorClicks = 2;

            fireButton.SetActive(true);
            bananaButton.SetActive(true);
        }
    }

    // Fire
    public void Buy2()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();

            ButtonRef.SetActive(false);
            fire.SetActive(true);

            boughtFire = true;
        }
    }

    // Banana
    public void Buy3()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();
            audioManager.Play("Banana");

            ButtonRef.SetActive(false);
            banana.SetActive(true);

            boughtBanana = true;
        }
    }

    // More
    public void Buy4()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();

            boughtBanana = false;
            boughtFire = false;

            ButtonRef.SetActive(false);

            magicButton.SetActive(true);

            smacking.cursorClicks += smacking.cursorClicks;
            Fire.fireAmount += Fire.fireAmount;
            Banana.bananaAmount += Banana.bananaAmount;
        }
    }

    // Magic
    public void Buy5()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();
            audioManager.Play("Woop");
            StartCoroutine(Magic());

            ButtonRef.SetActive(false);
        }
    }

    IEnumerator Magic()
    {
        cameraAnimator.Play("Gone");
        yield return new WaitForSeconds(1);
        objects.SetActive(false);
        yield return new WaitForSeconds(1);
        Instantiate(allGone);
        facesAnimator.Play("Happy");
        yield return new WaitForSeconds(8);
        rotateButton.SetActive(true);
    }

    // Rotate
    public void Buy6()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();

            ButtonRef.SetActive(false);

            backgroundRotater.SetActive(true);
            boughtRotate = true;
            rotate.canSpinFaster = true;

            spinParticleEffect.SetActive(true);
        }
    }

    // Stop Spinning
    public void Buy7()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();

            ButtonRef.SetActive(false);

            rotate.canSpinFaster = false;
            rotate.isStopped = true;
            spinParticleEffect.SetActive(false);
            bruhText.SetActive(true);
        }
    }

    // MachineGun
    public void Buy8()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            Clicked();

            ButtonRef.SetActive(false);

            machineGun.SetActive(true);
        }
    }

    // Explosion
    public void Buy9()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            CameraShaker.Instance.ShakeOnce(4f, 5f, .1f, 5f);
            audioManager.Play("Explosion");

            ButtonRef.SetActive(false);

            StartCoroutine(Explosion());
        }
    }
    IEnumerator Explosion()
    {
        Instantiate(explosion);
        yield return new WaitForSeconds(0.2f);
        sack.SetActive(false);
        chainBase.SetActive(false);
        flash.SetActive(true);
        newWalls.SetActive(true);
        audioManager.Play("EarBleeding2");
        globalVolume2.SetActive(false);
        yield return new WaitForSeconds(4f);
        Destroy(machineGun);
        smacking.clicks = 1;
        smacking.clicksText.text = smacking.clicks.ToString();
        nextText.SetActive(true);
        flash.SetActive(false);
        newFlash.SetActive(true);
        clicksAnimator.Play("FadeIn");
    }
}
