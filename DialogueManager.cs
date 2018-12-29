using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;
	public bool stopMovement;
	public Transform warpTarget;
	public GameObject player;


	private Queue<string> sentences;

	// Use this for initialization
	void Start () {

		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool ("IsOpen", true);
		stopMovement = true;
	
		nameText.text = dialogue.name;

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine(TypeSentence(sentence));


	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
			dialogueText.text += letter;
			yield return null;		{

		}
	}

	void EndDialogue()
	{
		animator.SetBool ("IsOpen", false);
		GameObject.Find("Player").GetComponent<PlayerStats>().saveScene();
		//GameObject.Find ("Main Camera").GetComponent<Camera> ().saveCamera ();

		SceneManager.LoadScene ("Main");
		stopMovement = false;

		Debug.Log ("End of conversation.");
	}

}
