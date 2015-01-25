using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector3 initialPosition;
	public GameObject P1;
	public GameObject P2;
	public float cameraSpeed;
//	public Vector3 initialRotation;

	public bool isFollowing;

	// Use this for initialization
	void Start () {
//		this.transform.localPosition = initialPosition;

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 max;
		Animator speed;

		if (P1.transform.localPosition.z > P2.transform.localPosition.z) {
			max = P1.transform.localPosition;
			speed = P1.GetComponent<Animator> ();
		} else {
			max = P2.transform.localPosition;
			speed = P2.GetComponent<Animator> ();
		}

		if (max.z >= this.transform.localPosition.z + 15) {
			Vector3 newPos = new Vector3 (0f, 0f, speed.speed * cameraSpeed);
			this.transform.localPosition += newPos;		
		}

	}

	void setPosition(Vector3 pos) {
		this.transform.localPosition = pos;
	}
}
