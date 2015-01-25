using UnityEngine;
public class Damagable : MonoBehaviour
{
	public float health;
	public int points;
	public int[] hitPoints = {12,20,30};
	private Animator animator;
	public bool dead;

	public AudioClip hitsound;
	public AudioClip deathsound;
	
	
	private AudioSource source;
	private float lowPitchRange = .75F;
	private float highPitchRange = 1.5F;
	private float velToVol = .6F;
	private float velocityClipSplit = 10F;

	void Start() {
		source = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		dead = false;
	}

	void Update() {
	}



	public int dealDamage(float damage) {
		health -= damage;
		if(this.health <= 0) {
			source.PlayOneShot(deathsound, velToVol);
			animator.SetBool ("Death", true);
			dead = true;
//			Destroy(gameObject);
			print("destroy");
			return points;
		} else {
			source.PlayOneShot(hitsound, velToVol);
			animator.SetTrigger ("Hit");
			print ("hit");
			return hitPoints[Random.Range(0,hitPoints.Length)];

		} 
	}



	
		
}


