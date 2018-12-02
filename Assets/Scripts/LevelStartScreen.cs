using TMPro;
using UnityEngine;

public class LevelStartScreen : MonoBehaviour {

    public TMP_Text levelName;

    string textToSet;

    private void Awake()
    {
        SetText();
    }

    public string[] GetLevelName()
    {
        string[] regionAndLevel = textToSet.Split('_');
        return regionAndLevel;
    }

    private void SetText()
    {
        textToSet = LevelManager.Instance.GetLevelName();
        string[] arr = textToSet.Split('_');
        levelName.text = "Region: " + arr[0] + "\nLevel: " + arr[1];
    }

}
