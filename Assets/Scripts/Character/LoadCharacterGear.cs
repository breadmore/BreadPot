using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterGearData
{
    public List<GearData> Gear;
}

public class LoadCharacterGear : Singleton<LoadCharacterGear>
{
    public TextAsset jsonFile;
    private Dictionary<string, GearData> gearDictionary;

    void Start()
    {
        if (jsonFile != null)
        {
            LoadJsonData(jsonFile.text);
        }
        else
        {
            Debug.LogError("JSON 파일 읽기 실패");
        }
    }

    void LoadJsonData(string jsonString)
    {
        CharacterGearData characterGearData = JsonUtility.FromJson<CharacterGearData>(jsonString);

        if (characterGearData != null && characterGearData.Gear != null)
        {
            gearDictionary = new Dictionary<string, GearData>();

            foreach (GearData gear in characterGearData.Gear)
            {
                gearDictionary.Add(gear.Code, gear);
            }
        }
        else
        {
            Debug.LogError("데이터 불러오기 실패");
        }
    }

    public GearData GetGearDataWithCode(string code)
    {
        if (gearDictionary.ContainsKey(code))
        {
            return gearDictionary[code];
        }
        else
        {
            Debug.LogError($"캐릭터 코드 {code} 찾을수 없음");
            return null;
        }
    }
}
