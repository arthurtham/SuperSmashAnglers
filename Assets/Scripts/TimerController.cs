using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

	private static float timer;

	private static bool running = false;

	//public static TimerController instance;

	[SerializeField]
	public Text m_Textbox;
	private static float defaultTime = 60.0f;

	// Use this for initialization
	void Start () {
		//instance = this;
		ResetTimer ();
	}

	public static void ResetTimer() {
		timer = defaultTime;
		Debug.Log ("The timer is started!");
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
