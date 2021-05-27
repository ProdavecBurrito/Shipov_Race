using DG.Tweening;
using UnityEngine;

public class RewardWindowView : MonoBehaviour, ISidePanelTween
{
    [SerializeField] private Vector2 _openPosition;
    [SerializeField] private Vector2 _closePosition;
    private float _duration = 0.6f;
    private bool _isOpen;

    public void ShowWindow()
    {
        if (_isOpen)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        var sequence = DOTween.Sequence();

        sequence.Insert(0.0f, transform.DOLocalMove(_openPosition, _duration));
        sequence.OnComplete(() =>
        {
            sequence = null;
        });

        _isOpen = true;
    }

    private void Hide()
    {
        var sequence = DOTween.Sequence();

        sequence.Insert(0.0f, transform.DOLocalMove(_closePosition, _duration));
        sequence.OnComplete(() =>
        {
            sequence = null;
        });
        _isOpen = false;
    }
}
