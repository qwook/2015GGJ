using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector3 initialPosition;
	public GameObject P1;
	public GameObject P2;
//	public Vector3 initialRotation;

	public bool isFollowing;

	// Use this for initialization
	void Start () {
		this.transform.localPosition = initialPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newMin = ((P1.transform.localPosition.z < P2.transform.localPosition.z) ? P1.transform.localPosition : P2.transform.localPosition);
		if (newMin.z >= this.transform.localPosition.z + 20) {
			Vector3 newPos = new Vector3 (0f, 0f, 0.05f);
			this.transform.localPosition += newPos;

				
		}
//		Vector3 newPos = new Vector3 (0f, 0f, newMin.z);
//		this.transform.localPosition += newPos;

	}

	void setPosition(Vector3 pos) {
		this.transform.localPosition = pos;
	}
}
