using UnityEngine;
using System.Collections;

public class TestPlayerAnimation : MonoBehaviour {

	public Camera camera;
	public string horizontalAxis;
	public string verticalAxis;
	public string action1;
	public string action2;


	float forwardSpeed = 0.0f;
	float sideSpeed = 0.0f;
	Vector3 gravity = Vector3.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float verticalAmount = Input.GetAxis ("Vertical");
		float horizontalAmount = Input.GetAxis ("Horizontal");

		transform.rotation = Quaternion.LookRotation ((Vector3.forward * verticalAmount)+(Vector3.right * horizontalAmount)/2);


//		if (Input.GetAxis ("Vertical") > 0) {
//			transform.rotation = Quaternion.LookRotation (Vector3.forward);
////			camera.transform.rotation = Quaternion.LookRotation (Vector3.forward);
//		} else if (Input.GetAxis ("Vertical") < 0) {
//			transform.rotation = Quaternion.LookRotation (-Vector3.forward);
////			camera.transform.rotation = Quaternion.LookRotation (-Vector3.forward);
//		}

		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
			if (forwardSpeed < 1.0f) {
				forwardSpeed += Time.fixedDeltaTime;
			} else {
				forwardSpeed = 1.0f;
			}
		} else {
			if (forwardSpeed > 0.0f) {
				forwardSpeed -= Time.fixedDeltaTime;
			} else {
				forwardSpeed = 0.0f;
			}
		}

//		if (Input.GetAxis ("Horizontal") > 0) {
//			transform.rotation = Quaternion.LookRotation (Vector3.right);
//			//			camera.transform.rotation = Quaternion.LookRotation (Vector3.forward);
//		} else if (Input.GetAxis ("Horizontal") < 0) {
//			transform.rotation = Quaternion.LookRotation (-Vector3.right);
//			//			camera.transform.rotation = Quaternion.LookRotation (-Vector3.forward);
//		}
		
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
			if (sideSpeed < 1.0f) {
				sideSpeed += Time.fixedDeltaTime;
			} else {
				sideSpeed = 1.0f;
			}
		} else {
			if (sideSpeed > 0.0f) {
				sideSpeed -= Time.fixedDeltaTime;
			} else {
				sideSpeed = 0.0f;
			}
		}

		Animator animator = GetComponent<Animator>();

		animator.SetFloat ("Speed", forwardSpeed);
		animator.SetBool ("Punch", Input.GetKey ("g"));
		animator.SetBool ("Punch2", Input.GetKey ("h"));

		CharacterController characterController = GetComponent<CharacterController> ();
		gravity = Physics.gravity * Time.fixedDeltaTime;
		if ((characterController.collisionFlags & CollisionFlags.CollidedBelow) != 0) {
			gravity = Vector3.zero;
		}
		characterController.Move (gravity);

	}
}
