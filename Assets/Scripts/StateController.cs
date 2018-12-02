using UnityEngine;

public class StateController : MonoBehaviour
{

    public GameObject player;

    LevelState selectedLevel;

    private void Start()
    {
        if (!selectedLevel)
        {
            selectedLevel = transform.GetChild(0).GetChild(0).GetComponent<LevelState>();
            player.transform.position = selectedLevel.transform.position;
        }
    }

    void Update()
    {
        SelectLevelState();
        FindObjectOfType<LevelSelectionUI>().UpdateText();
    }

    public string GetLevelName()
    {
        return selectedLevel.LevelName;
    }

    private void SelectLevelState()
    {
        HandleKeyboardInput();
        player.transform.position = selectedLevel.transform.position;
    }

    private void HandleKeyboardInput()
    {
        SelectStates();
        LoadLevel();
    }

    private void SelectStates()
    {
        SelectLeftState();
        SelectUpState();
        SelectRightState();
        SelectDownState();
    }

    private void SelectLeftState()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectState(selectedLevel.LeftState);
        }
    }

    private void SelectUpState()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectState(selectedLevel.UpState);
        }
    }

    private void SelectRightState()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectState(selectedLevel.RightState);
        }
    }

    private void SelectDownState()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectState(selectedLevel.DownState);
        }
    }

    private void SelectState(LevelState level)
    {
        if (!level) { return; }
        if (selectedLevel.IsComplete())
        {
            selectedLevel = level;
            return;
        }
        else
        {
            if (level.IsComplete())
            {
                selectedLevel = level;
                return;
            }
        }
        Debug.Log("You must complete the current Level to progress.");
    }

    private void LoadLevel()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedLevel.LevelName == null) { return; }
            LevelManager.Instance.LoadLevel(selectedLevel.LevelName);
        }
    }
}
