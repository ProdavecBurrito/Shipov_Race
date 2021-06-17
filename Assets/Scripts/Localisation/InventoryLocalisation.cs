using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class InventoryLocalisation : MonoBehaviour
{
    [SerializeField] Text _close;
    [SerializeField] TMP_Text _inventory;

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
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("Inventory");
        yield return loadingOperation;

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var table = loadingOperation.Result;
            _close.text = table.GetEntry("close")?.GetLocalizedString();
            _inventory.text = table.GetEntry("inventory")?.GetLocalizedString();
        }
        else
        {
            Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
        }
    }
}
