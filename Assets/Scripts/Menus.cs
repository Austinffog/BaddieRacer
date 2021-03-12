using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public GameObject pauseMenu, gameOverMenu, victoryMenu;
    private float points = 0f, blackCarPoint = 0f;
    private const float timeOne = 1f, timeZero = 0f;
    private bool gameIsOver, gameIsVictory;

    public AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeOne;

        gameIsOver = false;
        gameIsVictory = false;
    }

    public void Pause()
    {
        buttonSound.Play();

        if (gameIsOver == true || gameIsVictory == true)
        {

        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = timeZero;
        }
        
    }

    public void Resume()
    {
        buttonSound.Play();

        pauseMenu.SetActive(false);
        Time.timeScale = timeOne;
    }

    public void Exit()
    {
        buttonSound.Play();

        Application.Quit();
    }

    public void MainMenu()
    {
        buttonSound.Play();

        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        buttonSound.Play();

        SceneManager.LoadScene("Game");
        points = 0f;
        PlayerPrefs.SetFloat("points", points);
        blackCarPoint = 0f;
        PlayerPrefs.SetFloat("blackCarPoints", blackCarPoint);
    }

    public void Replay()
    {
        buttonSound.Play();

        victoryMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = timeOne;

        gameIsOver = false;
        gameIsVictory = false;
    }

    public void Victory()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = timeZero;
        gameIsVictory = true;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = timeZero;
        gameIsOver = true;
    }
}

/*
 Reference

 Freesound. 2021. Button Clicks 3 by Mellau, 14 February  2020. [Online]. 
 Available at: https://freesound.org/people/Mellau/sounds/506052/. [Accessed 9 March 2021].

 */
