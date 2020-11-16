using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
   [SerializeField]public Rigidbody2D rb;

    void Start(){
        gameObject.tag = "Asteroids";

    }
    void Update(){
        RotateAsteroid();
        regenAsteroid();
    }

    void RotateAsteroid(){
        transform.Rotate(Vector3.forward * 3f);
    }

    void regenAsteroid(){
        if (transform.position.y<-5.76f){
            transform.position = new Vector3(Random.Range(-7.85f,7.95f),Random.Range(6f,12f),0);
            rb.velocity = Vector3.zero;
            ScoreScript.scoreValue += 10;
            
        }
    }
}
