using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class MainMenuLocalisation : MonoBehaviour
{
    [SerializeField] Text _play;
    [SerializeField] Text _inventory;
    [SerializeField] Text _fight;
    [SerializeField] Text _exit;


    private void Awake()
    {
        ChangedLocaleEvent(null);
        LocalizationSettings.SelectedLocaleChanged += ChangedLocaleEvent;
    }

    private void ChangedLocaleEvent(Locale locale)
    {
        StartCoroutine(OnChangedLocale(locale));
    }

    private IEnumerator OnChangedLocale(Locale locale)
    {
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("MainMenu");
        yield return loadingOperation;

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var table = loadingOperation.Result;
            _play.text = table.GetEntry("main_menu")?.GetLocalizedString();
            _inventory.text = table.GetEntry("inventory")?.GetLocalizedString();
            _fight.text = table.GetEntry("fight")?.GetLocalizedString();
            _exit.text = table.GetEntry("exit")?.GetLocalizedString();
        }
        else
        {
            Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
        }
    }
}
