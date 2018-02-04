using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonURL : MonoBehaviour {

	public Button m_Button;
	public string url;

	// Use this for initialization
	void Start () {
		Button btn = m_Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {
		Application.OpenURL (url);
	}
}

