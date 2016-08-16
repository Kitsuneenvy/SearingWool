using UnityEngine;
using System.Collections;

public class Layer : MonoBehaviour {


	int layerNo = 0;
	GameObject managerObject;
	GameObject worldObject;
	WorldSettings worldSettingsObject;

	// Use this for initialization
	void Start () {
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
	void Update () {
	
	}

	public int returnLayerNo(){
		return layerNo;
	}

	public void rotateClockwise(){
		//transform.RotateAround(worldObject.transform.position,Vector3.up,90);
		transform.Rotate(new Vector3(0, 0, 1), 5);
	}

	public void rotateCounterClockwise(){
		//transform.RotateAround(worldObject.transform.position,Vector3.up,-90);
		transform.Rotate(new Vector3(0, 0, 1), -5);
	}

	public void rotateCounterClockwiseInitialise(){
		transform.Rotate(new Vector3(0, 0, 1), -45);
	}
	public void rotateClockwiseInitialise(){
		transform.Rotate(new Vector3(0, 0, 1), 45);
	}
}
