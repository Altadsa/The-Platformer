using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timeLeft = 300;
    public int coinsCollected = 0;
    public int score = 0;

    bool isGameOver;

    private static GameManager _instance;
    private static readonly object padlock = new object();
    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
    }

    private void Update()
    {
        if (!isGameOver && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; 
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelManager.Instance.LoadLevel("00_01");
        }
    }

    public void EndGame()
    {
        string levelName = LevelManager.Instance.GetLevelName();
        PreferencesManager.Instance.OnLevelComplete(levelName);
        PreferencesManager.Instance.UnlockLevel(levelName);
        PreferencesManager.Instance.SetLevelScore(levelName, score);
        string nextLevel = "00_01";
        LevelManager.Instance.LoadLevel(nextLevel);
    }

    public void ConvertCoinsToScore()
    {
        isGameOver = true;
        StartCoroutine(AddCoinsToScore());
    }

    public void AddTimeToScore()
    {
        score += (10 * (int)timeLeft);
    }

    private void Awake()
    {
        coinsCollected = 0;
    }

    IEnumerator AddCoinsToScore()
    {
        while (coinsCollected > 0)
        {
            yield return new WaitForSeconds(0.5f);
            coinsCollected--;
            score += 100; 
        }
    }
}
