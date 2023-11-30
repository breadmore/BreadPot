using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterPool : SingletonDontDestroy<CharacterPool>
{
    public LoadCharacterData loadCharacterData;
    public TextMeshProUGUI characterInfoText;

    public List<Character> characters;

    public List<CharacterPreset> characterPresets;

    void Start()
    {
        loadCharacterData = GetComponent<LoadCharacterData>();
        for (int i = 0; i < 4; i++)
        {
            characters.Add(loadCharacterData.GetCharacterDataWithCode((i+1).ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}