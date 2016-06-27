using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	GameObject worldSettingsObject;
	int stage;
	public bool rotateCamera = false;
	public Texture cameraIcon;
	public Texture rotateIcon;
	int currentLayer = 1;


	// Use this for initialization
	void Start () {
		worldSettingsObject = GameObject.FindGameObjectWithTag("WorldObject");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		GUILayout.BeginHorizontal();
		if(rotateCamera==true){
			if(GUILayout.Button(new GUIContent(rotateIcon))){
				rotateCamera = !rotateCamera;
			}
		} else {
			if(GUILayout.Button(new GUIContent(cameraIcon))){
				rotateCamera = !rotateCamera;
			}
		}
		if(GUILayout.Button("<-")){
			if(currentLayer>1){
				currentLayer--;
			}
		}
		GUILayout.Label(currentLayer.ToString());
		if(GUILayout.Button("->")){
			if(currentLayer<worldSettingsObject.GetComponent<WorldSettings>().Layers.Count){
				currentLayer++;
			}
		}
		GUILayout.Label("Remaining turns : " + worldSettingsObject.GetComponent<WorldSettings>().returnTurns().ToString());
		GUILayout.EndHorizontal();
	}

	public int returnCurrentLayer(){
		return currentLayer;
	}
	
}
