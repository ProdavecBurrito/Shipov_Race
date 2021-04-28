using System.Collections.Generic;

public class PlayerData
{
    private string _titleData;
    private int _currentHealth;
    private int _currentMoney;
    private int _currentPower;
    private int _crimeLevel;

    private List<IEnemy> _signedEnemies = new List<IEnemy>();

    public string TitleData => _titleData;

    public int Money
    {
        get => _currentMoney;
        set
        {
            if (_currentMoney != value)
            {
                _currentMoney = value;
                Notify(DataType.Money);
            }
        }
    }

    public int Health
    {
        get => _currentHealth;
        set
        {
            if (_currentHealth != value)
            {
                _currentHealth = value;
                Notify(DataType.Health);
            }
        }
    }

    public int Power
    {
        get => _currentPower;
        set
        {
            if (_currentPower != value)
            {
                _currentPower = value;
                Notify(DataType.Power);
            }
        }
    }

    public int CrimeLevel
    {
        get => _crimeLevel;
        set
        {
            if (_crimeLevel != value)
            {
                _crimeLevel = value;
                Notify(DataType.CrimeLevel);
            }
        }
    }

    protected PlayerData(string titleData)
    {
        _titleData = titleData;
    }

    public void SubscribeEnemy(IEnemy enemy)
    {
        _signedEnemies.Add(enemy);
    }

    public void UnsubscribeEnemy(IEnemy enemy)
    {
        _signedEnemies.Remove(enemy);
    }

    protected void Notify(DataType dataType)
    {
        foreach (var investor in _signedEnemies)
        {
            investor.Update(this, dataType);
        }
    }
}
