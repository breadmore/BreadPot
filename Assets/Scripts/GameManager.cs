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


    // Start is called before the first frame update
    void Start()
    {
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
        print("next turn");

        timeLine++;
        RefreshMap();
        MovementUI.instance.DeterminationMovement();
    }

    public void RefreshMap()
    {
        //
        if (timeLine % Consts.REFRESH_MAP_TIME == 0)
        {
            print("Refresh");
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
