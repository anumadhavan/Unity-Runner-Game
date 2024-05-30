using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   private GameManager gameManager;

	void  Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}


	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			gameManager.CoinCollected();
			gameObject.SetActive(false);
		}
	}
}
