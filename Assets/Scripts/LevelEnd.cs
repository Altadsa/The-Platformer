using UnityEngine.UI;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public GameObject levelEndPanel;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            levelEndPanel.SetActive(true);
        }
    }
}
