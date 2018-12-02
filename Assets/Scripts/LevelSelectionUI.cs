using TMPro;
using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{

    public TMP_Text levelName;

    public StateController stateController;

    public void UpdateText()
    {
        levelName.text = stateController.GetLevelName();
    }
}
