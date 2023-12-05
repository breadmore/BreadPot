using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDataWrapper
{
    public List<Character> Character;
}

public class LoadCharacterData : Singleton<LoadCharacterData>
{
    public TextAsset jsonFile;
    private Dictionary<string, Character> characterDictionary;

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
        CharacterDataWrapper characterDataWrapper = JsonUtility.FromJson<CharacterDataWrapper>(jsonString);

        if (characterDataWrapper != null && characterDataWrapper.Character != null)
        {
            characterDictionary = new Dictionary<string, Character>();

            foreach (Character character in characterDataWrapper.Character)
            {
                characterDictionary.Add(character.Code, character);
            }
        }
        else
        {
            Debug.LogError("데이터 불러오기 실패");
        }
    }

    public Character GetCharacterDataWithCode(string code)
    {
        if (characterDictionary.ContainsKey(code))
        {
            return characterDictionary[code];
        }
        else
        {
            Debug.LogError($"캐릭터 코드 {code} 찾을수 없음");
            return null;
        }
    }
}