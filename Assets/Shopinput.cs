using UnityEngine;

public class Shopinput : MonoBehaviour
{
    MenuController menuC;
    public bool CanOpenS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuC = gameObject.GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanOpenS == true)
        {
            OpenShopUI();
        }
        else if (menuC.UIisOpen == "Shop")
        {
            menuC.OpenShop();
            menuC.UIisOpen = "None";
        }
    }

    public void OpenShopUI()
    {

        if (Input.GetKeyDown(KeyCode.E) && menuC.UIisOpen != "Shop" && menuC.UIisOpen != "Menu")
        {
            menuC.OpenShop();
            menuC.UIisOpen = "Shop";
        }  
        else if (Input.GetKeyDown(KeyCode.E) && menuC.UIisOpen == "Shop")
        {
            menuC.OpenShop();
            menuC.UIisOpen = "None";
        }
    }
}
