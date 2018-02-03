using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
	public Button m_Button;
	public string m_ToScene;


	void Start()
	{
		Button btn = m_Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		if (m_ToScene.Equals ("")) {
			m_ToScene = this.gameObject.scene.name;
		}
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the "+ m_ToScene +" button!");
		SceneManager.LoadScene (m_ToScene, LoadSceneMode.Single);
	}
}