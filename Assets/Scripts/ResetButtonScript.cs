using UnityEngine;
using System.Collections;

public class ResetButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		//When we click reset button, Button style is changed to active.
		VariableScript.Background_Released.SetActive (false);
		VariableScript.Text_Released.SetActive (false);
		VariableScript.Background_Pressed.SetActive (true);
		VariableScript.Text_Pressed.SetActive (true);

	}

	void OnMouseUp() {

		//When we release reset button, Button style is changed to inactive.
		VariableScript.Background_Released.SetActive (true);
		VariableScript.Text_Released.SetActive (true);
		VariableScript.Background_Pressed.SetActive (false);
		VariableScript.Text_Pressed.SetActive (false);

		//When we release reset button, graph is reset.
		VariableScript.METABOLIZER_ID = -1;
		VariableScript.HERBAL_DRUG_COUNT = 0;

		VariableScript.SetTopBar (-1);
		VariableScript.ResetLeftBar ();
		VariableScript.ShowGraphLegend (-1);
		GraphScript.RemoveAllGraph ();
	}
}
