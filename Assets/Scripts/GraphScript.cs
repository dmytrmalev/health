using UnityEngine;
using System.Collections;

public class GraphScript : MonoBehaviour {

	// Graph panel to draw graphs for amount of drag with no inhibitor, with 1st inhibitor, with 2nd inihibitor, with 1st & 2nd inhibitor.
	public GameObject UM;
	public GameObject UM_IN_1;
	public GameObject UM_IN_2;
	public GameObject UM_IN_1_2;

	// Sample circles for 4 graph line vertices.
	public GameObject Circle_Cyan;
	public GameObject Circle_Pink;
	public GameObject Circle_Green;
	public GameObject Circle_Purple;

	// Base point, Max X Point and Max Y Point of the graph.
	Vector3 BasePoint = new Vector3 (0.48f, -2.15f, -1f);
	Vector3 RightCornerPoint = new Vector3(3.55f, -2.15f, -1f);
	Vector3 TopCornerPoint = new Vector3(0.45f, 0.8f, -1f);

	// Vertices that are displayed in the graph: 7 circles for each 4 graphs.
	public static GameObject[] Cyan_Circles = new GameObject[7];
	public static GameObject[] Pink_Circles = new GameObject[7];
	public static GameObject[] Green_Circles = new GameObject[7];
	public static GameObject[] Purple_Circles = new GameObject[7];

	public int[] Circle_Points2 = {0, 1, 2, 4, 6, 8, 24};

	// Use this for initialization
	void Start () {

		// Initialize graph vertices.
		Circle_Cyan.SetActive (false);
		Circle_Pink.SetActive (false);
		Circle_Green.SetActive (false);
		Circle_Purple.SetActive (false);

		for (int i = 0; i < 7; i++) {
			Cyan_Circles[i] = (GameObject) Instantiate(Circle_Cyan);
			Pink_Circles[i] = (GameObject) Instantiate(Circle_Pink);
			Green_Circles[i] = (GameObject) Instantiate(Circle_Green);
			Purple_Circles[i] = (GameObject) Instantiate(Circle_Purple);
		}
	}

	// Function to show vertices for each graphs.
	// Parameter: 	index - Index of the graph vertice. Range of 0-6 (Means 7 vertices)
	// 				objects - Graph vertices to be displayed.
	//				vec - Coordinates of each vertices.
	void ShowCircles(int index, GameObject [] objects, Vector3 vec) {
		for (int i = 0; i < 7; i++) {
			if (index == Circle_Points2[i]) {
				objects[i].transform.position = vec;
			}
		}
	}

