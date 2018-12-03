using UnityEngine;
using GEV;

public class LevelStart : MonoBehaviour {

    [SerializeField]
    GameObject player;

    [SerializeField]
    ScriptableEvent onLevelStarted;

    private void Awake()
    {
        player.transform.position = transform.position;
        onLevelStarted.Raise();
    }
}
