using UnityEngine;
using System.Collections;

public class VariableScript : MonoBehaviour {

	// Resources to show selected and unselected items for ULTRARAPID, EXTENSIVE, INTERMEDIATE, POOR Metabolizers.
	// 0: ULTRARAPID, 1: EXTENSIVE, 2:INTERMEDIATE, 3:POOR.

	public GameObject [] Active = new GameObject[4];
	public GameObject [] ActiveText = new GameObject[4];
	public GameObject [] InactiveText = new GameObject[4];

	public static GameObject [] TopBar_Active = new GameObject[4];
	public static GameObject [] TopBar_ActiveText = new GameObject[4];
	public static GameObject [] TopBar_InactiveText = new GameObject[4];

	// Resources to show selected and unselected items for Herbals and Drugs.
	// 0: Echiniacea Plus H, 		1: Echiniacea Plus I, 			2: Echiniacea Plus L
	// 3: Echiniacea special H, 	4: Echiniacea special I, 		5: Echiniacea special L
	// 6: Echiniacea Goldenseal H, 	7: Echiniacea Goldenseal I, 	8: Echiniacea Goldenseal L
	// 9: Black Tea H, 				10: Black Tea I, 				11: Black Tea L

	public GameObject[] Left_Active = new GameObject[12];
	public GameObject[] Left_Inactive = new GameObject[12];
	public GameObject[] Left_ActiveText = new GameObject[12];
	public GameObject[] Left_InactiveText = new GameObject[12];
	public GameObject[] LeftBarItems = new GameObject[12];

	public static GameObject[] LeftBar_Active = new GameObject[12];
	public static GameObject[] LeftBar_Inactive = new GameObject[12];
	public static GameObject[] LeftBar_ActiveText = new GameObject[12];
	public static GameObject[] LeftBar_InactiveText = new GameObject[12];
	public static GameObject [] LeftBar_Object = new GameObject[12];

	// Resources to show graph legend for UM, EM, IM, PM
	// 0: UM, 1: EM, 2: IM, 3: PM

	public GameObject[] MTexts = new GameObject[4];
	public GameObject[] M_IN_1Texts = new GameObject[4];
	public GameObject[] M_IN_2Texts = new GameObject[4];
	public GameObject[] M_IN_1_2Texts = new GameObject[4];

	public static GameObject[] MS = new GameObject[4];
	public static GameObject[] M_IN_1S = new GameObject[4];
	public static GameObject[] M_IN_2S = new GameObject[4];
	public static GameObject[] M_IN_1_2S = new GameObject[4];

	// Resources to show graph Y-axis numbers.
	// Y-axis is separated into 5 pieces.
	// 0: 1st piece, 1: 2nd piece, 2: 3rd piece, 3: 4th piece. 4: 5th piece.

	public GameObject[] ULTRA_AXIS = new GameObject[5];
	public GameObject[] EXTENSIVE_AXIS = new GameObject[5];
	public GameObject[] INTERMEDIATE_AXIS = new GameObject[5];
	public GameObject[] POOR_AXIS = new GameObject[5];

	public static GameObject[] ULTRA_YAXIS = new GameObject[5];
	public static GameObject[] EXTENSIVE_YAXIS = new GameObject[5];
	public static GameObject[] INTERMEDIATE_YAXIS = new GameObject[5];
	public static GameObject[] POOR_YAXIS = new GameObject[5];

	// Resources to show MessageBox

	public GameObject Body;
	public GameObject Button_Released;
	public GameObject Button_Pressed;
	public GameObject[] Button_Texts = new GameObject[3];

	public static GameObject Message_Body;
	public static GameObject Message_Button_Released;
	public static GameObject Message_Button_Pressed;
	public static GameObject[] Message_Button_Texts = new GameObject[3];

	// Resources to show Reset Button.
	public GameObject Released_Bg;		//Background of reset button when unclicked.
	public GameObject Released_Text;	//Text "Reset" of reset button when unclicked.
	public GameObject Pressed_Bg;		//Background of reset button when clicked.
	public GameObject Pressed_Text;		//Text "Reset" of reset button when clicked.

	public static GameObject Background_Released;
	public static GameObject Text_Released;
	public static GameObject Background_Pressed;
	public static GameObject Text_Pressed;

