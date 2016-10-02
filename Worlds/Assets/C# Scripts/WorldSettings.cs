		using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldSettings : MonoBehaviour
{

	public int randomnessDegree;
	public List<GameObject> Layers = new List<GameObject> ();
	public int turnLimit;
	int randomAllowance;
	int turns;
	bool shifting = false;
	bool tappedLayer = false;
	bool clockwise = false;
	public bool busy = false;
	RaycastHit touchHit;
	GameObject managerObject;
	Vector2 touchDeltaPosition;
	float defaultTime = 9;
	float currentTime = 9;



	// Use this for initialization
	void Start ()
	{
		managerObject = GameObject.FindGameObjectWithTag ("Manager");
		randomAllowance = randomnessDegree;
		randomizeWorld ();
		turns = turnLimit;
	}


	void randomizeWorld ()
	{
		int spinsPerLayer = randomnessDegree / Layers.Count;
		foreach (GameObject layer in Layers) {
			if (randomAllowance != 0) {
				for (int i = 0; i <= spinsPerLayer; i++) {
					if (Random.Range (0, 100) > 50) {
						layer.GetComponent<Layer> ().rotateClockwiseInitialise ();
					} else {
						layer.GetComponent<Layer> ().rotateCounterClockwiseInitialise ();
					}
					randomAllowance--;
				}
			} else {
				break;
			}
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if(busy==false){
			if (shifting == false) {
				if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
					Ray touchRay = Camera.main.ScreenPointToRay (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 0));
					if (Physics.Raycast (touchRay, out touchHit) && touchHit.transform.tag == "Layer") {
						managerObject.GetComponent<Manager> ().setCurrentLayer (touchHit.transform.GetComponent<Layer> ().returnLayerNo ());
						tappedLayer = true;
					}
				}

				if(tappedLayer==true){
					if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
						touchDeltaPosition = Input.GetTouch (0).deltaPosition;
						float touchDeltaX = Input.GetTouch (0).deltaPosition.x;
						float touchDeltaY = Input.GetTouch (0).deltaPosition.y;
						Layers [managerObject.GetComponent<Manager> ().returnCurrentLayer () - 1].GetComponent<Layer> ().setOriginalAngle();
						if (touchDeltaX > 0 && touchDeltaY < 1 && touchDeltaY > -1) {
							Layers [managerObject.GetComponent<Manager> ().returnCurrentLayer () - 1].GetComponent<Layer> ().transform.Rotate (new Vector3 (0, 0, 1), -touchDeltaX*16);
						}
						if (touchDeltaX < 0 && touchDeltaY < 1 && touchDeltaY > -1) {
							Layers [managerObject.GetComponent<Manager> ().returnCurrentLayer () - 1].GetComponent<Layer> ().transform.Rotate (new Vector3 (0, 0, 1), -touchDeltaX*16);
						}
					}
					if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
							Layers [managerObject.GetComponent<Manager> ().returnCurrentLayer () - 1].GetComponent<Layer> ().rotateTowardsNearestAngle();
						tappedLayer = false;
					}
				}
				} else {
					if (currentTime > 0) {
						if (clockwise == true) {
							Layers [managerObject.GetComponent<Manager> ().returnCurrentLayer () - 1].GetComponent<Layer> ().rotateClockwise ();
						} else {
							Layers [managerObject.GetComponent<Manager> ().returnCurrentLayer () - 1].GetComponent<Layer> ().rotateCounterClockwise ();
						}
						currentTime--;
					} else {
						currentTime = defaultTime;
						shifting = false;
						decreaseTurns ();
					}
				}
		}	
	}


	public void decreaseTurns ()
	{
		turns--;
		if (turns == 0) {
			Application.Quit ();
		}
	}

	public List<GameObject> returnLayers ()
	{
		return Layers;
	}

	public int returnTurns ()
	{
		return turns;
	}

	public void setShift(bool shiftVal){
		shifting = shiftVal;
	}
}
