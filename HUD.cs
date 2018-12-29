using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

	public Text MOOD;
	public Text CASH;
    int mood;
	int cash;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		cash = GameObject.Find ("Player").GetComponent<PlayerStats> ().curCash;
		mood = GameObject.Find ("Player").GetComponent<PlayerStats> ().curMood;
       
        MOOD.text = ("" + mood + "/100");
		CASH.text = ("$" + cash);
    }
}
