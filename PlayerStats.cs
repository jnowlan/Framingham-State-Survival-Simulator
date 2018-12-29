using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public PlayerData PlayerData {get; private set;}
    public GameObject sleepButton;
    public GameObject testButton;

    private void OnEnable()
	{
		PlayerData = PlayerPersistence.LoadData ();

		transform.position = PlayerData.Location;

	}

	private void OnDisable()
	{
		PlayerPersistence.Savedata (this);
	}


	public void saveScene()
	{
		PlayerPersistence.Savedata (this);
	}

	public int minMood = 0;
	public int curMood = 50;
	public int maxMood = 100;
	public int curCash = 5000;
	public int maxCash = 1000000;

	public Animator sleepAnimator;
	public Animator animator;

	public int credits;
	public bool menuOpen;
	public bool canMove;

	// Use this for initialization
	void Start () 
	{

		canMove = true;
		menuOpen = false;
        animator.SetBool("nearBed", false);
        animator.SetBool("nearProf", false);

        sleepButton.SetActive(false);
        testButton.SetActive(false);

        credits = 0;


	}

	// Update is called once per frame
	void Update () 
	{
		if (curMood > maxMood) {
			curMood -= (curMood - maxMood);
		}

		if (curMood < minMood) {
			curMood += (minMood - curMood);
		}

	}

	public void sleepBoost(int boost)
	{
		curMood += boost;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("NPC"))
		{
            testButton.SetActive(true);
            curMood -= 99;
			animator.SetBool ("nearProf", true);

			credits += 1;
		
		}
		else if (other.gameObject.CompareTag("BedroomSleep"))
        {
            sleepButton.SetActive(true);
            sleepAnimator.SetBool ("nearBed", true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("NPC"))
		{
			animator.SetBool("nearProf", false);
		}

		if(other.gameObject.CompareTag("BedroomSleep"))
		{
			sleepAnimator.SetBool("nearBed", false);
		}
	}
}



