using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

	private static float timer;

	private static bool running = false;

	//private static Vector3 m_timerLocationOriginal;
	//private static Vector3 m_timerLocationCentered;

	//public static TimerController instance;

	[SerializeField]
	public Text m_Textbox;
	private static float defaultTime = 60.0f;

	// Use this for initialization
	void Start () {
		//instance = this;
		ResetTimer ();
		/*m_timerLocationOriginal = new Vector3 (
			m_Textbox.gameObject.transform.position.x,
			m_Textbox.gameObject.transform.position.y,
			m_Textbox.gameObject.transform.position.z);
		m_timerLocationCentered = new Vector3 (
			0,
			0,
			m_Textbox.gameObject.transform.position.z);*/
	}

	public static void ResetTimer() {
		StopTimer ();
		timer = defaultTime;
		Debug.Log ("The timer is reset!");
	}

	public static void StopTimer() {
		running = false;
		Debug.Log ("The timer is stopped!");
	}

	public static void StartTimer() {
		running = true;
		Debug.Log ("The timer is started!");
	}

	// Update is called once per frame
	void Update () {
		if (running) {
			timer -= Time.deltaTime;
		}

		if (timer < 10.0f) {
			if (((timer % 2 >= 0.5) && (timer % 2 <= 1.0)) || (timer % 2 >= 1.5))
				m_Textbox.color = Color.red;
			else
				m_Textbox.color = Color.yellow;
			//m_Textbox.gameObject.transform.position = m_timerLocationCentered;
		} else {
			m_Textbox.color = Color.white;
			//m_Textbox.transform.position = m_timerLocationOriginal;

		}

		m_Textbox.text = timer.ToString("0.00");
		if (timer <= 0.0f) {
			//Player 1 wins by default
			WinController.instance.SetWinState(true);
			WinController.instance.SetWinPlayer (0);
			TimerController.StopTimer ();
			Debug.Log("Player 1 wins!");
			SceneManager.LoadScene ("Winner", LoadSceneMode.Single);
		}
	}
}
