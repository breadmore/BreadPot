using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterManager : Singleton<CharacterManager>
{
    private MoveController moveController;
    public Tilemap tilemap;

    public List<GameObject> players = new List<GameObject>();
    public List<string> characterCode = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerWithCode();
        Vector3Int startPositionTilemapIndex = new Vector3Int(10, 7, 0); // 타일맵에서 시작 위치로 사용할 타일의 인덱스
        // 타일맵의 월드 좌표를 가져오기
        Vector3 startPosition = tilemap.GetCellCenterWorld(startPositionTilemapIndex);

        moveController = GetComponent<MoveController>();
        CameraFollow.instance.SetPlayer();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlayerWithCode()
    {
        for (int i=0; i<Consts.MAX_NUMBER_PARTY; i++)
        {
            characterCode.Add(LoadData("Character" + (i + 1).ToString()));
            GameObject gameObject = Instantiate(GetCharacterPrefabWithCode(characterCode[i]), transform);
            players.Add(gameObject);
        }


    }

    public GameObject GetCharacterPrefabWithCode(string code)
    {
        foreach (CharacterPreset preset in CharacterPool.instance.characterPresets) // yourCharacterPresetsArray는 캐릭터 프리셋 배열 또는 리스트
        {
            if (preset.Code == code)
            {
                return preset.CharacterPrefab;
            }
        }

        return null;
    }

    public void SetPlayerTurn(int currentPlayerIndex)
    {
        moveController.nowTurnPlayer = players[currentPlayerIndex];
    }

    string LoadData(string key)
    {
        return PlayerPrefs.GetString(key, "");
    }


}
