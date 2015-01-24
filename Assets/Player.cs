using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {
	
	public CharacterControllerThirdPerson body;
	
	public float health;
	public int points;
	public float coolDownTimeOne;
	public float coolDownTimeTwo;
	
	private float coolDownOneTimer;
	private float coolDownTwoTimer;
	
	public void dealDamage(float damage) {
		this.health = this.health - damage;
		if (this.health <= 0) {
			//game over		
		}
	}
	
	public virtual void doSpecialOne() {
		if (coolDownOneTimer >= coolDownTimeOne) {
			// do the action	
			coolDownOneTimer = 0;
		}
	} 
	public virtual void doSpecialTwo() {
		if (coolDownTwoTimer >= coolDownTimeTwo) {
			// do the action
			coolDownTwoTimer = 0;
		}
	} 
	

	public void Update() {
		updateTimers();
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