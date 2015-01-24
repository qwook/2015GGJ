using UnityEngine;
using System.Collections;

public class Yobs : Player {

	void Update() {
		if (Input.GetButtonDown ("Action1")) {
			doSpecialOne();
		}

		if (Input.GetButtonDown ("Action2")) {
			doSpecialTwo();
		}
						
	}

	override void doSpecialOne () {
		//do magic
		print ("do special one");
	}

	override void doSpecialTwo () {
		//do other magic
		print ("do special two");
	}


}
