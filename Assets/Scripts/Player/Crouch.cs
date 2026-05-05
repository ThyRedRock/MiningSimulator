using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Crouch : MonoBehaviour
{
    public float crouchHeight;
    public Move player;

    private Vector2 normalHeight;
    private float yInput;


    public void Start()
    {
        normalHeight = transform.localScale;
    }

    private void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");

        if(yInput < 0 && player.isOnGround)
        {
            if(transform.localScale.y != crouchHeight)
            transform.localScale = new Vector2(normalHeight.x, crouchHeight);
        }
        else 
        {
            if(transform.localScale.y != normalHeight.y)
            transform.localScale = normalHeight;
        }
    }
}
