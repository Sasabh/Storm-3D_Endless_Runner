using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Animator anim;
	private Vector3 moveVector;
	private float verticalVelocity = 0.0f;
	private float gravity = 10.0f;
	private float speed = 5.0f;
	private float animDuration = 2.0f;
	private bool isDead = false;
	void Start () {
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead == true)
			return;

		if (Time.time < animDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
		
		moveVector = Vector3.zero;

		if(controller.isGrounded){
			verticalVelocity = -0.5f;
		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}
		moveVector = Vector3.zero;
		//X
		moveVector.x = Input.GetAxisRaw ("Horizontal") * speed;
		//Y
		moveVector.y = verticalVelocity;
		//Z
		moveVector.z = speed;
		controller.Move (moveVector * Time.deltaTime);

//		if(Input.GetKeyDown(KeyCode.Space)){
//			Vector3 position = this.transform.position;
//			position.y=(position.y)+ 2.5f;
//			this.transform.position = position;
//			//anim.Play("JUMP00");
//		}
		
	}

	public void SetSpeed(float modifier){
		speed = 5.0f + modifier;
	}

	//Called when player hita something
	private void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.point.z > transform.position.z + controller.radius)
			Death ();
	}
	private void Death(){
		isDead = true;
		GetComponent<Score> ().OnDeath ();
	}

}
