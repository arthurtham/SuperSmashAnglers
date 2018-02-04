using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlayerSelect : MonoBehaviour {

	//Reference itself
	public static ButtonPlayerSelect instance;

	private int playerId;
	private static int playerIdMax = 4;
	public int m_playerIdDefault;
	public int player;
	private static int[] playerIds = new int[playerIdMax+1];
	public Button m_Button;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		playerId =m_playerIdDefault;
		updateSprite ();
		Button btn = m_Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		nextPlayer ();	
		updateSprite ();
	}

	public int[] getPlayerIds() {
		return playerIds;
	}

	void nextPlayer()
	{
		if (playerId >= playerIdMax) {
			playerId = 0;
		} else {
			playerId++;
		}
		Debug.Log("playerId is now " + playerId.ToString() + "!");
	}

	void updateSprite() {
		string playerName = idToString (playerId);
		Debug.Log ("./Sprites/Players/" + playerName + ".png");
		Sprite toLoad = Resources.Load<Sprite> ("Sprites/Players/"+playerName+"");
		m_Button.GetComponent<Image> ().sprite = toLoad;
		m_Button.GetComponentInChildren<Text> ().text = "Player "+(player+1).ToString()
			+": "+playerName+
			"\n\""+idToNickname(playerId)+"\"";
		playerIds [player] = playerId;

	}

	public string idToString(int id) {
		switch (id) {
		case 0:
			return "Jerald";
		case 1:
			return "Jessica";
		case 2:
			return "Carl";
		case 3:
			return "Jason";
		case 4:
			return "Milan";
		} 
		return "null";
	}

	public string idToNickname(int id) {
		switch (id) {
		case 0:
			return "Finding Gerald";
		case 1:
			return "Jess the Mess";
		case 2:
			return "The Great Carl Reef";
		case 3:
			return "Jason";
		case 4:
			return "Milan";
		}
		return "null";
	}
}
