using UnityEngine;
using System.Collections;

public class ReleasedButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		gameObject.layer = 19;
		VariableScript.Message_Button_Pressed.SetActive(true);
		VariableScript.Message_Button_Pressed.layer = 21;
	}

	void OnMouseUp() {
		VariableScript.HideMessageBox ();
	}
}
