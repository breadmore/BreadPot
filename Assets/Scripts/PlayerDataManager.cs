using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : SingletonDontDestroy<PlayerDataManager>
{
    public List<Character> characterAttributes = new List<Character>();
    public List<PlayerInventory> playerInventories = new List<PlayerInventory>();

    public void CreatePlayers()
    {
        characterAttributes.Clear();
        playerInventories.Clear();

        for (int i = 0; i < Consts.MAX_NUMBER_PARTY; i++)
        {
            Character newCharacterAttributes = new Character();
            PlayerInventory newPlayerInventory = LoadPlayerInventory(PlayerPrefs.GetString("Character" + (i + 1).ToString()));
            characterAttributes.Add(newCharacterAttributes);
            playerInventories.Add(newPlayerInventory);
            characterAttributes[i] = LoadCharacterData.instance.GetCharacterDataWithCode(PlayerPrefs.GetString("Character" + (i + 1).ToString()));
            
        }
        PlayerGridParent.instance.RefreshPlayerGrid();
    }

    public PlayerInventory LoadPlayerInventory(string code)
    {
        PlayerInventory playerInventory = new PlayerInventory();
        GearData gearData = LoadCharacterGear.instance.GetGearDataWithCode(code);

        playerInventory.leftHandEquipmentCode = gearData.WeaponLeft;
        playerInventory.rightHandEquipmentCode = gearData.WeaponRight;
        playerInventory.helmatEquipmentCode = gearData.Helmat;
        playerInventory.armorEquipmentCode = gearData.Armor;
        playerInventory.footEquipmentCode = gearData.Foot;
        return playerInventory;
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
        // 저장 로직 여기에 넣을 생각입니다
        }

    private void Start()
    {

        CreatePlayers();
    }
}