using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {
	
	public CharacterControllerThirdPerson body;
	
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
	
	public void dealDamage(float damage) {
		this.health = this.health - damage;
		if (this.health <= 0) {
			//game over		
		}
	}

	public virtual void doSpecialOne() {} 
	public virtual void doSpecialTwo() {} 

	void Initialize() {

	}

	public void Update() {

		updateTimers ();
		if (Input.GetButtonDown ("Action1")) {
			if (coolDownOneTimer >= coolDownTimeOne) {
				doSpecialOne();	
				coolDownOneTimer = 0;
			}
			
		}
		
		if (Input.GetButtonDown ("Action2")) {
			if (coolDownOneTimer >= coolDownTimeOne) {
				doSpecialOne();	
				coolDownOneTimer = 0;
			}
		}
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
