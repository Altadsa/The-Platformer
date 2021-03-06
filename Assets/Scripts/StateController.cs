﻿using UnityEngine;

public class StateController : MonoBehaviour
{
    Transform player;

    LevelState selectedLevel;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        selectedLevel = GetCurrentLevelState();
        if (selectedLevel == null)
        {
            selectedLevel = transform.GetChild(0).GetChild(0).GetComponent<LevelState>();
            player.position = selectedLevel.transform.position;
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

    private LevelState GetCurrentLevelState()
    {
        string currentLevelName = PreferencesManager.Instance.GetCurrentLevel();
        foreach (Transform child in transform)
        {
            foreach (Transform greatChild in child)
            {
                if (greatChild.GetComponent<LevelState>().LevelName == currentLevelName)
                {
                    return greatChild.GetComponent<LevelState>();
                }
            }
        }
        return null;
    }

    private void SelectLevelState()
    {
        HandleKeyboardInput();
        player.position = selectedLevel.transform.position;
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
