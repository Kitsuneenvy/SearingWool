using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	Vector2 touchDeltaPosition;
	GameObject managerObject;
	GameObject worldObject;
	WorldSettings worldSettingsObject;
	bool shifting = false;
	bool clockwise = false;
	float defaultTime = 30;
	float currentTime = 30;
	int layerNo = 0;
	RaycastHit touchHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			Ray touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(touchRay, out touchHit)&&touchHit.transform.tag=="Layer"){
				Debug.Log(layerNo.ToString());
				managerObject.GetComponent<Manager>().setCurrentLayer(layerNo);

			}
		}
	
	}
	public void rotateClockwise(){
		//transform.RotateAround(worldObject.transform.position,Vector3.up,90);
		transform.Rotate(new Vector3(0, 0, 1), 3);
	}

	public void rotateCounterClockwise(){
		//transform.RotateAround(worldObject.transform.position,Vector3.up,-90);
		transform.Rotate(new Vector3(0, 0, 1), -3);
	}
}
