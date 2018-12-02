using UnityEngine.UI;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public GameObject levelEndPanel;

    public GameObject player;

    int triggersLeft = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggersLeft < 1) { return; }
        if (collision.gameObject == player)
        {
            triggersLeft--;
            GameManager.Instance.ConvertCoinsToScore();
            GameManager.Instance.AddTimeToScore();
            levelEndPanel.SetActive(true);
        }
    }
}
