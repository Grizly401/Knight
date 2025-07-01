using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{

    [SerializeField] private GameObject _progressBar;
    [SerializeField] private Image _progressBarImage;
    [SerializeField] private Text _loadingText;

    AsyncOperation _asyncOperation;
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

    IEnumerator AsyncLoadScene(int SceneID)
    {
        float loadingProgress;
        _asyncOperation = SceneManager.LoadSceneAsync(SceneID);
        _progressBar.SetActive(true);

        while (!_asyncOperation.isDone)
        {
            loadingProgress = Mathf.Clamp01(_asyncOperation.progress / 0.9f);
            _loadingText.text = $"Загрузка ... {(loadingProgress * 100).ToString("0")}%";
            _progressBarImage.fillAmount = loadingProgress;
            yield return null;
        }

    }

}
