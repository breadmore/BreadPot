using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterDataWrapper
{
    public List<Character> Character;
}

public class LoadCharacterData : MonoBehaviour
{
    public TextAsset jsonFile; // Drag and drop your JSON file in the Unity Editor.
    private Dictionary<string, Character> characterDictionary;

    void Start()
    {
        if (jsonFile != null)
        {
            LoadJsonData(jsonFile.text);
        }
        else
        {
            Debug.LogError("JSON file not assigned!");
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
            Debug.LogError("Failed to parse JSON data or no characters found!");
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
            Debug.LogError($"Character with code {code} not found!");
            return null;
        }
    }

    void DisplayCharacterData(string code)
    {
        Character characterData = GetCharacterDataWithCode(code);

        if (characterData != null)
        {
            Debug.Log($"Character Code: {characterData.Code}");
            Debug.Log($"Character Name: {characterData.Name}");
            // 추가적인 데이터 출력 로직 추가
        }
    }
}