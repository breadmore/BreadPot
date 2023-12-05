using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class GameManager : Singleton<GameManager>
{
    public bool onUI=false;

    private int timeLine;


    public EnemyManager enemyManager;
    private TileMapCollision tileMapCollision;
    public int currentPlayerIndex; // 현재 플레이어 인덱스

    public int canMoveCount;
    // Start is called before the first frame update
    void Start()
    {
        
        currentPlayerIndex = -1;
        timeLine = 0;
        tileMapCollision = transform.GetComponent<TileMapCollision>();
        NextTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ReturnTimeLine()
    {
        return timeLine;
    }

    public void NextTurn()
    {
        // 다음 플레이어 
        currentPlayerIndex = (++currentPlayerIndex) % 4;
        // 턴 이동
        timeLine++;
        // 맵 생성
        RefreshMap();

        CharacterManager.instance.SetPlayerTurn(currentPlayerIndex);
        CameraFollow.instance.SwitchPlayer(currentPlayerIndex);

        canMoveCount = 0;
        MovementUI.instance.DeterminationMovement();

        PlayerInfo.instance.RefreshPlayerInfo(currentPlayerIndex);
    }

    public void RefreshMap()
    {
        //
        if (timeLine % Consts.REFRESH_MAP_TIME == 0)
        {
            EnemyManager.instance.SpawnEnemy();
        }
    }

    public void CheckCollision()
    {
        tileMapCollision.CheckCollision();
    }
    public void DeleteEnemy()
    {
        
    }

    public void DeleteEvent()
    {

    }

}
