using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour {

    public TMP_Text coinUIText;

    string text = "x";

	void Update () {
        coinUIText.text = text + GameManager.Instance.coinsCollected;
	}
}
