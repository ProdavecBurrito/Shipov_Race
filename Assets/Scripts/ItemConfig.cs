using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class ItemConfig : ScriptableObject
{
    public int id;
    public string title;
    public Sprite image;
}

