using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Inventory/Ore")]
public class OreData : ScriptableObject
{
    public string oreName;
    public Sprite icon;
    public int mineSpeed;
}
