using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
	public Button m_Button;
	//private GameObject Timer = GameObject.FindGameObjectWithTag("TimerTag");

	void Start()
	{
		Button btn = m_Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the restart button!");
		SceneManager.LoadScene (this.gameObject.scene.name, LoadSceneMode.Single);
	}
}