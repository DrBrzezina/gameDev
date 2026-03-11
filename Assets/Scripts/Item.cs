using UnityEngine;

[CreateAssetMenu(fileName = "NowyPrzedmiot", menuName = "Piramida/Przedmiot")]
public class Item : ScriptableObject
{
    public string itemName;
    public enum ItemType { Torch, Armor, Weapon, Potion, Treasure }
    public ItemType type;
    public string effect;
    public int value;
    public Sprite icon;
}