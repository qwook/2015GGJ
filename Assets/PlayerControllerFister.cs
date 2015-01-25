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

	//initial health / points
	public float health;
	public int points;

	//how far in front should we detect collision
	public float punchLength;

	private float coolDownOneTimer;
	private float coolDownTwoTimer;




	
	
	float forwardSpeed = 0.0f;
	float sideSpeed = 0.0f;
	Vector3 gravity = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		float verticalAmount = Input.GetAxis (horizontalAxis);
		float horizontalAmount = -Input.GetAxis (verticalAxis);

		if (verticalAmount != 0 || horizontalAmount != 0) {
			print (verticalAmount + " " + horizontalAmount);
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
		
		Animator animator = GetComponent<Animator>();
		animator.SetFloat ("Speed", (forwardSpeed + sideSpeed));
		
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
				doActionOne();
				bool didHit = traceHit();
				coolDownOneTimer = 0;
			}
			
		}
		
		if (Input.GetButtonDown (action2)) {
			if (coolDownOneTimer >= coolDownTimeOne) {
				doActionTwo();	
				coolDownTwoTimer = 0;
			}
		}
		
	}

	void doActionOne() {

	}

	void doActionTwo() {
		
	}

	bool traceHit() {
		RaycastHit hit;;
		Vector3 direction = transform.rotation.eulerAngles.normalized;
		int mask = 1 << 8;
		Physics.Raycast(transform.localPosition, direction, out hit, punchLength, mask);
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
