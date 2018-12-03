using UnityEngine;
using GEV;

public class LevelEnd : MonoBehaviour {

    [SerializeField]
    ScriptableEvent onLevelEnd;

    public GameObject player;

    int triggersLeft = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggersLeft < 1) { return; }
        if (collision.gameObject == player)
        {
            GameManager.Instance.OnLevelEnd();
            onLevelEnd.Raise();
        }
    }
}
