using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource", order = 0)]
public class ItemUpgradeConfigDataSource : ScriptableObject
{
    public ItemUpgradeConfig[] itemConfigs;
}

