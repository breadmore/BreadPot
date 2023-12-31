using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GearData
{
    public string Code;
    public string WeaponLeft;
    public string WeaponRight;
    public string Helmat;
    public string Armor;
    public string Foot;
}


[System.Serializable]
public class Character
{
    public string Name;
    public string Code;
    public int AttackDamage;
    public int Defense;
    public int MagicalDefense;
    public int Evasion;
    public int Health;
    public int Strength;
    public int Vitality;
    public int Intelligence;
    public int Wisdom;
    public int Talent;
    public int Agility;
    public int Luck;
    public int EXP;
    public string SkillCode;

}

[Serializable]
public class PlayerInventory
{
    public Vector2Int playerPosition;
    public string leftHandEquipmentCode;
    public string rightHandEquipmentCode;
    public string helmatEquipmentCode;
    public string armorEquipmentCode;
    public string footEquipmentCode;
    public int gold;
    public string[] inventory = new string[5];

    public PlayerInventory()
    {
        // 초기화 로직
        playerPosition = Vector2Int.zero;
        leftHandEquipmentCode = "";
        rightHandEquipmentCode = "";
        helmatEquipmentCode = "";
        armorEquipmentCode = "";
        footEquipmentCode = "";
        gold = 0;
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = "";
        }
    }
}


[Serializable]
public class CharacterPreset
{
    public GameObject CharacterPrefab;
    public string Code;
}