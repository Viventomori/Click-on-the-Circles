using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ISceneManager : MonoBehaviour
{
    public static ISceneManager instance;
    
    [SerializeField] private int score;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endScore;
    
    [SerializeField] private AudioSource soundTip;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score;
        endScore.text = scoreText.text;
    }
    
    public void ScorePlus()
    {
        soundTip.Play();
        score++;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
    public void Quit()
    {
        Application.Quit();
    }
    
}
