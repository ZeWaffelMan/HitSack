using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];

    public GameObject fire;
    public GameObject banana;
    public GameObject chain;
    public GameObject goldChain;

    public GameObject fireButton;
    public GameObject cursorButton;
    public GameObject bananaButton;
    public GameObject glassesButton;

    private bool boughtFire = false;
    private bool boughtBanana = false;

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


        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 250;
        shopItems[2, 3] = 502;
        shopItems[2, 4] = 2026;

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

            cursorButton.SetActive(false);
            fireButton.SetActive(true);
            bananaButton.SetActive(true);
            smacking.cursorClicks = 2;
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

            fireButton.SetActive(false);
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

            bananaButton.SetActive(false);
            banana.SetActive(true);

            boughtBanana = true;
        }
    }

    // Gold Chain
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

            glassesButton.SetActive(false);
            
            chain.SetActive(false);
            goldChain.SetActive(true);

            smacking.cursorClicks += smacking.cursorClicks;
            Fire.fireAmount += Fire.fireAmount;
            Banana.bananaAmount += Banana.bananaAmount;
        }
    }
}
