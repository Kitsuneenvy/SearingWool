using UnityEngine;
using System.Collections;

enum direction : int {down = 0, left = 90, up = 180, right = 270};

public class Layer : MonoBehaviour {


	int layerNo = 0;
	GameObject managerObject;
	GameObject worldObject;
	WorldSettings worldSettingsObject;
	int nearestDirection = 0;
	int newAngle = 0;
	int originalAngle = 0;
	Vector3 target = new Vector3(270,0,0);
	bool lerping = false;

	// Use this for initialization
	void Start () {
		nearestDirection = (int)direction.down;
		managerObject = GameObject.FindGameObjectWithTag("Manager");
		worldObject = GameObject.FindGameObjectWithTag("WorldObject");
		worldSettingsObject = worldObject.GetComponent<WorldSettings>();
		foreach(GameObject layer in worldSettingsObject.Layers){
			if(layer.name == this.name){
				layerNo = worldSettingsObject.Layers.IndexOf(layer);
				layerNo +=1;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			rotateTowardsNearestAngle();
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			setOriginalAngle();
		}
		if(lerping == true){
			if(Vector3.Distance(transform.eulerAngles,target) > 0.05f){
				transform.eulerAngles = Vector3.Lerp(transform.localRotation.eulerAngles,target,0.5f);
				worldSettingsObject.busy = true;
			} else {
				transform.eulerAngles = target;
				lerping = false;
				worldSettingsObject.busy = false;
				if(newAngle!=originalAngle){
					worldSettingsObject.decreaseTurns();
				}
			}
		}
	}

	public int returnLayerNo(){
		return layerNo;
	}

	public void rotateClockwise(){
		//transform.RotateAround(worldObject.transform.position,Vector3.up,90);
		transform.Rotate(new Vector3(0, 0, 1), 2);
	}

	public void rotateCounterClockwise(){
		//transform.RotateAround(worldObject.transform.position,Vector3.up,-90);
		transform.Rotate(new Vector3(0, 0, 1), -2);
	}

	public void rotateCounterClockwiseInitialise(){
		transform.Rotate(new Vector3(0, 0, 1), -45);
	}
	public void rotateClockwiseInitialise(){
		transform.Rotate(new Vector3(0, 0, 1), 45);
	}

	void findNearestAngle(){
		if(transform.eulerAngles.y>315&& transform.eulerAngles.y<360){
			nearestDirection = 0;
		} 
		if (transform.eulerAngles.y>270 && transform.eulerAngles.y<315){
			nearestDirection = 270;
		} 
		if (transform.eulerAngles.y>225 && transform.eulerAngles.y<270){
			nearestDirection = 270;
		} 
		if (transform.eulerAngles.y>180 && transform.eulerAngles.y<225){
			nearestDirection = 180;
		} 
		if (transform.eulerAngles.y>135 && transform.eulerAngles.y<180){
			nearestDirection = 180;
		} 
		if (transform.eulerAngles.y>90 && transform.eulerAngles.y<135){
			nearestDirection = 90;
		} 
		if (transform.eulerAngles.y>45 && transform.eulerAngles.y<90){
			nearestDirection = 90;
		} 
		if (transform.eulerAngles.y>0 && transform.eulerAngles.y<45){
			nearestDirection = 0;
		}
	}

	public void rotateTowardsNearestAngle(){
		findNearestAngle();
		target = new Vector3(270,nearestDirection,0);
		newAngle = nearestDirection;
		int distanceToRotate = (int)transform.eulerAngles.y-(int)nearestDirection;
		if(transform.eulerAngles.y == 0||transform.eulerAngles.y == 90||transform.eulerAngles.y == 180||transform.eulerAngles.y == 270||transform.eulerAngles.y == 360){
			return;
		} else {
			lerping = true;
		}
	}

	public void setOriginalAngle(){
		originalAngle = (int)transform.eulerAngles.y;
		Debug.Log(originalAngle.ToString());
	}
}
