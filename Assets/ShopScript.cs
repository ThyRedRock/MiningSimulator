using Unity.VisualScripting;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public InteractSystem MyIntSys;
    [SerializeField] Shopinput shopUI;

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
}
