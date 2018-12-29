﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	public int timeLeft = 5;
	public Text countDownText;

	// Use this for initialization
	void Start () {

		StartCoroutine ("LoseTime");

	}

	// Update is called once per frame
	void Update () {

		countDownText.text = ("Time Left: " + timeLeft);

		if (timeLeft <= 0) {
			StopCoroutine ("LoseTime");

			countDownText.text = "Times Up!";
		}
	}

	IEnumerator LoseTime()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			timeLeft--;
		}
	}
}
