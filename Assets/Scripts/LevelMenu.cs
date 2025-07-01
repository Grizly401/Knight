using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : Menu
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Sprite _starsIconOne, _starsIconTwo;


    private void Awake()
    {
       int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

       for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }
        
        for(int i = 0; i < unlockedLevel; i++)
        {
            _buttons[i].interactable = true;
        }
        
    }

    private void Start()
    {
        for (int i = 1; i <= _buttons.Length; i++)
        {
            if (PlayerPrefs.HasKey("Stars" + i))
            {
                if (PlayerPrefs.GetInt("Stars" + i) == 1)
                {
                    _buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite = _starsIconTwo;
                    _buttons[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = _starsIconOne;
                    _buttons[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = _starsIconOne;
                }
                else if (PlayerPrefs.GetInt("Stars" + i) == 2)
                {
                    _buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite = _starsIconTwo;
                    _buttons[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = _starsIconTwo;
                    _buttons[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = _starsIconOne;
                }
                else
                {
                    _buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite = _starsIconTwo;
                    _buttons[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = _starsIconTwo;
                    _buttons[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = _starsIconTwo;
                }
            }
            else
            {
                _buttons[i - 1].transform.GetChild(0).gameObject.SetActive(false);
                _buttons[i - 1].transform.GetChild(1).gameObject.SetActive(false);
                _buttons[i - 1].transform.GetChild(2).gameObject.SetActive(false);
            }
                
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
