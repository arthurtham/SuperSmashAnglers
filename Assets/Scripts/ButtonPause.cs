using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour {
	public Button m_Button;
	// Use this for initialization
	void Start () {
		Button btn = m_Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	}
	
	// Update is called once per frame
	void TaskOnClick()
	{
		Debug.Log("You have clicked the pause button!");
		PauseController.instance.SwitchPause ();
		PauseController.instance.SwitchPanel ();
	}
}
