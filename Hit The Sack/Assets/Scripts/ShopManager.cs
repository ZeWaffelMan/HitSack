using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[10, 10];

    public GameObject fire;
    public GameObject banana;
    public GameObject chain;
    public GameObject goldChain;
    public GameObject backgroundRotater;

    public GameObject fireButton;
    public GameObject cursorButton;
    public GameObject bananaButton;
    public GameObject glassesButton;
    public GameObject magicButton;
    public GameObject rotateButton;

    public Animator sackAnimator;

    private bool boughtFire = false;
    private bool boughtBanana = false;

    public static bool boughtRotate = false;

    Smacking smacking;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
    }

    private void Start()
    {
        //ID's
        shopItems[1,1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;
        shopItems[1, 6] = 6;
        shopItems[1, 7] = 7;



        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 250;
        shopItems[2, 3] = 502;
        shopItems[2, 4] = 2026;
        shopItems[2, 5] = 4;
        shopItems[2, 6] = 0;
        shopItems[2, 7] = 0;


    }

    private void Update()
    {
        if(boughtFire == true && boughtBanana == true)
        {
            glassesButton.SetActive(true);
        }
    }

    // Cursor
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            smacking.clicksText.text = smacking.clicks.ToString();
            audioManager.Play("Slap");


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
            smacking.clicksText.text = smacking.clicks.ToString();
            audioManager.Play("Slap");

            ButtonRef.SetActive(false);
            fire.SetActive(true);

            boughtFire = true;
        }
    }

    //Banana
    public void Buy3()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            smacking.clicksText.text = smacking.clicks.ToString();
            audioManager.Play("Slap");

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
            smacking.clicksText.text = smacking.clicks.ToString();
            audioManager.Play("Slap");

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
            smacking.clicksText.text = smacking.clicks.ToString();
            audioManager.Play("Slap");

            ButtonRef.SetActive(false);

            rotateButton.SetActive(true);
            sackAnimator.Play("SackDisco");
        }
    }

    // Rotate
    public void Buy6()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            smacking.clicksText.text = smacking.clicks.ToString();
            audioManager.Play("Slap");

            ButtonRef.SetActive(false);

            backgroundRotater.SetActive(true);
            boughtRotate = true;
            Rotate.canSpinFaster = true;
        }
    }

    // Stop Spinning
    public void Buy7()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            smacking.clicksText.text = smacking.clicks.ToString();

            audioManager.Play("Slap");

            ButtonRef.SetActive(false);

            Rotate.canSpinFaster = false;
            Rotate.isStopped = true;
        }
    }
}
