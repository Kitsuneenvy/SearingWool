using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

	GameObject thumbnailTarget;
	int currentThumbnail = 0;
	GameObject newTarget;
	Vector3 lerpTarget;
	public List<GameObject> thumbnails = new List<GameObject>();
	bool lerping = false;
	float initialDistance = 0;
	Vector2 touchDeltaPosition;
	public GameObject sun;

	// Use this for initialization
	void Start () {
		thumbnailTarget = thumbnails[currentThumbnail];
		transform.LookAt(thumbnailTarget.transform);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			float touchDeltaX = Input.GetTouch (0).deltaPosition.x;
			float touchDeltaY = Input.GetTouch (0).deltaPosition.y;
			if (touchDeltaX > 0 && touchDeltaY < 1 && touchDeltaY > -1) {
				if(currentThumbnail-1<0){
					currentThumbnail = thumbnails.Count-1;
				} else {
					currentThumbnail--;
				}
				thumbnailTarget = thumbnails[currentThumbnail];
				lerping = true;
				lerpTarget = thumbnailTarget.transform.position;
				initialDistance = Vector3.Distance(transform.position,lerpTarget);
			}
			if (touchDeltaX < 0 && touchDeltaY < 1 && touchDeltaY > -1) {
				if(currentThumbnail+1>=thumbnails.Count){
					currentThumbnail = 0;
				} else {
					currentThumbnail++;
				}
				thumbnailTarget = thumbnails[currentThumbnail];
				lerping = true;
				lerpTarget = thumbnailTarget.transform.position;
				initialDistance = Vector3.Distance(transform.position,lerpTarget);
			}
		}



		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(currentThumbnail+1>=thumbnails.Count){
				currentThumbnail = 0;
			} else {
				currentThumbnail++;
			}
			thumbnailTarget = thumbnails[currentThumbnail];
			lerping = true;
			lerpTarget = thumbnailTarget.transform.position;
			initialDistance = Vector3.Distance(transform.position,lerpTarget);
		}



		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(currentThumbnail-1<0){
				currentThumbnail = thumbnails.Count-1;
			} else {
				currentThumbnail--;
			}
			thumbnailTarget = thumbnails[currentThumbnail];
			lerping = true;
			lerpTarget = thumbnailTarget.transform.position;
			initialDistance = Vector3.Distance(transform.position,lerpTarget);
		}



		if(lerping){
			lerpTowardsNewTarget();
			if(Vector3.Distance(transform.position,lerpTarget)<0.5){
				lerping = false;
			}
		}
	}

	void lerpTowardsNewTarget(){
		lerpTarget = thumbnailTarget.transform.position;
		lerpTarget.x -= 5;
		lerpTarget.y += 5;
		float distanceRemaining = Vector3.Distance(transform.position,lerpTarget);
		float distanceTravelled = initialDistance-distanceRemaining;
		transform.position = Vector3.Lerp(transform.position,lerpTarget,(distanceTravelled/initialDistance)/10);
	}


}
