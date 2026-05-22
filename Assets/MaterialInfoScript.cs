using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class MaterialInfoScript : MonoBehaviour
{
    public String Name;
    public int Amount;
    [SerializeField] TMP_Text NameT;
    [SerializeField] TMP_Text AmountT;
    [SerializeField] Button mybutton;
    [SerializeField] UnityEngine.UI.Image myImage;

    bool Selected;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject shopObject = GameObject.Find("ShopObject");

        mybutton.onClick.AddListener(() => 
        shopObject.GetComponent<ShopScript>().Select_Deselect(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        AmountT.text = "x" + Amount + "";
        NameT.text = "" + Name;
    }

    public void changecolor()
    {
        if (Selected == false)
        {
            myImage.color = new Color32(11, 75, 221, 105);
            Selected = true;
        }
        else
        {
            myImage.color = new Color32(0, 0, 0, 105);
            Selected = false;
        }
    }
}
