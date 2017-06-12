using UnityEngine;
using System.Collections;

public class POOR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		VariableScript.SetTopBar (3);
		VariableScript.METABOLIZER_ID = VariableScript.POOR_METABOLIZER;
		VariableScript.ShowGraphLegend (3);
		VariableScript.SetYAxis (3);
	}
}
