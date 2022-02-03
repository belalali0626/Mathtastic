using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMB : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator Anim;

    // crosshair for shooting   
    public GameObject crosshair;
    public bool endOfAiming;


    //Prefabs
    public GameObject shuriken;


    // Storing movement, horizontal and vertical 
    public float moveSpeed = 5f;
    public float shu_base_speed = 1.0f;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        Aim();
        ProcessInput();
        Shoot();

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

    void ProcessInput()
    {
        endOfAiming = Input.GetButtonUp("Fire1");
    }

    void Aim()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.localPosition = mousePos;

     }

    void Shoot()
    {
        Vector2 ShootingDirection = crosshair.transform.localPosition;
        ShootingDirection.Normalize();


        if (endOfAiming)
        {
            Debug.Log("Hii");
            GameObject shu = Instantiate(shuriken, transform.position, Quaternion.identity);
            shu.GetComponent<Rigidbody2D>().velocity = ShootingDirection * shu_base_speed;
            shu.transform.Rotate(0, 0, Mathf.Atan2(ShootingDirection.y, ShootingDirection.x) * Mathf.Rad2Deg);
            //Destroy(shu, 2.0f);
        }

    }
}
