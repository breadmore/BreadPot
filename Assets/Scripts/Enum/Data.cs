using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string Name;
    public string Code;
    public int AttackDamage;
    public int Defense;
    public int MagicalDefense;
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
    public string hatEquipmentCode;
    public string chestplateEquipmentCode;
    public string shoesEquipmentCode;
    public string ringEquipmentCode;
    public string necklaceEquipmentCode;
    public int money;
    public string[] inventory = new string[5];

    public PlayerInventory()
    {
        // 초기화 로직
        playerPosition = Vector2Int.zero;
        leftHandEquipmentCode = "";
        rightHandEquipmentCode = "";
        hatEquipmentCode = "";
        chestplateEquipmentCode = "";
        shoesEquipmentCode = "";
        ringEquipmentCode = "";
        necklaceEquipmentCode = "";
        money = 0;
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