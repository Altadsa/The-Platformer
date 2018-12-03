using System.Collections;
using GEV;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    ScriptableEvent onCoinsChanged;

    [SerializeField]
    ScriptableEvent onScoreChanged;

    float timeLeft = 300;
    int coinsCollected = 0;
    int score = 0;

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

    public float TimeLeft { get { return timeLeft; } }
    public int Coins { get { return coinsCollected; } }
    public int Score { get { return score; } }

    public void EndGame()
    {
        string levelName = LevelManager.Instance.GetLevelName();
        PreferencesManager.Instance.OnLevelComplete(levelName);
        PreferencesManager.Instance.UnlockLevel(levelName);
        PreferencesManager.Instance.SetLevelScore(levelName, score);
        string nextLevel = "00_01";
        LevelManager.Instance.LoadLevel(nextLevel);
    }

    public void OnPlayerDeath()
    {
        LevelManager.Instance.ResetLevel();
    }

    public void OnLevelEnd()
    {
        AddTimeToScore();
        ConvertCoinsToScore();
    }

    public void ConvertCoinsToScore()
    {
        isGameOver = true;
        StartCoroutine(AddCoinsToScore());
    }

    public void AddTimeToScore()
    {
        score += (10 * (int)timeLeft);
        onScoreChanged.Raise();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        onScoreChanged.Raise();
    }

    public void AddCoin()
    {
        coinsCollected++;
        onCoinsChanged.Raise();
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
            onCoinsChanged.Raise();
            onScoreChanged.Raise();
        }
    }
}
