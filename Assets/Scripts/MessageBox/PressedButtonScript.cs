using UnityEngine;
using System.Collections;

public class PressedButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		VariableScript.HideMessageBox ();
	}
}
