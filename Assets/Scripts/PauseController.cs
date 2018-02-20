using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

	public static PauseController instance;
	private static bool paused = false;
	private static bool panel = false;
	public GameObject m_PauseMenu;

	// Use this for initialization
	void Start () {
		instance = this;
		Time.timeScale = 1;
		paused = false;
		panel = false;
	}

	public void SwitchPause(){
		paused = !paused;
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void SwitchPanel(){
		panel = !panel;
		m_PauseMenu.SetActive (panel);
	}

}
