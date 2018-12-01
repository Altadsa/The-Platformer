using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string levelName)
    {
        StartCoroutine(StartLevel(levelName));
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
}
