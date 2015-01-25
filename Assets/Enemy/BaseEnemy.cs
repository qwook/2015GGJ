using UnityEngine;
using System.Collections;
public class BaseEnemy : MonoBehaviour {
	

	public int punchingDistance;
	public int activateDistance;
	public float movementSpeed;
	public int slowDownDistance;
	public float slowDownSpeed;

	//cooldown between hits
	public float coolDownTimeOne;
	public float coolDownTimeTwo;
	
	
	//how far in front should we detect collision
	public float punchLength;
	public Vector3 punchHeight;
	
	private float coolDownOneTimer;
	private float coolDownTwoTimer;

	private bool activated = false;
	
	
	private Animator animator;
	
	
	private GameObject[] targets;
	private GameObject target;
	
	
	
	float forwardSpeed = 0.0f;
	float sideSpeed = 0.0f;
	Vector3 gravity = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		

		targets = GameObject.FindGameObjectsWithTag ("Player");

		if (targets.Length >= 1) {
			target = targets[0];
		} else {
			return;
		}
		for (int i = 1; i < targets.Length; i++) {	
			
			if((this.transform.position - targets[i].transform.position).sqrMagnitude > (this.transform.position - target.transform.position).sqrMagnitude) {
				target = targets[i];
			}
		}

		Vector3 towardsTarget = -(this.transform.position - target.transform.position);


		towardsTarget.y = 0;

		if(!activated && towardsTarget.sqrMagnitude > activateDistance) {

		} else {
			activated = true;
			print ("activated");
			transform.rotation = Quaternion.LookRotation (towardsTarget);
			if(towardsTarget.sqrMagnitude > 40) {
				if(towardsTarget.sqrMagnitude > slowDownDistance){
					animator.SetFloat ("Speed", slowDownSpeed);
				} else {
					animator.SetFloat ("Speed", movementSpeed);
				}
			}

		}
		
		CharacterController characterController = GetComponent<CharacterController> ();
		gravity = Physics.gravity * Time.fixedDeltaTime;
		if ((characterController.collisionFlags & CollisionFlags.CollidedBelow) != 0) {
			gravity = Vector3.zero;
		}
		characterController.Move (gravity);
		
		
		//punching

		if(towardsTarget.sqrMagnitude < punchingDistance) {

			updateTimers ();
			if (coolDownOneTimer >= coolDownTimeOne) {
				bool didHit = traceHit();
				coolDownOneTimer = 0;
				animator.SetBool ("Punch", true);
			} else {
				animator.SetBool ("Punch", false);
			}

			if (coolDownTwoTimer >= coolDownTimeTwo) {
				bool didHit = traceHit();
				coolDownTwoTimer = 0;
				animator.SetBool ("Punch2", true);
			} else {
				animator.SetBool ("Punch2", false);
			}
		}	
		
	}
	
	
	bool traceHit() {
		RaycastHit hit;;
		Vector3 direction = transform.rotation * Vector3.forward;
		int mask = 1 << 9;
//		print (direction + " " + direction);
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
