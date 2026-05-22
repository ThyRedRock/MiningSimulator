using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class ShopScript : MonoBehaviour
{
    public InteractSystem MyIntSys;
    [SerializeField] GameObject Invc;
    [SerializeField] Shopinput shopUI;
    public List<GameObject> Selectedsell;
    [SerializeField] TMP_Text SellSelectedText;
    [SerializeField] TMP_Text SellAllText;
    int SellSelectedvalue;
    int SellAllvalue;

    public int Money;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SellSelectedText.text = "$" + SellSelectedvalue + "";
        SellAllText.text = "$" + SellAllvalue + "";

        if (MyIntSys.CanInteract == true && MyIntSys.playerInRange == true)
        {
            shopUI.CanOpenS = true;
        }
        else
        {
            shopUI.CanOpenS = false;
        }
    }

    public void Select_Deselect(GameObject ClickedObj)
    {
        if (Selectedsell.Contains(ClickedObj))
        {
            Selectedsell.Remove(ClickedObj);
            CountSellSelectedValue();
        }
        else
        {
            Selectedsell.Add(ClickedObj);
            CountSellSelectedValue();
        }
    }

    public void CountSellSelectedValue()
    {
        SellSelectedvalue = 0;

        foreach(GameObject selected in Selectedsell)
        {
            if(selected != null)
            {
                if (selected.GetComponent<MaterialInfoScript>().Name == "Rock Bits")
                {
                    SellSelectedvalue = SellSelectedvalue+ selected.GetComponent<MaterialInfoScript>().Amount * 5;
                }

                if (selected.GetComponent<MaterialInfoScript>().Name == "Shiny Rock Bits")
                {
                    SellSelectedvalue =+ SellSelectedvalue + selected.GetComponent<MaterialInfoScript>().Amount * 40;
                }
            }
            else
            {
                Selectedsell.Remove(selected);
            }
        }
    }
    public void CountSellAllValue()
    {
        SellAllvalue = 0;

        for (int i = Invc.GetComponent<InventoryController>().MatinfoList.Count - 1; i >= 0; i--)
        {
            GameObject Mat = Invc.GetComponent<InventoryController>().MatinfoList[i];
            
            if(Mat != null)
            {
                if (Mat.GetComponent<MaterialInfoScript>().Name == "Rock Bits")
                {
                    SellAllvalue = SellAllvalue+ Mat.GetComponent<MaterialInfoScript>().Amount * 5;
                }

                if (Mat.GetComponent<MaterialInfoScript>().Name == "Shiny Rock Bits")
                {
                    SellAllvalue =+ SellAllvalue + Mat.GetComponent<MaterialInfoScript>().Amount * 40;
                }
            }
            else
            {
                Invc.GetComponent<InventoryController>().MatinfoList.Remove(Mat);
            }
        }
        
    }

    public void SellAll()
    {
        Money = Money + SellAllvalue;
        Invc.GetComponent<InventoryController>().MatinfoList.Clear();
        Selectedsell.Clear();
    }
    public void SellSelected()
    {
        Money = Money + SellSelectedvalue;

        foreach(GameObject Sel in Selectedsell)
        {
            Destroy(Sel);
        }
    }
}
