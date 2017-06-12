using UnityEngine;
using System.Collections;

public class ULTRARAPID : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		VariableScript.SetTopBar (0);
		VariableScript.METABOLIZER_ID = VariableScript.ULTRARAPID_METABOLIZER;
		VariableScript.ShowGraphLegend (0);
		VariableScript.SetYAxis (0);
	}
}
