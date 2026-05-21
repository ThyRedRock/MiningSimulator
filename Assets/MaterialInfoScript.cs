using System;
using UnityEngine;
using TMPro;

public class MaterialInfoScript : MonoBehaviour
{
    public String Name;
    public int Amount;
    public SpriteRenderer sprR;
    [SerializeField] TMP_Text NameT;
    [SerializeField] TMP_Text AmountT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AmountT.text = "" + AmountT + "x";
        NameT.text = "" + NameT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
