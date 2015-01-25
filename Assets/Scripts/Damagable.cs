using UnityEngine;
public class Damagable : MonoBehaviour
{
	public float health;
	public int points;


	void Start() {

	}

	void Update() {

	}

	public int dealDamage(float damage) {
		health -= damage;
		if(this.health <= 0) {
			Destroy(gameObject);
			print("destroy");
			return points;
		} else {
			return 0;
		} 
	}

	
		
}


