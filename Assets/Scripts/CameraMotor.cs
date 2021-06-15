using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	private float transition = 0.0f;
	private float animDuration = 2.0f;
	private Vector3 animOffset = new Vector3(0, 3, 3);

	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + startOffset;
		//X
		moveVector.x = 0;
		//Y
		moveVector.y = Mathf.Clamp (moveVector.y, 3.0f, 10.0f);
		//Z

		if (transition > 1.0f) {
			transform.position = moveVector;
		} 
		else {
			transform.position = Vector3.Lerp(moveVector + animOffset, moveVector, transition);
			transition +=Time.deltaTime * 1 / animDuration;
			transform.LookAt(lookAt.position + Vector3.up);
		}
		//transform.position = moveVector;
	}
}
