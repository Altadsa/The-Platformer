using UnityEngine;

public class GameManager : MonoBehaviour {

    public int coinsCollected = 0;

    private static GameManager _instance;
    private static readonly object padlock = new object();
    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
    }

    private void Awake()
    {
        coinsCollected = 0;
    }
}
