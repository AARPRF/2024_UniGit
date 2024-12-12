using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //1. Ninja Ex_1
    [Header ("Score Elements")]
    public int score;  
    public Text scoreText;

    //5.
    public int highScore;
    public Text highscoreText;

    //4.
    [Header("GameOver Elements")]
    public GameObject GameOverPanel;

    //7.
    [Header("Sounds Elements")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;

    //6.
    public void GetHighScore()
    {
        //Same exact label(key) as in the SetInt method
        highScore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = "Best: " + highScore.ToString();
    }


    //1.
    public void IncreaseScore(int addedPoints)
    {
        //1. Increase and visualize current score
        //To make it work, has to called from fruit controller
        score += addedPoints;
        scoreText.text = score.ToString();


        //5.
        if (score > highScore)
        {

            //Class to store thing between sessions by defined key as a customize string
            //Define a key, "HighScore", same name in setting and getting methods
            PlayerPrefs.SetInt("HighScore", score);
            highscoreText.text = "Best: " + score.ToString();
        }//
    }


    //2. Method called by the BombController script
    public void OnBombHit()
    {

        //2.
        Debug.Log("Bomb hit");
        //Stops every movement in the game
        Time.timeScale = 0;

        //4.
        //True to show when hit bomb
        GameOverPanel.SetActive(true);
    }


    //4. Called by the button once the panel is shown when hit a bomb
    public void RestartGame()
    {
        //LoadSceneAsync Loads the scene in the background and only shows when its ready
        //LoadScene this time could be ok, because there not some much in the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Time Scale back to 1
        Time.timeScale = 1;
    }


    // Start is called before the first frame update
    void Start()
    {
        //6. get high score each time the game is loaded
        GetHighScore();

        //7.
        //Pasamos a la varible privada lo del componente audiosource
        audioSource = GetComponent<AudioSource>();
    }

    //7.
    public void PlayRandmoSliceSound()
    {
        AudioClip randomSound = sliceSounds[
            Random.Range(0, sliceSounds.Length)];
        //Several ways to play sounds. Get the audio clip to the audiosource component
        audioSource.PlayOneShot(randomSound);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

}
