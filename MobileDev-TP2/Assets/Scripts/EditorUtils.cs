using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUtils : MonoBehaviour
{
 
    public float movespeed;
    public Rigidbody2D rb;
    private Vector2 movedic;
    
    void Update(){
        ProcessInputs();
    }

    void FixedUpdate(){
        Move();

    }

    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movedic = new Vector2(moveX, moveY);

    }

    void Move(){
        rb.velocity = new Vector2(movedic.x * movespeed, movedic.y*movespeed);
    }

}
