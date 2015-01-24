using UnityEngine;

public class NPC : MonoBehaviour {
	
	public float health;
	public float attackRange;
	public float attackCoolDown;
	public Player player;
	private float attackCoolDownTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0){
			Destroy(this); // Do death animaiton etc instead
		}
		Vector3 v1 = Vector3.Normalize (player.transform.position - transform.position) * Time.deltaTime;
		Vector3 v2 = new Vector3 (1, 0, 1);
		transform.Translate(Vector3.Scale(v1,v2));
		attackCoolDownTimer += Time.deltaTime;
		if(Vector3.Distance(transform.position, player.transform.position) <= attackRange){
			if(attackCoolDownTimer >= attackCoolDown){
				attack ();
				attackCoolDownTimer = 0;
			}
		}
	}

	private void attack(){

	}
}
