using UnityEngine;
public class Damagable : MonoBehaviour
{
	public float health;
	public int points;
	private Animator animator;
	public bool dead;

	void Start() {
		animator = GetComponent<Animator>();
		dead = false;
	}

	void Update() {
	}



	public int dealDamage(float damage) {
		health -= damage;
		if(this.health <= 0) {
			animator.SetBool ("Death", true);
			dead = true;
//			Destroy(gameObject);
			print("destroy");
			return points;
		} else {
			animator.SetBool ("Hit", true);
			print ("hit");
			return 0;
		} 
	}



	
		
}


