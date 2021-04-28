
using UnityEngine;

class Enemy : IEnemy
{
    private const int CoinsСoefficient = 5;
    private const float PowerСoefficient = 1.5f;
    private const int MaxHealthPlayer = 50;
    private const float _beforeExceedingHealthCoefficient = 0.15f;
    private const float _afterExceedingHealthCoefficient = 0.5f;
    private const int _lowCrimeLevelCoefficient = -3;
    private const int _hightCrimeLevelCoefficient = 3;

    private float _currentForceCoefficient = 0f;
    private string _name;
    private int _crimeLevel;
    private int _playerMoney;
    private int _playerHealth;
    private int _playerPower;
    private int _playerCrimeLevel;

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(PlayerData playerData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _playerMoney = playerData.Money;
                break;

            case DataType.Health:
                _playerHealth = playerData.Health;
                break;

            case DataType.Power:
                _playerPower = playerData.Power;
                break;

            case DataType.CrimeLevel:
                _playerCrimeLevel = playerData.CrimeLevel;
                break;
        }

        Debug.Log($"Notified {_name} change to {playerData}");
    }

    public int Power
   {
       get
       {
            if (_playerHealth > MaxHealthPlayer)
            {
                _currentForceCoefficient += _afterExceedingHealthCoefficient;
            }
            else
            {
                _currentForceCoefficient += _beforeExceedingHealthCoefficient;
            }

            if (_playerCrimeLevel >= 3)
            {
                _crimeLevel = _hightCrimeLevelCoefficient;
            }
            else
            {
                _crimeLevel = _lowCrimeLevelCoefficient;
            }
           var power = (int) (_playerMoney / CoinsСoefficient + _currentForceCoefficient + _playerPower / PowerСoefficient + _crimeLevel);
          
           return power;
       }
   }

}

