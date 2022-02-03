using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMB : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Animator Anim;

    // Storing movement, horizontal and vertical 
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Animator
        Anim.SetFloat("Horizontal", movement.x);
        Anim.SetFloat("Vertical", movement.y);
        Anim.SetFloat("Speed", movement.sqrMagnitude);


    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);



    }
}
