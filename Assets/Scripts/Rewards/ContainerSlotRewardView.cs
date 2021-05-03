using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerSlotRewardView : MonoBehaviour
{
    [SerializeField] private Image _selectBackground;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _textDays;
    [SerializeField] private TMP_Text _countReward;

    public void SetData(Reward reward, int countDay, bool isSelect)
    {
        _icon.sprite = reward.Icon;
        _textDays.text = $"Day {countDay}";
        _countReward.text = reward.RewardValue.ToString();
        _selectBackground.gameObject.SetActive(isSelect);
    }
}