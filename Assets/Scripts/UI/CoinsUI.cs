﻿using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour {

    [SerializeField]
    TMP_Text coinUIText;

    string text = "x";

    private void Awake()
    {
        coinUIText.text = text + GameManager.Instance.Coins;
    }

    public void OnUIUpdated()
    {
        coinUIText.text = text + GameManager.Instance.Coins;
	}
}
