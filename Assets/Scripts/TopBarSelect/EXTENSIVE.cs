using UnityEngine;
using System.Collections;

public class EXTENSIVE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		VariableScript.SetTopBar (1);
		VariableScript.METABOLIZER_ID = VariableScript.EXTENSIVE_METABOLIZER;
		VariableScript.ShowGraphLegend (1);
		VariableScript.SetYAxis (1);
	}
}