	// Variables to specify which Metabolizer is selected.
	public static int ULTRARAPID_METABOLIZER = 0;
	public static int EXTENSIVE_METABOLIZER = 1;
	public static int INTERMEDIATE_METABOLIZER = 2;
	public static int POOR_METABOLIZER = 3;

	// Variable to specify selected Metabolizer.
	public static int METABOLIZER_ID = -1;

	// Variable to specify maximum Y-axis value for each Metabolizer.
	// 200: ULTRARAPID, 150: EXTENSIVE, 100: INTERMEDIATE, 15: POOR.
	public static int[] pnY_Max = {250, 150, 100, 15};

	// Variable to specify drag&dropped drug count.
	public static int HERBAL_DRUG_COUNT = 0;
	// Variable to store drag&dropped drugs.
	public static int[] HERBAL_DRUGS = new int[2];
	// Variable to store Multipliers for each drug;
	public static float [] HERBAL_DRUG_MULTIPLIERS = {0.67f, 0.70f, 0.74f, 0.86f, 0.90f, 0.95f, 0.80f, 0.84f, 0.88f, 0.88f, 0.92f, 0.97f};

	// Variable to store value of impact for each drugs in 0-240 minutes
	public static float[,] GRAPH_VERTICES = 
	{
		// UM
		{0f, 10f, 60f, 100f, 140f, 170f, 200f, 212f, 212f, 206.4f, 200.8f, 195.2f, 189.6f, 184f, 178.4f, 172.8f, 167.2f, 161.6f, 156f, 150.4f, 144.8f, 139.2f, 133.6f, 128f, 122.4f},
		// EM
		{0f, 10f, 30f, 50f, 70f, 85f, 100f, 106f, 106f, 103.2f, 100.4f, 97.6f, 94.8f, 92f, 89.2f, 86.4f, 83.6f, 80.8f, 78f, 75.2f, 72.4f, 69.6f, 66.8f, 64f, 61.2f},
		// IM
		{0f, 10f, 21f, 35f, 49f, 59.5f, 70f, 74.2f, 74.2f, 72.24f, 70.28f, 68.32f, 66.36f, 64.4f, 62.44f, 60.48f, 58.52f, 56.56f, 54.6f, 52.64f, 50.68f, 48.72f, 46.76f, 44.8f, 42.84f},
		// PM
		{0f, 1f, 3f, 5f, 7f, 8.5f, 10f, 10.6f, 10.6f, 10.32f, 10.04f, 9.76f, 9.48f, 9.2f, 8.92f, 8.64f, 8.36f, 8.08f, 7.8f, 7.52f, 7.24f, 6.96f, 6.68f, 6.4f, 6.12f}
	};

	void Start () {

		for (int i = 0; i < 4; i++) {

			// Initialize topbar resources.
			TopBar_Active[i] = Active[i];
			TopBar_ActiveText[i] = ActiveText[i];
			TopBar_InactiveText[i] = InactiveText[i];

			// Set topbar items to be unselected.
			TopBar_Active[i].SetActive(false);
			TopBar_ActiveText[i].SetActive(false);

			// Initialize graph legend.
			MS[i] = MTexts[i];
			M_IN_1S[i] = M_IN_1Texts[i];
			M_IN_2S[i] = M_IN_2Texts[i];
			M_IN_1_2S[i] = M_IN_1_2Texts[i];

			// Set graph legend items to be hidden originally.
			MS[i].SetActive(false);
			M_IN_1S[i].SetActive(false);
			M_IN_2S[i].SetActive(false);
			M_IN_1_2S[i].SetActive(false);
		}

		for (int i = 0; i < 12; i++) {

			// Initialize left bar items.
			LeftBar_Object[i] = LeftBarItems[i];
			LeftBar_Active[i] = Left_Active[i];
			LeftBar_Inactive[i] = Left_Inactive[i];
			LeftBar_ActiveText[i] = Left_ActiveText[i];
			LeftBar_InactiveText[i] = Left_InactiveText[i];

			// Set leftbar items to be unselected.
			LeftBar_Active[i].SetActive(false);
			LeftBar_ActiveText[i].SetActive(false);
		}

		for (int i = 0; i < 5; i++) {

			// Initialize graph Y-axis numbers.
			ULTRA_YAXIS[i] = ULTRA_AXIS[i];
			EXTENSIVE_YAXIS[i] = EXTENSIVE_AXIS[i];
			INTERMEDIATE_YAXIS[i] = INTERMEDIATE_AXIS[i];
			POOR_YAXIS[i] = POOR_AXIS[i];

			// Set graph Y-axis numbers to be hidden.
			ULTRA_YAXIS[i].SetActive(false);
			EXTENSIVE_YAXIS[i].SetActive(false);
			INTERMEDIATE_YAXIS[i].SetActive(false);
			POOR_YAXIS[i].SetActive(false);
		}

		// Initialize Message Box.
		Message_Body = Body;
		Message_Button_Pressed = Button_Pressed;
		Message_Button_Released = Button_Released;

		for (int i = 0; i < 3; i++)
		{
			Message_Button_Texts[i] = Button_Texts[i];
		}

		// Hide Message. (This functionality is used in other script files, so it is implemented as a function.)
		HideMessageBox ();

		// Initialize reset button.
		Background_Released = Released_Bg;
		Text_Released = Released_Text;
		Background_Pressed = Pressed_Bg;
		Text_Pressed = Pressed_Text;

		// Set reset button to be unselected.
		Background_Pressed.SetActive (false);
		Text_Pressed.SetActive (false);
	}

