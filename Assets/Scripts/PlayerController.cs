using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float m_Horizontal_Speed = 0;
	public float m_Jump_Speed = 0;
	private bool grounded = false;
	private bool jump_delay = false;

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


		//Vector3 euler = new Vector3 (0, 100, 0);
		//Quaternion dRotation = Quaternion.Euler (euler * Time.deltaTime);
		// Horizontal Movement
		if (Input.GetAxis ("Horizontal") > 0.5f) {
			Debug.Log ("Player is moving forward!");
			//m_Rigidbody.AddRelativeForce (Vector3.right * m_Horizontal_Speed);
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation - m_Horizontal_Speed / 2);
		} else if (Input.GetAxis ("Horizontal") < -0.5f) {
			Debug.Log ("Player is moving backward!");
			//m_Rigidbody.AddRelativeForce (Vector3.right * -1.0f * m_Horizontal_Speed);
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation + m_Horizontal_Speed / 2);
		}

		if (grounded) {
			//Vertical Movement
			if ((Input.GetButton ("Jump")) && (!jump_delay) ) {
				Debug.Log ("Player spazzed!");
				m_Rigidbody.AddRelativeForce (Vector3.up * m_Jump_Speed);
				jump_delay = true;
				Invoke("JumpDelayReset",0.5f);
			}

		}
	
	}

	//reset jump delay
	void JumpDelayReset () {
		jump_delay = false;
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
