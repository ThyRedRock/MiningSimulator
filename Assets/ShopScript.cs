using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ShopScript : MonoBehaviour
{
    public InteractSystem MyIntSys;
    [SerializeField] Shopinput shopUI;
    public List<GameObject> Selectedsell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        else
        {
            Selectedsell.Add(ClickedObj);
        }
    }
}
