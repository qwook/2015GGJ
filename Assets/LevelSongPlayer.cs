using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSongPlayer : MonoBehaviour {
	

	

	//	public AudioClip introSong;
	private AudioSource source;
	private float lowPitchRange = .75F;
	private float highPitchRange = 1.5F;
	private float velToVol = .6F;
	private float velocityClipSplit = 10F;
	

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		//		source.PlayOneShot (introSong);
		source.Play ();
	}

}

