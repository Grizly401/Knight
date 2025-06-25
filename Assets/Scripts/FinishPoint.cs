using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] CoinManager _coinManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();
            LevelStars();
            DataGame.GetInctance().IsOver = true;
        }
    }

    private void Start()
    {

    }

    private void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReacheddIndex"))
        {
            PlayerPrefs.SetInt("ReacheddIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1)+ 1);
            PlayerPrefs.Save();
        }
    }

    private void LevelStars()
    {
        
        if ((_coinManager.Coin / _coinManager._allCoins) < 0.33f && !PlayerPrefs.HasKey("Stars" + SceneManager.GetActiveScene().buildIndex))
            PlayerPrefs.SetInt("Stars" + SceneManager.GetActiveScene().buildIndex, 1);
        else if ((_coinManager.Coin / _coinManager._allCoins) >= 0.33f && (_coinManager.Coin / _coinManager._allCoins) <= 0.66f && (!PlayerPrefs.HasKey("Stars" + SceneManager.GetActiveScene().buildIndex) || PlayerPrefs.GetInt("Stars" + SceneManager.GetActiveScene().buildIndex)< 2))
            PlayerPrefs.SetInt("Stars" + SceneManager.GetActiveScene().buildIndex, 2);
        else if ((_coinManager.Coin / _coinManager._allCoins) > 0.66f && (!PlayerPrefs.HasKey("Stars" + SceneManager.GetActiveScene().buildIndex) || PlayerPrefs.GetInt("Stars" + SceneManager.GetActiveScene().buildIndex) < 3))
            PlayerPrefs.SetInt("Stars" + SceneManager.GetActiveScene().buildIndex, 3);

        Debug.Log(PlayerPrefs.GetInt("Stars" + SceneManager.GetActiveScene().buildIndex));
    }
}
