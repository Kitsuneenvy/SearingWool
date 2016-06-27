using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	Vector2 touchDeltaPosition;
	public GameObject viewTarget;
	GameObject managerObject;


	// Use this for initialization
	void Start () {
		managerObject=GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(viewTarget.transform);
		if(managerObject.GetComponent<Manager>().rotateCamera == true){
			if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved){

				touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				float touchDeltaX = Input.GetTouch(0).deltaPosition.x;
				float touchDeltaY = Input.GetTouch(0).deltaPosition.y;

				transform.RotateAround(viewTarget.transform.position,Vector3.up,touchDeltaX * 50 * Time.deltaTime);
				transform.RotateAround(viewTarget.transform.position,Vector3.left,touchDeltaY * 50 * Time.deltaTime);
			}
			if(Input.touchCount == 2){
				Touch firstTouch = Input.GetTouch(0); //Save the touches
				Touch secondTouch = Input.GetTouch(1);

				Vector2 firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;  //Find the position of the touches since last frame
				Vector2 secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

				float touchDeltaMagnitude = (firstTouchPrevPos - secondTouchPrevPos).magnitude; //See if the touches are moving closer or farther away
				float touchMagnitude = (firstTouch.position - secondTouch.position).magnitude;

				float magnitudeDifference = touchDeltaMagnitude - touchMagnitude;

				Camera.main.GetComponent<Camera>().fieldOfView += magnitudeDifference * 0.5f;
				Camera.main.GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);


			}
		}
	}


}
