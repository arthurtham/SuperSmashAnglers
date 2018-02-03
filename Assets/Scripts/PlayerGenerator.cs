using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour {

	private static int[] playerIds;
	private GameObject p1;
	private GameObject p2;

	// Use this for initialization
	void Start () {
		playerIds = ButtonPlayerSelect.instance.getPlayerIds();
		Debug.Log (playerIds[0]);
		p1 = GameObject.FindGameObjectWithTag ("Player1").gameObject;
		p2 = GameObject.FindGameObjectWithTag ("Player2").gameObject;

		StartCoroutine (LateStart ());

	}

	IEnumerator LateStart()
	{
		yield return new WaitForEndOfFrame ();
		Generate ();
	}

	void Generate() {
		Debug.Log (ButtonPlayerSelect.instance.idToString (playerIds [0]));
		//Debug.Log (obj);

		Sprite toLoad = Resources.Load<Sprite> ("Sprites/Players/"+ButtonPlayerSelect.instance.idToString (playerIds [0]));
		p1.GetComponent<SpriteRenderer> ().sprite = toLoad;
		p1.AddComponent<PolygonCollider2D> ();

		toLoad = Resources.Load<Sprite> ("Sprites/Players/"+ButtonPlayerSelect.instance.idToString (playerIds [1]));
		p2.GetComponent<SpriteRenderer>().sprite = toLoad;
		p2.AddComponent<PolygonCollider2D> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
