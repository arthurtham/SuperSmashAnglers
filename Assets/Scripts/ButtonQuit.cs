using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonQuit : MonoBehaviour
{
	public Button m_Button;


	void Start()
	{
		Button btn = m_Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the quit button!");
		Application.Quit ();
	}
}