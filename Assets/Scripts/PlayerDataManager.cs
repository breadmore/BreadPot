using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : SingletonDontDestroy<PlayerDataManager>
{
    public LoadCharacterData loadCharacterData;
    public List<Character> characterAttributes = new List<Character>();
    public List<PlayerInventory> playerInventories = new List<PlayerInventory>();

    public void CreatePlayers()
    {
        characterAttributes.Clear();
        playerInventories.Clear();

        for (int i = 0; i < Consts.MAX_NUMBER_PARTY; i++)
        {
            Character newCharacterAttributes = new Character();
            PlayerInventory newPlayerInventory = new PlayerInventory();
            characterAttributes.Add(newCharacterAttributes);
            playerInventories.Add(newPlayerInventory);
            characterAttributes[i] = loadCharacterData.GetCharacterDataWithCode(PlayerPrefs.GetString("Character" + (i + 1).ToString()));
        }

    }

    // 특정 플레이어 데이터 불러오기
    public PlayerInventory GetPlayerInventory(int playerIndex)
    {
        if (playerIndex < 0 || playerIndex >= playerInventories.Count)
        {
            Debug.LogError("Invalid player index");
            return null;
        }

        return playerInventories[playerIndex];
    }

    // 특정 플레이어 데이터 저장
    public void SavePlayerData(int playerIndex, PlayerInventory playerInventory)
    {
        if (playerIndex < 0 || playerIndex >= playerInventories.Count)
        {
            Debug.LogError("Invalid player index");
            return;
        }

        playerInventories[playerIndex] = playerInventory;
    }

    private void Start()
    {
        if (loadCharacterData == null)
        {
            Debug.LogError("LoadCharacterData not found!");
            return;
        }
        else
        {
            CreatePlayers();
        }
    }
}