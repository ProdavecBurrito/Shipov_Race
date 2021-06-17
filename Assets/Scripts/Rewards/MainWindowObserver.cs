using JoostenProductions;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainWindowObserver : MonoBehaviour
{
    [SerializeField] private TMP_Text _countMoneyText;
    [SerializeField] private TMP_Text _countHealthText;
    [SerializeField] private TMP_Text _countPowerText;
    [SerializeField] private TMP_Text _countPowerEnemyText;
    [SerializeField] private TMP_Text _crimeLevelText;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private Button _removeCoinsButton;
    [SerializeField] private Button _addHealthButton;
    [SerializeField] private Button _removeHealthButton;
    [SerializeField] private Button _addPowerButton;
    [SerializeField] private Button _removePowerButton;
    [SerializeField] private Button _addCrimeLevel;
    [SerializeField] private Button _removeCrimeLevel;
    [SerializeField] private Button _fightButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _skipFightFightButton;
    [SerializeField] private Button _skipButton;
    [SerializeField] private RectTransform _skipFightImage;

    private int _allPlayerMoney;
    private int _allPlayerHealth;
    private int _allPlayerPower;
    private int _playerCrimeLevel;
    private bool _isSkipFight;

    private Money _money;
    private Health _heath;
    private Power _power;
    private CrimeLevel _crimeLevel;
    private Timer _timer;

    private Enemy _enemy;

    private void Start()
    {
        _timer = new Timer();
        _timer.EndCountDown += ClearFightResultText;
        UpdateManager.SubscribeToUpdate(_timer.CountTime);

        _enemy = new Enemy("Enemy Car");

        _money = new Money(nameof(Money));
        _money.SubscribeEnemy(_enemy);

        _heath = new Health(nameof(Health));
        _heath.SubscribeEnemy(_enemy);

        _power = new Power(nameof(Power));
        _power.SubscribeEnemy(_enemy);

        _crimeLevel = new CrimeLevel(nameof(CrimeLevel));
        _crimeLevel.SubscribeEnemy(_enemy);

        _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _removeCoinsButton.onClick.AddListener(() => ChangeMoney(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _removeHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _removePowerButton.onClick.AddListener(() => ChangePower(false));

        _addCrimeLevel.onClick.AddListener(() => ChangeCrimeLevel(true));
        _removeCrimeLevel.onClick.AddListener(() => ChangeCrimeLevel(false));

        _skipFightFightButton.onClick.AddListener(Fight);
        _skipFightFightButton.onClick.AddListener(CloseSkipFight);
        _skipButton.onClick.AddListener(CloseSkipFight);

        _fightButton.onClick.AddListener(Fight);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
        {
            _allPlayerMoney++;
        }
        else
        {
            _allPlayerMoney--;
        }

        ChangeDataWindow(_allPlayerMoney, DataType.Money);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
        {
            _allPlayerHealth++;
        }
        else
        {
            if (_allPlayerHealth > 0)
            {
                _allPlayerHealth--;
            }
        }

        ChangeDataWindow(_allPlayerHealth, DataType.Health);
    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
        {
            _allPlayerPower++;
        }
        else
        {
            if (_allPlayerPower > 0)
            {
                _allPlayerPower--;
            }
        }

        ChangeDataWindow(_allPlayerPower, DataType.Power);
    }

    private void ChangeCrimeLevel(bool isAddCount)
    {
        if (isAddCount)
        {
            _playerCrimeLevel++;
        }
        else
        {
            if (_playerCrimeLevel > 0)
            {
                _playerCrimeLevel--;
            }
        }

        ChangeDataWindow(_playerCrimeLevel, DataType.CrimeLevel);
    }

    private void Fight()
    {
        if (_crimeLevel.CrimeLevel > 2 || _isSkipFight)
        {
            if (_allPlayerPower >= _enemy.Power)
            {
                _resultText.text = "Win";
                _resultText.color = Color.yellow;
            }
            else
            {
                _resultText.text = "Lose";
                _resultText.color = Color.red;
            }
            _timer.Init(2.0f);
        }
        else
        {
            ShowSkipFight();
        }
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money {countChangeData.ToString()}";
                _money.Money = countChangeData;
                break;

            case DataType.Health:
                _countHealthText.text = $"Player Health {countChangeData.ToString()}";
                _heath.Health = countChangeData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Player Power {countChangeData.ToString()}";
                _power.Power = countChangeData;
                break;

            case DataType.CrimeLevel:
                _crimeLevelText.text = $"Player Crime Level {countChangeData.ToString()}";
                _crimeLevel.CrimeLevel = countChangeData;
                break;
        }

        _countPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
    }

    public void InitMainMenu(UnityAction mainMenu)
    {
        _mainMenuButton.onClick.AddListener(mainMenu);
    }

    private void ShowSkipFight()
    {
        _skipFightImage.gameObject.SetActive(true);
        _isSkipFight = true;
    }

    private void CloseSkipFight()
    {
        _skipFightImage.gameObject.SetActive(false);
        _isSkipFight = false;
    }

    private void ClearFightResultText()
    {
        _resultText.text = string.Empty;
    }

    private void OnDestroy()
    {
        _addCoinsButton.onClick.RemoveAllListeners();
        _removeCoinsButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _removeHealthButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _removePowerButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();

        _addCrimeLevel.onClick.RemoveAllListeners();
        _removeCrimeLevel.onClick.RemoveAllListeners();

        _skipFightFightButton.onClick.RemoveAllListeners();
        _skipButton.onClick.RemoveAllListeners();

        _timer.EndCountDown -= ClearFightResultText;
        UpdateManager.UnsubscribeFromUpdate(_timer.CountTime);

        _money.UnsubscribeEnemy(_enemy);
        _heath.UnsubscribeEnemy(_enemy);
        _power.UnsubscribeEnemy(_enemy);
        _crimeLevel.UnsubscribeEnemy(_enemy);
    }
}

