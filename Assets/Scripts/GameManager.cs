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
        PreferencesManager.Instance.UnlockLevel(LevelManager.Instance.GetLevelName());
        PreferencesManager.Instance.SetLevelScore(LevelManager.Instance.GetLevelName(), score);
        string nextLevel = GetNextLevel();
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

    private string GetNextLevel()
    {
        string nextLevelString = "";
        string[] regionAndLevel = FindObjectOfType<LevelStartScreen>().GetLevelName();
        if (regionAndLevel.Length == 2)
        {
            int nextLevel = int.Parse(regionAndLevel[1]);
            nextLevel++;
            regionAndLevel[1] = nextLevel.ToString();
            nextLevelString = string.Concat(regionAndLevel[0] + "_0" + regionAndLevel[1]);
        }
        return nextLevelString;
    }

    private void Awake()
    {
        coinsCollected = 0;
    }

    IEnumerator AddCoinsToScore()
    {
        while (coinsCollected > 1)
        {
            yield return new WaitForSeconds(1);
            coinsCollected--;
            score += 100; 
        }
    }
}
