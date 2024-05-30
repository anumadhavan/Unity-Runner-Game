using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject totalScore;
    


    private void Start()
    {
       
    }
    public void OnPlayButtonClick()
    {
        startScreen.SetActive(false);
        gameManager.OnPlayClicked();
        score.SetActive(true);

    }
     public void OnGameOver(float timeDelay)
     {
        Invoke("EnableGameOverScreen",timeDelay);
       
        
     }
      private void EnableGameOverScreen()
      {
        gameOver.SetActive(true);
        score.SetActive(false);
       
      }

    public void PlayAgainButtonClicked()
    {

        gameManager.OnPlayClicked();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

     public void QuitGame()
    {
        Application.Quit();
    }
}

