using UnityEngine;
using System.Collections;

public class AnimateStartScreen : MonoBehaviour {
	private Animator animator;
	private Vector3 reset;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetFloat ("Speed", 0.5f);
		reset = new Vector3 (-10, 10, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > 40) {
			transform.position = reset;
		}
	}
}
