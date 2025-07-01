using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : Menu
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _dieMenu;
    [SerializeField] private Character _character;
    [SerializeField] private GameObject _screenOver;
    [SerializeField] private GameObject _pauseButton;

    private bool _activatedPause = false;

    public void StartInputSystem()
    {
        _character.Input.Enable();
    }

    public void StopInputSystem()
    {
        _character.Input.Disable();
    }
    public override void ActiveMenu(GameObject menu)
    {
        base.ActiveMenu(menu);
    }

    public override void DisableMenu(GameObject menu)
    {
        base.DisableMenu(menu);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void GameQuit()
    {
        base.GameQuit();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void LoadScene(int SceneIndex)
    {
        base.LoadScene(SceneIndex);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    private void Update()
    {
        if (DataGame.GetInctance().IsDead && _activatedPause == false)
        {
            StartCoroutine(StopGame());
            _activatedPause = true;
        }

        if (DataGame.GetInctance().IsOver)
        {
            _dieMenu.SetActive(true);
            _screenOver.SetActive(true);
            _pauseButton.SetActive(false);
        }
    }

    private IEnumerator StopGame()
    {
        yield return new WaitForSeconds(2f);
        _dieMenu.SetActive(true);
    }



}
