using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public GameObject player;

    LevelState selectedLevel;

    private void Start()
    {
        if (!selectedLevel)
        {
            selectedLevel = transform.GetChild(0).GetComponent<LevelState>();
            player.transform.position = selectedLevel.transform.position;
        }
    }

    void Update () {
		
	}
}
