using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New_Status_Data",menuName = "ScriptableObject/StatusData")]
public class ScriptableStatus : ScriptableObject
{
    [SerializeField] int maxHp;
    [SerializeField] int atk;
    [SerializeField] int abilityPower;
    [SerializeField] int armor;
    
   public void AddMaxHP(int amount)
    {
        maxHp += amount;
    }
    public void DecreaseMaxHP(int amount) => maxHp -= amount;
    public void AddATK(int amount) => atk += amount;
    public void DecreaseATK(int amount) => atk -= amount;
    public void AddAbilityPower(int amount) => abilityPower += amount;
    public void DecreaseAbilityPower(int amount) => abilityPower -= amount;
    public void AddArmor(int amount) => armor += amount;
    public void DecreaseArmor(int amount) => armor -= amount;
    

}
