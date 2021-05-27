using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    int Id { get; }
    ItemInfo Info { get; }
    Sprite Sprite { get; }
}

