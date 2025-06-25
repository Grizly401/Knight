using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalSelector : MonoBehaviour
{
    private bool active = false;

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocalKey", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int LocalId)
    {
        if (active == true)
            return;

        StartCoroutine(SetLocale(LocalId));
        

    }

    IEnumerator SetLocale(int localId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localId];
        PlayerPrefs.SetInt("LocalKey", localId);
        active = false;
    }
}
