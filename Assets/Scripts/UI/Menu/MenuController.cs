using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject ShopCanvas;

    MenuInput menuUI;
    Shopinput ShopUI;

    public string UIisOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.SetActive(false);
        ShopCanvas.SetActive(false);

        ShopUI = gameObject.GetComponent<Shopinput>();
        menuUI = gameObject.GetComponent<MenuInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }
    public void OpenShop()
    {
        ShopCanvas.SetActive(!ShopCanvas.activeSelf);
    }
}
