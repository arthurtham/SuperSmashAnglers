using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerSpriteController : MonoBehaviour {

	private Sprite m_WinnerSprite;
	public GameObject go;

	// Use this for initialization
	void Start () {
		//Winner Sprite Controller appears on a game complete,
		//so the boolean in the controller can be reset now.
		WinController.instance.SetWinState(false);
		StartCoroutine (LateStart ());
	}

	IEnumerator LateStart() {
		yield return new WaitForEndOfFrame ();

		//Set the sprite to the winner
		m_WinnerSprite = Resources.Load<Sprite> ("Sprites/Players/" +
			ButtonPlayerSelect.instance.idToString(
				ButtonPlayerSelect.instance.getPlayerIds () [
			WinController.instance.GetWinPlayer ()]
			)
		);
		Debug.Log ("Sprites/Players/" +
		ButtonPlayerSelect.instance.idToString (
			ButtonPlayerSelect.instance.getPlayerIds () [
				WinController.instance.GetWinPlayer ()]
		)
		);

		go.GetComponent<SpriteRenderer>().sprite = m_WinnerSprite;

		//Now set the text
		this.GetComponentInChildren<Text> ().text = "Player " +
			(WinController.instance.GetWinPlayer() + 1).ToString() + " wins!";
		

	}
	// Update is called once per frame
	void Update () {
		
	}
}
