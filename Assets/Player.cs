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
	

	public virtual void doSpecialOne() {} 
	public virtual void doSpecialTwo() {} 

	void Initialize() {

	}

	public void Update() {

	}


}
