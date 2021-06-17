using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class RewardLocalisation : MonoBehaviour
{
    [SerializeField] TMP_Text _reward;
    [SerializeField] TMP_Text _getReward;
    [SerializeField] TMP_Text _counter;
    [SerializeField] TMP_Text _reset;

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
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("Reward");
        yield return loadingOperation;

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var table = loadingOperation.Result;
            _reward.text = table.GetEntry("reward")?.GetLocalizedString();
            _getReward.text = table.GetEntry("get")?.GetLocalizedString();
            _counter.text = table.GetEntry("counter_text")?.GetLocalizedString();
            _reset.text = table.GetEntry("reset")?.GetLocalizedString();
        }
        else
        {
            Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
        }
    }
}
