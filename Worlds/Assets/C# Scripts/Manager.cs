using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	GameObject worldSettingsObject;
	int stage;
	public bool rotateCamera = false;
	public Texture cameraIcon;
	public Texture rotateIcon;
	public int currentLayer = 1;
	string debugString = "";
	public Texture2D counterBackground = null;
	public Texture2D pauseButton = null;
	public Texture2D playButton = null;
	Rect counterRect = new Rect(0,0,0,0);
	Rect pauseRect = new Rect(0,0,0,0);
	Rect menuRect = new Rect(0,0,0,0);
	bool menuOpen = false;
	public GUIStyle counterFont;
	public float sensitivityValue = 1;


	// Use this for initialization
	void Start () {
		counterRect.width = counterBackground.width;
		counterRect.height = counterBackground.height;
		pauseRect.x = counterBackground.width;
		pauseRect.width = pauseButton.width;
		pauseRect.height = pauseButton.height;
		menuRect.x = Screen.width/3;
		menuRect.y = Screen.height/5;
		menuRect.width = Screen.width/2;
		menuRect.height = Screen.height/3;
		worldSettingsObject = GameObject.FindGameObjectWithTag("WorldObject");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnGUI() {
		if(!menuOpen){
			GUI.Label(counterRect,counterBackground,counterFont);
			GUI.Label(counterRect, worldSettingsObject.GetComponent<WorldSettings>().returnTurns().ToString(),counterFont);
			if(GUI.Button(pauseRect,pauseButton,counterFont)){
				menuOpen=true;
			}
		} else {
			GUI.Window(0,menuRect,menuFunction,"Menu");
		}
//		GUILayout.BeginHorizontal();
//		GUILayout.Label(counterBackground);
//		GUILayout.Label("Remaining turns : " + worldSettingsObject.GetComponent<WorldSettings>().returnTurns().ToString());
//		GUILayout.EndHorizontal();
	}

	void menuFunction(int id){
		GUILayout.BeginVertical();
		if(GUILayout.Button(playButton)){
			menuOpen = false;
		}
		sensitivityValue = GUILayout.HorizontalSlider(sensitivityValue,0.5f,2);
		GUILayout.Label("Sensitivity = " + sensitivityValue.ToString());
		if(GUILayout.Button("Quit")){
			Application.Quit();
		}
		GUILayout.EndVertical();

	}
	public int returnCurrentLayer(){
		return currentLayer;
	}

	public void setCurrentLayer(int x){
		currentLayer = x;
	}
	public void setDebugString(string x){
		debugString = x;
	}

	public void toggleMenu(bool open){
		menuOpen = open;
	}
	
}
