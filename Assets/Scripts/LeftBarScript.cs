using UnityEngine;
using System.Collections;

public class LeftBarScript : MonoBehaviour {

	bool bIsOnDrag = false;
	float fOffsetX = 0;
	float fOffsetY = 0;

	public GameObject avatar;
	public GameObject tempObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (bIsOnDrag == true) {
			OnMouseOver();
		}
	}

	void OnMouseDown() {

		// If we click one item of left bar, that item is duplicated for visualization purpose.
		tempObject = (GameObject) Instantiate (gameObject);
		tempObject.transform.position = gameObject.transform.position;

		// The initial position of touch point in the item is saved for drag&drop purpose.
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 6.6f;

		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		fOffsetX = gameObject.transform.position.x - mouseWorldPosition.x;
		fOffsetY = gameObject.transform.position.y - mouseWorldPosition.y;

		Vector3 position = gameObject.transform.position;
		position.x = position.y = 0;

		// Flag is set true for drag&drop purpose.
		bIsOnDrag = true;

	}

	void OnMouseOver() {

		// When we drag and drop a drug, duplicate of that item follows the mouse position.
		if (bIsOnDrag == true) {
			Vector3 objectPosition = gameObject.transform.position;
			Vector3 mousePosition = Input.mousePosition;

			mousePosition.z = 6.6f;
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePosition);
			objectPosition.x = mouseWorldPosition.x + fOffsetX;
			objectPosition.y = mouseWorldPosition.y + fOffsetY;

			tempObject.transform.position = objectPosition;
		}
	}

	void OnMouseUp() {

		// When we release the mouse, duplicate of the selected item disappears.
		tempObject.SetActive (false);

		bIsOnDrag = false;

		// If no metabolizer is selected, error message is displayed.
		if (VariableScript.METABOLIZER_ID == -1) {
			VariableScript.ShowMessageBox(2);
			return;
		}

		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 6.6f;
		
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		mouseWorldPosition.z = 0;

		// If drug is drag & dropped correctly to the human body.
		if (avatar.collider2D.bounds.Contains (mouseWorldPosition)) {
			for (int i = 0; i < 12; i++)
			{
				if (gameObject.Equals(VariableScript.LeftBar_Object[i]))
				{
					// If 2 inhibitors are already selected, error message is displayed.
					if (VariableScript.HERBAL_DRUG_COUNT == 2)
					{
						VariableScript.ShowMessageBox(0);
					}
					else
					{
						// If inihibitor is already selected, error message is displayed.
						if (VariableScript.HERBAL_DRUG_COUNT == 1 && VariableScript.HERBAL_DRUGS[0] == i)
						{
							VariableScript.ShowMessageBox(1);
							return;
						}

						// Selected inhibitor is highlighted as selected state.
						VariableScript.HERBAL_DRUGS[VariableScript.HERBAL_DRUG_COUNT ++] = i;
						VariableScript.LeftBar_Inactive[i].SetActive(false);
						VariableScript.LeftBar_InactiveText[i].SetActive(false);
						VariableScript.LeftBar_Active[i].SetActive(true);
						VariableScript.LeftBar_ActiveText[i].SetActive(true);
					}
					break;
				}
			}
		}
	}
}
