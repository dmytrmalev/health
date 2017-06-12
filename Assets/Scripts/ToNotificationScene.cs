using UnityEngine;
using System.Collections;

public class ToNotificationScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		VariableScript.METABOLIZER_ID = -1;
		VariableScript.HERBAL_DRUG_COUNT = 0;
		Application.LoadLevel ("Notification");
	}
}
