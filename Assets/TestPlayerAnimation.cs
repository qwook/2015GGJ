using UnityEngine;
using System.Collections;

public class TestPlayerAnimation : MonoBehaviour {

	float forwardSpeed = 0.0f;
	Vector3 gravity = Vector3.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Vertical") > 0) {
			transform.rotation = Quaternion.LookRotation (Vector3.forward);
		} else if (Input.GetAxis ("Vertical") < 0) {
			transform.rotation = Quaternion.LookRotation (-Vector3.forward);
		}

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
