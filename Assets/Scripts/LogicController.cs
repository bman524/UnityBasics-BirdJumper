using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicController : MonoBehaviour
{
    public int baseScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool gameOverFLag = false;
    public AudioSource a_src;
    public AudioClip ding;
    public AudioClip[] audioClips;
    private int acIdx = -1;

    private void Start()
    {
        a_src.clip = ding;
    }
    public void addScore(int scoreChange)
    {
        if (!gameOverFLag)
        {
            baseScore += scoreChange;
            //Debug.Log("Score: "+baseScore);
            scoreText.text = baseScore.ToString();

            a_src.PlayOneShot(audioClips[randomSoundIdx()]);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverFLag = true;
    }

    private int randomSoundIdx()
    {
        int randNum = acIdx;
        while(randNum == acIdx)
        {
            randNum = Random.Range(0, audioClips.Length);
        }
        acIdx = randNum;
        return randNum;
    }
}
