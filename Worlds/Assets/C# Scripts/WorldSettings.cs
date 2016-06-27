using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldSettings : MonoBehaviour {

	public int randomnessDegree;
	public List<GameObject> Layers = new List<GameObject>();
	public int turnLimit;
	int randomAllowance;
	int turns;



	// Use this for initialization
	void Start () {
		randomAllowance = randomnessDegree;
		randomizeWorld();
		turns = turnLimit;
	}


	void randomizeWorld (){
		int spinsPerLayer = randomnessDegree/Layers.Count;
		foreach(GameObject layer in Layers){
			if (randomAllowance!=0){
				for(int i = 0; i<=spinsPerLayer; i++){
					if(Random.Range(0,100)>50){
						layer.GetComponent<RotateLayer>().rotateClockwise();
					} else {
						layer.GetComponent<RotateLayer>().rotateCounterClockwise();
					}
					randomAllowance--;
				}
			} else {
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void decreaseTurns(){
		turns--;
	}
	public List<GameObject> returnLayers(){
		return Layers;
	}
	public int returnTurns(){
		return turns;
	}
}
