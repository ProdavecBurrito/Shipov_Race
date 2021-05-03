using UnityEngine;

public class Item : IItem
{
    public int Id { get; set; }
    public ItemInfo Info { get; set; }
    public Sprite Sprite { get; set; }
}
