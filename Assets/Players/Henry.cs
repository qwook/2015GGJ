using UnityEngine;
using System.Collections;

public class Henry : Player {
	
	void Update() {
		
		base.Update ();
		
		
		
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

