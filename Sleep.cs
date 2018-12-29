using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

	int boost;
	public void triggerSleep()
    {
		boost = 100;
		GameObject.Find("Player").GetComponent<PlayerStats>().sleepBoost(boost);
	}
}
