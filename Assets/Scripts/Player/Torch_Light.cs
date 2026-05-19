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
        transform.position = new Vector3(playerLocation.x + x, playerLocation.y + y, playerLocation.z);

        if(crouch.isCrouching == true)
        {
            y = crouchDistance;
        }
        else if(crouch.isCrouching == false)
        {
            y = 1.2f;
        }
    }
}
