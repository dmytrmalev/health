using UnityEngine;
using System.Collections;

public class MenuShowScript : MonoBehaviour {

	public GameObject left_menu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		left_menu.SetActive (true);
	}
}
