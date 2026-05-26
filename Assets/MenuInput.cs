using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class MenuInput : MonoBehaviour
{

    MenuController menuC;

    public bool CanOpenM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuC = gameObject.GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab) && menuC.UIisOpen != "Menu" && menuC.UIisOpen != "Shop")
        {
            menuC.OpenMenu();
            Debug.Log("Open Menu");
            menuC.UIisOpen = "Menu";
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && menuC.UIisOpen == "Menu")
        {
            menuC.OpenMenu();
            Debug.Log("Close Menu");
            menuC.UIisOpen = "None";
        }
        

    }
}
