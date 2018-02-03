using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float m_Horizontal_Speed = 0;
	public float m_Jump_Speed = 0;
	private bool grounded;

	public Rigidbody2D m_Rigidbody;

	//Awake
	void Awake () {
		m_Rigidbody = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Physics uses FixedUpdate
	void FixedUpdate () {

		if (grounded) {
			// Horizontal Movement
			if (Input.GetAxis ("Horizontal") > 0.5f) {
				Debug.Log ("Player is moving forward!");
				m_Rigidbody.AddRelativeForce (transform.right * m_Horizontal_Speed);
			} else if (Input.GetAxis ("Horizontal") < -0.5f) {
				Debug.Log ("Player is moving backward!");
				m_Rigidbody.AddRelativeForce (transform.right * -1.0f * m_Horizontal_Speed);
			}

			//Vertical Movement
			if (Input.GetButton ("Jump")) {
				Debug.Log ("Player spazzed!");
				m_Rigidbody.AddForce (transform.up * m_Jump_Speed);
			}

		}
	
	}

	// Collision detection
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag("Ground")) {
			Debug.Log ("Just entered the ground!");
			this.grounded = true;
		}
	}

	void OnCollisionExit2D (Collision2D other) {
		if (other.gameObject.CompareTag("Ground")) {
			Debug.Log ("Just left the ground!");
			this.grounded = false;
		}
	}
}