	// Function to remove graph elements for reset purpose.
	public static void RemoveAllGraph()
	{
		for (int i = 0; i < 7; i++) {
			Green_Circles[i].SetActive(false);
			Pink_Circles[i].SetActive(false);
			Purple_Circles[i].SetActive(false);
			Cyan_Circles[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// If no metabolizer is selected no graph is displayed.
		if (VariableScript.METABOLIZER_ID == -1)
			return;

		// Set graph points according to the selected metabolizer.
		float [] UM_Vertices = new float[25];
		for (int i = 0; i < 25; i++){
			UM_Vertices[i] = VariableScript.GRAPH_VERTICES[VariableScript.METABOLIZER_ID, i];
		}

		// Draw graph amount drug without any inhibitor.
		if (VariableScript.HERBAL_DRUG_COUNT >= 0 && UM.GetComponent<LineRenderer>()) {
			LineRenderer lineRenderer = UM.GetComponent<LineRenderer>();
			lineRenderer.SetVertexCount(25);
			for (int i = 0; i < 7; i++) {
				Cyan_Circles[i].SetActive(true);
			}
			for (int i = 0; i < 25; i++) {
				float x = i * 10 / 250.0f * (RightCornerPoint.x - BasePoint.x) + BasePoint.x;
				float y = UM_Vertices[i] / (float)VariableScript.pnY_Max[VariableScript.METABOLIZER_ID] * (TopCornerPoint.y -  BasePoint.y) + BasePoint.y;
				lineRenderer.SetPosition(i, new Vector3(x, y, -1f));
				ShowCircles(i, Cyan_Circles, new Vector3(x, y, -1f));
			}
			lineRenderer.SetWidth(0.03f, 0.03f);
		}

		// Draw graph amount drug with 1st inhibitor.
		if (VariableScript.HERBAL_DRUG_COUNT >= 1 && UM_IN_1.GetComponent<LineRenderer>()) {
			LineRenderer lineRenderer = UM_IN_1.GetComponent<LineRenderer>();
			lineRenderer.SetVertexCount(25);
			for (int i = 0; i < 7; i++) {
				Pink_Circles[i].SetActive(true);
			}
			for (int i = 0; i < 25; i++) {
				float x = i * 10 / 250.0f * (RightCornerPoint.x - BasePoint.x) + BasePoint.x;
				float y = UM_Vertices[i] / (float)VariableScript.pnY_Max[VariableScript.METABOLIZER_ID] * (TopCornerPoint.y -  BasePoint.y) * VariableScript.HERBAL_DRUG_MULTIPLIERS[VariableScript.HERBAL_DRUGS[0]] + BasePoint.y;
				lineRenderer.SetPosition(i, new Vector3(x, y, -1f));
				ShowCircles(i, Pink_Circles, new Vector3(x, y, -1f));
			}
			lineRenderer.SetWidth(0.03f, 0.03f);
		}

		// Draw graph amount drug with 2nd inhibitor, 1st & 2nd inhibitor.
		if (VariableScript.HERBAL_DRUG_COUNT >= 2 && UM_IN_1.GetComponent<LineRenderer>() && UM_IN_1_2.GetComponent<LineRenderer>()) {

			// Draw graph amount drug with 2nd inhibitor.
			LineRenderer lineRenderer = UM_IN_2.GetComponent<LineRenderer>();
			lineRenderer.SetVertexCount(25);
			for (int i = 0; i < 7; i++) {
				Green_Circles[i].SetActive(true);
				Purple_Circles[i].SetActive(true);
			}
			for (int i = 0; i < 25; i++) {
				float x = i * 10 / 250.0f * (RightCornerPoint.x - BasePoint.x) + BasePoint.x;
				float y = UM_Vertices[i] / (float)VariableScript.pnY_Max[VariableScript.METABOLIZER_ID] * (TopCornerPoint.y -  BasePoint.y) * VariableScript.HERBAL_DRUG_MULTIPLIERS[VariableScript.HERBAL_DRUGS[1]] + BasePoint.y;
				lineRenderer.SetPosition(i, new Vector3(x, y, -1f));
				ShowCircles(i, Green_Circles, new Vector3(x, y, -1f));
			}
			lineRenderer.SetWidth(0.03f, 0.03f);

			// Draw graph amount drug with 1st & 2nd inhibitor.
			lineRenderer = UM_IN_1_2.GetComponent<LineRenderer>();
			lineRenderer.SetVertexCount(25);
			for (int i = 0; i < 25; i++) {
				float x = i * 10 / 250.0f * (RightCornerPoint.x - BasePoint.x) + BasePoint.x;
				float y = UM_Vertices[i] / (float)VariableScript.pnY_Max[VariableScript.METABOLIZER_ID] * (TopCornerPoint.y -  BasePoint.y) * VariableScript.HERBAL_DRUG_MULTIPLIERS[VariableScript.HERBAL_DRUGS[0]] * VariableScript.HERBAL_DRUG_MULTIPLIERS[VariableScript.HERBAL_DRUGS[1]] + BasePoint.y;
				lineRenderer.SetPosition(i, new Vector3(x, y, -1f));
				ShowCircles(i, Purple_Circles, new Vector3(x, y, -1f));
			}
			lineRenderer.SetWidth(0.03f, 0.03f);
		}

	}
}
