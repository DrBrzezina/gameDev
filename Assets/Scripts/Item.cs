using UnityEngine;

[CreateAssetMenu(fileName = "NowyPrzedmiot", menuName = "Piramida/Przedmiot")]
public class Item : ScriptableObject
{
    public string itemName;
    
    public enum ItemType { Torch, Armor, Weapon, Potion, Treasure }
    public ItemType type;

    public string effect; // np. "+10 HP", "Light radius 5", "+5 Attack"
    public int value;     // wartość skarbów lub siła efektu
    
    public Sprite icon;   // odniesienie do Twoich assetów 16x16 / 16x32 px
}