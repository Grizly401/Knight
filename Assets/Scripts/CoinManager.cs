using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public int Coin { get; set; }
    public int _allCoins;

    private void Start()
    {
        _allCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log(_allCoins);
    }

}
