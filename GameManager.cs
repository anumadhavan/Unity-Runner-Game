using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMovements player;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private AudioSource coinCollected;

    private int coinCount = 0;
    [HideInInspector] public int totalCoinCollected = 0;


    public void OnPlayClicked()
    {
        Debug.Log("Invoked");
        player.SetRunningState(true);
    }
    

    public void CoinCollected()
    {
        coinCollected.Play();
        coinCount++;
        totalCoinCollected = coinCount;
        scoreText.text = " " + coinCount.ToString();
        totalScoreText.text = " " + totalCoinCollected.ToString();
        Debug.Log("Coin Count :" +coinCount);
    }

     public void OnPlayerHit()
     {
        player.OnPlayerHit();
        uIManager.OnGameOver(3f);
     }  
}