using UnityEngine;
using UnityEngine.UI;

public class MainRewardWindowView : MonoBehaviour
{
    [SerializeField] Button _showRewardWindowView;
    [SerializeField] RewardWindowView _rewardWindow;

    private void Awake()
    {
        _showRewardWindowView.onClick.AddListener(_rewardWindow.ShowReward);
    }
}
