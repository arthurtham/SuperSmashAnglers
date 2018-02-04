using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour {

	public static WinController instance;
	private static bool win = false;
	private static int winningPlayer = -1;


	void Awake() {
		instance = this;
	}

	public void SetWinState(bool set) {
		win = set;
	}

	public bool GetWinState() {
		return win;
	}

	public void SetWinPlayer(int set) {
		winningPlayer = set;
	}

	public int GetWinPlayer() {
		return winningPlayer;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
