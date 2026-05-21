using System;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class MaterialInfoScript : MonoBehaviour
{
    public String Name;
    public int Amount;
    [SerializeField] TMP_Text NameT;
    [SerializeField] TMP_Text AmountT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmountT.text = "x" + Amount + "";
        NameT.text = "" + Name;
    }
}
