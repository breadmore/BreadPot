using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EnemyManager : Singleton<EnemyManager>
{
    public EnemyData enemyData;
    public Tilemap tilemap; // 적을 소환할 Tilemap에 대한 참조

    public List<GameObject> enemies = new List<GameObject>();

    public void SpawnEnemy()
    {
        foreach (DummyEnemy dummyEnemy in enemyData.dummyEnemies)
        {
            // 타일맵 내 설치된 타일의 셀 얻기
            Vector3Int randomCell = GetRandomOccupiedCell(tilemap);

            // 얻은 셀의 중심 위치 계산
            Vector3 spawnPosition = tilemap.GetCellCenterWorld(randomCell);

            // 데이터를 기반으로 게임 오브젝트 생성
            GameObject enemyObject = Instantiate(dummyEnemy.dummyPrefab, spawnPosition, Quaternion.identity);

            // 생성된 오브젝트의 이름 설정
            enemyObject.name = dummyEnemy.name;

            enemies.Add(enemyObject);
        }
    }

    // 타일맵 내 설치된 타일의 셀을 얻기 위한 함수
    private Vector3Int GetRandomOccupiedCell(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int randomCell;

        // 설치된 타일이 있는 셀 리스트
        List<Vector3Int> occupiedCells = new List<Vector3Int>();

        // 타일맵 내에서 설치된 타일이 있는 셀 찾기
        for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        {
            for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            {
                Vector3Int cell = new Vector3Int(x, y, 0);
                if (tilemap.GetTile(cell) != null)
                {
                    occupiedCells.Add(cell);
                }
            }
        }

        // 설치된 타일이 있는 셀 중에서 무작위로 선택
        if (occupiedCells.Count > 0)
        {
            randomCell = occupiedCells[Random.Range(0, occupiedCells.Count)];
        }
        else
        {
            // 설치된 타일이 하나도 없을 경우에는 타일맵 전체 중에서 무작위로 선택
            int randomX = Random.Range(bounds.x, bounds.x + bounds.size.x);
            int randomY = Random.Range(bounds.y, bounds.y + bounds.size.y);
            randomCell = new Vector3Int(randomX, randomY, 0);
        }

        return randomCell;
    }

}
