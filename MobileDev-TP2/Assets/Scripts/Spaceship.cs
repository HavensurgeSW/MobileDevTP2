using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour {

	Rigidbody2D rb;
	float dirX;
	float moveSpeed = 20f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.acceleration.x * moveSpeed;
		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -8.0f, 8.0f), transform.position.y);
	}

	void FixedUpdate(){
		rb.velocity = new Vector2 (dirX, 0f);
	}

	void OnTriggerEnter2D(Collider2D Other){
		this.gameObject.SetActive(false);
		Handheld.Vibrate();
		
		SceneManager.LoadScene(0);
	}

}
