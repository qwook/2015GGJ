using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutSceneManager : MonoBehaviour {
	
	public string SceneToLoad;


//	public GameObject movie;
	private float interval = 0.5f;
	private float timer = 0f;
	private bool on = false;
	
	public bool flashing = false;
	
	//	public AudioClip introSong;
	private AudioSource source;
	private float lowPitchRange = .75F;
	private float highPitchRange = 1.5F;
	private float velToVol = .6F;
	private float velocityClipSplit = 10F;
	
	public Text text;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		//		source.PlayOneShot (introSong);
//		source.Play ();

//		movie.renderer.material.
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel(SceneToLoad);	
		}
		
		if(flashing) {
			timer += Time.deltaTime;
			if(timer > interval) {
				if(on) {
					text.enabled = false;
					on = false;
				} else {
					text.enabled = true;
					on = true;
				}
				timer = 0f;
			}
		}
		
		
		
	}
}

