using UnityEngine;

public class GameManager : MonoBehaviour {

    public int coinsCollected = 0;

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

    public void EndGame()
    {
        string nextLevel = GetNextLevel();
        LevelManager.Instance.LoadLevel(nextLevel);
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
}
