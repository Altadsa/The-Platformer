using UnityEngine;

public class PreferencesManager : MonoBehaviour {

    string levelPrefix = "_L";
    string scorePrefix = "_S";

    private static PreferencesManager _instance;
    private static readonly object padlock = new object();
    public static PreferencesManager Instance
    {
        get
        {
            lock(padlock)
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<PreferencesManager>();
                }
                return _instance;
            }
        }
    }

    private void Awake()
    {
        PreferencesManager[] instances = FindObjectsOfType<PreferencesManager>();
        if (instances.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public bool IsLevelCompleted(string levelName)
    {
        string key = string.Concat(levelPrefix, levelName);
        if (PlayerPrefs.GetString(key) == bool.TrueString)
        {
            return bool.Parse(PlayerPrefs.GetString(key));
        }
        return false;
    }

    public int LevelScore(string levelName)
    {
        string key = string.Concat(scorePrefix, levelName);
        return PlayerPrefs.GetInt(key);
    }

    public void UnlockLevel(string levelName)
    {
        string key = string.Concat(levelPrefix, levelName);
        PlayerPrefs.SetString(key, "True");
    }

    public void SetLevelScore(string levelName, int scoreToSet)
    {
        string key = string.Concat(scorePrefix, levelName);
        PlayerPrefs.SetInt(key, scoreToSet);
    }
}
