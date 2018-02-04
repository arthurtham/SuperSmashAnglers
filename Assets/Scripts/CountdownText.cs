using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour {

	/**
	 * Upon waking up, this object will countdown from 3,
	 * say "Go", then destroy itself.
	 **/

	private int counter = 0;
	public GameObject go;
	private Text txt;
	private GameObject p1;
	private GameObject p2;

	// Use this for initialization
	void Start () {
		//Get component
		txt = go.GetComponent<Text> ();

		//Get players
		p1 = GameObject.FindGameObjectWithTag ("Player1").gameObject;
		p2 = GameObject.FindGameObjectWithTag ("Player2").gameObject;



		//Set a countdown timer
		InvokeRepeating("Countdown",0.0f,1.0f);

	}

	void Countdown() {
		switch (counter) {
		case 0: 
			p1.GetComponent<Rigidbody2D>().isKinematic = true;
			p2.GetComponent<Rigidbody2D>().isKinematic = true;
			txt.text = "3";
			break;
		case 1:
			txt.text = "2";
			break;
		case 2:
			txt.text = "1";
			break;
		case 3:
			p1.GetComponent<Rigidbody2D>().isKinematic = false;
			p2.GetComponent<Rigidbody2D>().isKinematic = false;
			txt.text = "GO!";
			break;
		case 4:
			Destroy(this.gameObject); //Ends execution
			break;
		}
		//Keep incrementing
		++counter;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
