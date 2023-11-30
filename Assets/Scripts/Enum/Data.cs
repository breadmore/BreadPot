using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 스텟 데이터
public class CharacterAttributes
{
    public string Name { get; set; }
    public string Code { get; set; }
    // 주 능력치
    public int AttackDamage { get; set; }
    public int Defense { get; set; }
    public int MagicalDefense { get; set; }
    public int Health { get; set; }

    // 주사위 굴림 능력치
    public int Strength { get; set; }
    public int Vitality { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Talent { get; set; }
    public int Agility { get; set; }
    public int Luck { get; set; }
    public int EXP { get; set; }
}

[System.Serializable]
public class CharacterPreset
{
    public GameObject CharacterPrefab;
    public string Code;
}