using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelWin;

    public GameObject gameOverPannal;
    public GameObject levelWinPannal;

    public static int CurrentLevelIndex;
    public static int noOfPassingRings;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public Slider ProggressBar;

    public void Awake ()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    private void Start ()
    {
        Time.timeScale = 1f;
        noOfPassingRings = 0;
        gameOver = false;
        levelWin = false;
    }
    private void Update ()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPannal.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        currentLevelText.text = CurrentLevelIndex.ToString();
        nextLevelText.text = (CurrentLevelIndex + 1).ToString();

        //update our slider
        int proggress = noOfPassingRings * 100 / FindObjectOfType<HelixManager> ().noOfRings;
        ProggressBar.value = proggress;

        if(levelWin)
        {
            levelWinPannal.SetActive(true);
            if(Input.GetMouseButtonDown (0))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", CurrentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
