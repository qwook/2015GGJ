using UnityEngine;
using System.Collections;

public class PlayTheVideo : MonoBehaviour {
//
//	//the GUI texture  
//	private GUITexture videoGUItex;  
//	//the Movie texture  
//	private MovieTexture mTex;  
//	//the AudioSource  
//	private AudioSource movieAS;  
//	//the movie name inside the resources folder  
//	public string movieName = "film";  
//	
	bool hasPlayed = false;

	bool showingStoryboard = false;
	float showingStoryboardTime = 1.0f;

	void Awake() {

	}
	
	//On Script Start  
	void Start()  
	{  
//		//set the videoGUItex.texture to be the same as mTex  
//		videoGUItex.texture = mTex;  
//		//Plays the movie  
//		mTex.Play();  
//		//plays the audio from the movie  
//		movieAS.Play();  
		MovieTexture texture = (MovieTexture) renderer.material.mainTexture;
		texture.Play ();
		AudioClip audioClip = (AudioClip)texture.audioClip;
		AudioSource audioSource = GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
		audioSource.Play ();
	}

	void Update()
	{
		MovieTexture texture = (MovieTexture) renderer.material.mainTexture;
		if (texture.isPlaying) {
			hasPlayed = true;
		}
		if (hasPlayed == true && !texture.isPlaying) {
			if (showingStoryboard == false) {
				showingStoryboard = true;
				showingStoryboardTime = 2.0f;
				GameObject storyBoard = GameObject.Find ("StoryBoard");
				storyBoard.transform.position = new Vector3(0, 6.5f, 0);
			}
		}

		if (showingStoryboard) {
			if (showingStoryboardTime < 0) {
				Application.LoadLevel ("Level1");
			} else {
				showingStoryboardTime -= Time.deltaTime;
			}
		}

	}
}
