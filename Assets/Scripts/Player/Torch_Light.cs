using Unity.VisualScripting;
using UnityEngine;

public class Torch_Light : MonoBehaviour
{
    
    public GameObject player;
    public Vector3 playerLocation;
    public float x;
    public float y;
    public float crouchDistance;
    public Crouch crouch;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = new Vector3(playerLocation.x + x, playerLocation.y + y, playerLocation.z); //Makes torch follow player

        if(crouch.isCrouching == true) //if crouching then set y to crouchDistance
        {
            y = crouchDistance;
        }
        else if(crouch.isCrouching == false) //if not crouching then set y to normal
        {
            y = 1.2f;
        }
    }
}
