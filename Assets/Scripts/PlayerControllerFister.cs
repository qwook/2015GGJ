using UnityEngine;
using System.Collections;

public class PlayerControllerFister : MonoBehaviour {
	
	public Camera camera;

	//input 
	public string horizontalAxis;
	public string verticalAxis;
	public string action1;
	public string action2;

	//cooldown between hits
	public float coolDownTimeOne;
	public float coolDownTimeTwo;
	

	//how far in front should we detect collision
	public float punchLength;
	public Vector3 punchHeight;

	private float coolDownOneTimer;
	private float coolDownTwoTimer;


	private Animator animator;




	
	
	float forwardSpeed = 0.0f;
	float sideSpeed = 0.0f;
	Vector3 gravity = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {



		float verticalAmount = Input.GetAxis (horizontalAxis);
		float horizontalAmount = -Input.GetAxis (verticalAxis);

		if (verticalAmount != 0 || horizontalAmount != 0) {
			transform.rotation = Quaternion.LookRotation (((Vector3.forward * verticalAmount)+(Vector3.right * horizontalAmount)));
		}

		if (Mathf.Abs (verticalAmount) > 0) {
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

		if (Mathf.Abs (horizontalAmount) > 0) {
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
		

		animator.SetFloat ("Speed", (forwardSpeed + sideSpeed));

//		transform.forward += Vector3.forward * (forwardSpeed);
		
		CharacterController characterController = GetComponent<CharacterController> ();
		gravity = Physics.gravity * Time.fixedDeltaTime;
		if ((characterController.collisionFlags & CollisionFlags.CollidedBelow) != 0) {
			gravity = Vector3.zero;
		}
		characterController.Move (gravity);


		//punching
		updateTimers ();
		if (Input.GetButtonDown (action1)) {
			if (coolDownOneTimer >= coolDownTimeOne) {
				bool didHit = traceHit();
				coolDownOneTimer = 0;
				animator.SetBool ("Punch", true);
			}
		} else {
			animator.SetBool ("Punch", false);
		}
		
		if (Input.GetButtonDown (action2)) {
			if (coolDownTwoTimer >= coolDownTimeTwo) {
				bool didHit = traceHit();
				coolDownTwoTimer = 0;
				animator.SetBool ("Punch2", true);
			}
		} else {
			animator.SetBool ("Punch2", false);
		}
		animator.SetBool ("Hit", Input.GetKey ("f"));
	}
	

	bool traceHit() {
		RaycastHit hit;;
		Vector3 direction = transform.rotation * Vector3.forward;
		int mask = 1 << 8;
		print (direction + " " + direction);
		Debug.DrawRay(transform.position + punchHeight, direction * punchLength, Color.red, 3f);
		if (Physics.Raycast (transform.position + punchHeight, direction, out hit, punchLength, mask)) {

			print ("hit");		
		} else {
			print ("didn't hit");
		}
//		print (hit);
		return true;
	}

	private void updateTimers() {
		if (coolDownOneTimer < coolDownTimeOne){
			coolDownOneTimer += Time.deltaTime;

		}
		if (coolDownTwoTimer < coolDownTimeTwo){
			coolDownTwoTimer += Time.deltaTime;

		}
	}
}
