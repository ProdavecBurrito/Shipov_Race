using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardWindowView : MonoBehaviour
{
    private Animator _animator;
    private bool _isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShowReward()
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
        _animator.Play("RewardOpen");
        _isOpen = true;
    }

    private void Hide()
    {
        _animator.Play("RewardClose");
        _isOpen = false;
    }
}
