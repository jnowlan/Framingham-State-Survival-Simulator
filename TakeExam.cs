using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeExam : MonoBehaviour {

	public void triggerExam()
	{
		SceneManager.LoadScene ("Main");
	}
}
