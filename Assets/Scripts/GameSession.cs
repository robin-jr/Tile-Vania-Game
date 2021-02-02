using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour

{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    private void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateLives();
        UpdateScore();
    }
    private void UpdateLives()
    {
        livesText.text = lives.ToString();

    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();

    }
    public void HandleDeath()
    {
        --lives;
        UpdateLives();
        if (lives < 1)
        {
            FindObjectOfType<LevelLoader>().LoadMenu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void AddToScore(int score)
    {
        this.score += score;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