	// Function to show MessageBox.
	// Parameter: Text_ID
	// 0: "This inhibitor is already selected"
	// 1: "Maximum 2 inhibitors can be selected"
	// 2: "Please select the metabolizer first"
	public static void ShowMessageBox(int Text_ID)
	{
		Message_Body.SetActive (true);
		Message_Button_Released.SetActive (true);
		Message_Button_Texts [Text_ID].SetActive (true);
	}

	// Function to hide MessageBox.
	public static void HideMessageBox()
	{
		Message_Body.SetActive (false);
		Message_Button_Pressed.SetActive (false);
		Message_Button_Released.SetActive (false);

		for (int i = 0; i < 3; i++) {
			Message_Button_Texts[i].SetActive(false);
		}
	}

	// Function to show proper Y-axis numbers.
	// Parameter: index
	// 0: UM, 1: EM, 2: IM, 3: PM
	public static void SetYAxis(int index)
	{
		for (int i = 0; i < 5; i++)
		{
			ULTRA_YAXIS[i].SetActive(false);
			EXTENSIVE_YAXIS[i].SetActive(false);
			INTERMEDIATE_YAXIS[i].SetActive(false);
			POOR_YAXIS[i].SetActive(false);

			if (index == 0)
				ULTRA_YAXIS[i].SetActive(true);
			else if (index == 1)
				EXTENSIVE_YAXIS[i].SetActive(true);
			else if (index == 2)
				INTERMEDIATE_YAXIS[i].SetActive(true);
			else if (index == 3)
				POOR_YAXIS[i].SetActive(true);
		}
	}

	// Function to show graph legend.
	// Parameter: index
	// 0: UM, 1: EM, 2: IM, 3: PM
	public static void ShowGraphLegend(int index)
	{
		for (int i = 0; i < 4; i++)
		{
			MS[i].SetActive(false);
			M_IN_1S[i].SetActive(false);
			M_IN_2S[i].SetActive(false);
			M_IN_1_2S[i].SetActive(false);

			if (index == i)
			{
				MS[i].SetActive(true);
				M_IN_1S[i].SetActive(true);
				M_IN_2S[i].SetActive(true);
				M_IN_1_2S[i].SetActive(true);
			}
		}
	}

	// Function to reset leftbar. (All the items in the leftbar will be shown as unselected.)
	public static void ResetLeftBar()
	{
		for (int i = 0; i < 12; i++) {
			LeftBar_Active[i].SetActive(false);
			LeftBar_ActiveText[i].SetActive(false);
			LeftBar_Inactive[i].SetActive(true);
			LeftBar_InactiveText[i].SetActive(true);
		}
	}

	void Update () {
	
	}

	// Function to set topbar. (All the items in the topbar will be shown as unselected.)
	// Parameter: index(which item should be selected).
	// 0: ULTRARAPID 1: EXTENSIVE 2: INTERMEDIATE 3: POOR.

	public static void SetTopBar(int index)
	{
		for (int i = 0; i < 4; i++) {
			TopBar_Active[i].SetActive(false);
			TopBar_ActiveText[i].SetActive(false);
			TopBar_InactiveText[i].SetActive(true);

			if (i == index)
			{
				TopBar_Active[i].SetActive(true);
				TopBar_ActiveText[i].SetActive(true);
				TopBar_InactiveText[i].SetActive(false);
			}
		}
	}
}
