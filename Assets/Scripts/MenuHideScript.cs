using UnityEngine;
using System.Collections;

public class MenuHideScript : MonoBehaviour {

	public GameObject left_menu;
	// Use this for initialization
	void Start () {
		left_menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		left_menu.SetActive (false);
	}
}
