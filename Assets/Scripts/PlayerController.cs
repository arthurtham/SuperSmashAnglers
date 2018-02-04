using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//Define variables
	public float m_Horizontal_Speed = 0;
	public float m_Jump_Speed = 0;
	private bool grounded = false;
	private bool jump_delay = false;

	//Define Rigidbody
	public Rigidbody2D m_Rigidbody;

	//Define Custom Axis
	public string m_Player_AxisHorizontal;
	public string m_Player_ButtonJump;

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
		if (Input.GetAxis (m_Player_AxisHorizontal) > 0.5f) {
			Debug.Log ("Player is moving forward!");
			//m_Rigidbody.AddRelativeForce (Vector3.right * m_Horizontal_Speed);
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation - m_Horizontal_Speed / 2);
		} else if (Input.GetAxis (m_Player_AxisHorizontal) < -0.5f) {
			Debug.Log ("Player is moving backward!");
			//m_Rigidbody.AddRelativeForce (Vector3.right * -1.0f * m_Horizontal_Speed);
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation + m_Horizontal_Speed / 2);
		}

		if (grounded) {
			//Vertical Movement
			if ((Input.GetButton (m_Player_ButtonJump)) && (!jump_delay) ) {
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

		//Grounded
		if (other.gameObject.CompareTag("Ground")) {
			Debug.Log ("Just entered the ground!");
			this.grounded = true;
		}

		//DeadArea
		if ( (!WinController.instance.GetWinState()) && 
			(other.gameObject.CompareTag("DeadArea"))) {
			if (this.gameObject.CompareTag("Player1")) { //Player 1 lost
				WinController.instance.SetWinState(true);
				WinController.instance.SetWinPlayer (1);
				Debug.Log("Player 2 wins!");
			} else if (this.gameObject.CompareTag("Player2")) {//Player 2 lost
				WinController.instance.SetWinState(true);
				WinController.instance.SetWinPlayer (0);
				Debug.Log("Player 1 wins!");
			}
			SceneManager.LoadScene ("Winner", LoadSceneMode.Single);
		}

	}

	void OnCollisionExit2D (Collision2D other) {
		if (other.gameObject.CompareTag("Ground")) {
			Debug.Log ("Just left the ground!");
			this.grounded = false;
		}
	}

}
