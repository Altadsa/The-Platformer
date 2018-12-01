using UnityEngine;

public class LevelStart : MonoBehaviour {

    public GameObject player;

    private void Awake()
    {
        player.transform.position = transform.position;
    }
}
