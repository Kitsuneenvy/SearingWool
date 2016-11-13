using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {


	Vector2 touchDeltaPosition;

	public GameObject sun;

	RaycastHit touchHit;
	GameObject managerObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(sun.transform);


		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Ray touchRay = Camera.main.ScreenPointToRay (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 0));
			if (Physics.Raycast (touchRay, out touchHit) && touchHit.transform.tag == "World") {
				Application.LoadLevel(touchHit.transform.name);
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			float touchDeltaX = Input.GetTouch (0).deltaPosition.x;
			if(touchDeltaX!=0){
				this.transform.RotateAround(sun.transform.position,Vector3.up,touchDeltaX*0.1f);
			}
//			if (touchDeltaX > 0) {
//				//this.transform.Translate(Vector3.right*touchDeltaX*0.1f);
//				this.transform.RotateAround(sun.transform.position,Vector3.up,touchDeltaX*10);
//			}
//			if (touchDeltaX < 0) {
//
//				//this.transform.position += this.transform.TransformDirection(Vector3.right*touchDeltaX*0.1f);
//			}
		} 
		if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended){
			Ray touchRay = Camera.main.ScreenPointToRay (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 0));
			if (Physics.Raycast (touchRay, out touchHit) && touchHit.transform.tag == "World") {
				Application.LoadLevel(touchHit.transform.name);
			}
		}
	}
}
