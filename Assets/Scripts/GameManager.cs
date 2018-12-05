using System.Collections;
using GEV;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    ScriptableEvent onUIUpdated;

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
        StopAllCoroutines();
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

    public void OnLevelComplete()
    {
        int scorePerCoin = 100;
        for (int i = 0; i < coinsCollected; i++)
        {
            score += scorePerCoin;
        }
        onUIUpdated.Raise();
    }

    public void ConvertCoinsToScore()
    {
        isGameOver = true;
        StartCoroutine(AddCoinsToScore());
    }

    public void AddTimeToScore()
    {
        score += (10 * (int)timeLeft);
        onUIUpdated.Raise();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        onUIUpdated.Raise();
    }

    public void AddCoin()
    {
        coinsCollected++;
        onUIUpdated.Raise();
    }

    private void Awake()
    {
        coinsCollected = 0;
    }

    IEnumerator AddCoinsToScore()
    {
        while (coinsCollected > 0)
        {
            yield return new WaitForSeconds(0.25f);
            coinsCollected--;
            score += 100;
            onUIUpdated.Raise();
        }
    }
}
