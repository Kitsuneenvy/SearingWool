using UnityEngine;
using System.Collections;

public class RotateLayer : MonoBehaviour {

	
	Vector2 touchDeltaPosition;
	GameObject managerObject;
	GameObject worldObject;
	WorldSettings worldSettingsObject;
    bool shifting = false;
    bool clockwise = false;
    float defaultTime = 30;
    float currentTime = 30;


	// Use this for initialization
	void Start () {
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		worldObject = GameObject.FindGameObjectWithTag("WorldObject");
		worldSettingsObject = worldObject.GetComponent<WorldSettings>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			rotateCounterClockwise();
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			rotateClockwise();
		}
		if(managerObject.GetComponent<Manager>().rotateCamera == false && this.name.Contains(managerObject.GetComponent<Manager>().returnCurrentLayer().ToString())){
            if (shifting == false)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    float touchDeltaX = Input.GetTouch(0).deltaPosition.x;
                    float touchDeltaY = Input.GetTouch(0).deltaPosition.y;
                    if (touchDeltaX > 0 && touchDeltaY < 1 && touchDeltaY > -1)
                    {
                        shifting = true;
                        clockwise = false;
                    }
                    if (touchDeltaX < 0 && touchDeltaY < 1 && touchDeltaY > -1)
                    {
                        shifting = true;
                        clockwise = true;
                    }
                }
            }
            else
            {
                if (currentTime > 0)
                {
                    if (clockwise == true)
                    {
                        rotateClockwise();
                    }
                    else
                    {
                        rotateCounterClockwise();
                    }
                    currentTime --;
                }
                else
                {
                    currentTime = defaultTime;
                    shifting = false;
                    worldSettingsObject.decreaseTurns();
                }
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
