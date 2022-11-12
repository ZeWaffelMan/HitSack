using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public GameObject fire;

    Smacking smacking;

    private void Awake()
    {
        smacking = GameObject.Find("MouseManager").GetComponent<Smacking>();
    }

    private void Start()
    {
        //ID's
        shopItems[1,1] = 1;

        //Price
        shopItems[2, 1] = 500;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            if (smacking.clicks >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID = 1])
            {
                fire.SetActive(true);
            }
            smacking.clicks -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            smacking.clicksText.text = smacking.clicks.ToString();
        }

    }
}
