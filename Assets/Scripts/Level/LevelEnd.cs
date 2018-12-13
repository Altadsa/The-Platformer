using UnityEngine;
using GEV;

public class LevelEnd : MonoBehaviour {

    [SerializeField]
    ScriptableEvent onLevelEnd;

    int triggersLeft = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggersLeft < 1) { return; }
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            triggersLeft--;
            GameManager.Instance.OnLevelEnd();
            onLevelEnd.Raise();
        }
    }
}
