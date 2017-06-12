using UnityEngine;
using System.Collections;

public class INTERMEDIATE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		VariableScript.SetTopBar (2);
		VariableScript.METABOLIZER_ID = VariableScript.INTERMEDIATE_METABOLIZER;
		VariableScript.ShowGraphLegend (2);
		VariableScript.SetYAxis (2);
	}
}
