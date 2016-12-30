using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{

	GameObject player;
	public PlayerHealth playerHealth;


	public void RestartLevel ()									//method that restarts the level
	{
		if (playerHealth.currentHealth <= 0) 					//checks to see if the player health is 0, is the health is zero it then restarts the game (Will got to menu in the future).
		{
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		RestartLevel ();

	}
}
