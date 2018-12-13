using TMPro;
using UnityEngine;

public class LevelStatistics : MonoBehaviour {

    [SerializeField] TMP_Text levelStats;
    [SerializeField] TMP_Text levelComplete;

    int totalCoins, totalEnemies, totalSecrets;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        totalCoins = FindObjectsOfType<Coin>().Length;
        totalEnemies = FindObjectsOfType<Enemy>().Length;
        //totalSecrets = FindObjectsOfType<Secret>().Length;
    }

    public void OnLevelEnd()
    {
        DisplayLevelStats();
        DisplayLevelCompletion();
    }

    private void DisplayLevelStats()
    {
        string coinStats = string.Format("Coins: {0}/{1}", gameManager.Coins, totalCoins);
        string enemyStats = string.Format("Enemies: {0}/{1}", gameManager.Enemies, totalEnemies);
        levelStats.text = string.Format("Level Statistics\n{0}\n{1}", coinStats, enemyStats);
    }

    private void DisplayLevelCompletion()
    {
        float levelCompletion = ((gameManager.Coins + gameManager.Enemies) / (float)(totalCoins + totalEnemies)) * 100;
        levelComplete.text = string.Format("Completed: {0}%", Mathf.RoundToInt(levelCompletion));
    }
}
