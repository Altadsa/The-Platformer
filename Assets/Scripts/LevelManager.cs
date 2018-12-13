﻿using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private static LevelManager _instance;
    private static readonly object padlock = new object();
    public static LevelManager Instance
    {
        get
        {
            lock(padlock)
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<LevelManager>();
                }
                return _instance;
            }
        }
    }

    private void Awake()
    {
        LevelManager[] levelManagers = FindObjectsOfType<LevelManager>();
        if (levelManagers.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(StartLevel(levelName));
    }

    public void ResetLevel()
    {
        StartCoroutine(Reset());
    }

    public string GetLevelName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartLevel(string levelName)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(levelName);
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2.0f);
        string levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(levelName);
    }
}
