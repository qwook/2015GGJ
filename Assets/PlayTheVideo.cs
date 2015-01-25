using UnityEngine;
using System.Collections;

public class PlayTheVideo : MonoBehaviour {

	//the GUI texture  
	private GUITexture videoGUItex;  
	//the Movie texture  
	private MovieTexture mTex;  
	//the AudioSource  
	private AudioSource movieAS;  
	//the movie name inside the resources folder  
	public string movieName = "film";  
	
	void Awake() {

	}
	
	//On Script Start  
	void Start()  
	{  
		//set the videoGUItex.texture to be the same as mTex  
		videoGUItex.texture = mTex;  
		//Plays the movie  
		mTex.Play();  
		//plays the audio from the movie  
		movieAS.Play();  
	}  
}
