using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistence : MonoBehaviour {

	//public int curCash;
	//public int curMood;
	//public Vector3 Location;

	public static void Savedata(Player player)
	{
		PlayerPrefs.SetFloat ("x", player.transform.position.x);
		PlayerPrefs.SetFloat ("y", player.transform.position.y);
		PlayerPrefs.SetFloat ("z", player.transform.position.z);
		PlayerPrefs.SetInt ("curMood", player.PlayerData.curMood);
		PlayerPrefs.SetInt ("curCash", player.PlayerData.curCash);

		/*PlayerPrefs.SetFloat ("camx", camPos.position.x);
		PlayerPrefs.SetFloat ("camy", camPos.position.y);
		PlayerPrefs.SetFloat ("camz", camPos.position.z);
		*/

			
	}

	public static PlayerData LoadData()
	{
		float x = PlayerPrefs.GetFloat ("x");
		float y = PlayerPrefs.GetFloat ("y");
		float z = PlayerPrefs.GetFloat ("z");
		int curMood = PlayerPrefs.GetInt ("curMood");
		int curCash = PlayerPrefs.GetInt ("curCash");
		/*
		float camx = PlayerPrefs.GetFloat ("camx");
		float camy = PlayerPrefs.GetFloat ("camy");
		float camz = PlayerPrefs.GetFloat ("camz");
		*/



		PlayerData playerData = new PlayerData () {
			Location = new Vector3 (x, y, z),
			curMood = curMood,
			curCash = curCash,
			//camLocation = new Vector3(camx, camy, camz)

		};

		return playerData;
	}
}
