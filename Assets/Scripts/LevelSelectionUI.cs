using TMPro;
using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{

    public TMP_Text levelName;

    public StateController stateController;

    public void UpdateText()
    {
        levelName.text = LevelText();
    }

    private string LevelText()
    {
        string title = stateController.GetLevelName();
        string completed = IsLevelCompleted();
        string score = GetLevelScore();
        return string.Concat(title, completed, score);
    }

    private string IsLevelCompleted()
    {
        string text = "\nCompleted: ";
        string completed;
        if (PreferencesManager.Instance.IsLevelCompleted(stateController.GetLevelName()))
        {
            completed = "Yes";
        }
        else
        {
            completed = "No";
        }
        return string.Concat(text, completed);
    }

    private string GetLevelScore()
    {
        string text = "\nScore: ";
        int score = PreferencesManager.Instance.LevelScore(stateController.GetLevelName());
        return string.Concat(text, score);
    }
}
