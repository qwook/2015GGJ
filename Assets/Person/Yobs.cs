using UnityEngine;
using System.Collections;

public class Yobs : Player {

	void Update() {

		base.Update ();

		if (Input.GetButtonDown ("Action1")) {
			doSpecialOne();
		}

		if (Input.GetButtonDown ("Action2")) {
			doSpecialTwo();
		}
						
	}

	public override void doSpecialOne () {
		//do magic
		print ("do special one");
	}

	public override void doSpecialTwo () {
		//do other magic
		print ("do special two");
	}


}
