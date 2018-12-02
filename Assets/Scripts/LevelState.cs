using UnityEngine;

public class LevelState : MonoBehaviour {

    [SerializeField]
    string levelName;

    [SerializeField]
    LevelState leftState;

    [SerializeField]
    LevelState upState;

    [SerializeField]
    LevelState rightState;

    [SerializeField]
    LevelState downState;

    public string LevelName { get { return levelName; } }
    public LevelState LeftState { get { return leftState; } }
    public LevelState UpState { get { return upState; } }
    public LevelState RightState { get { return rightState; } }
    public LevelState DownState { get { return downState; } }

    public bool IsComplete()
    {
        return PreferencesManager.Instance.IsLevelCompleted(levelName);
    }
}
