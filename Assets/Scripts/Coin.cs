using UnityEngine;

public class Coin : MonoBehaviour {

    int triggersLeft = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggersLeft > 0)
        {
            triggersLeft--;
            GameManager.Instance.AddCoin();
            Destroy(gameObject); 
        }
    }
}
