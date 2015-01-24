using UnityEngine;
using System.Collections;

abstract class Player : MonoBehaviour {
	public float health;
	public int points;
	public float coolDownTimeOne;
	public float coolDownTimeTwo;

	private float coolDownOneTimer;
	private float coolDownTwoTimer;



	virtual void doSpecialOne() {};
	virtual void doSpecialTwo() {};


}
