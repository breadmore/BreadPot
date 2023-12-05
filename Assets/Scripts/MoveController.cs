using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MoveController : MonoBehaviour
{
    public GameObject nowTurnPlayer;

    public Tilemap tilemap;
    public float moveSpeed = 5.0f;

    private bool isMoving = false; // 이동 중인지 여부를 나타내는 변수
    private List<Vector2Int> currentPath; // 이동 경로를 담은 리스트
    private int currentPathIndex; // 현재 이동중인 경로 인덱스
    public TileBase Water;

    private void Update()
    {
        if(nowTurnPlayer == null)
        {
            return;
        }
        // 이동 중이 아닐 때만 클릭 이벤트 처리
        if (!GameManager.instance.onUI && !isMoving && Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 클릭된 위치가 Tilemap 내에 있는지 확인 및 타일이 설치된 위치인지 확인
            if (IsTileInstalledAtPosition(clickPosition))
            {
                // 내 위치
                Vector3Int startPlayerPosition = tilemap.WorldToCell(nowTurnPlayer.transform.position);
                Vector3Int goalPlayerPosition = tilemap.WorldToCell(clickPosition);

                // Vector2Int 형태로 변환함
                Vector2Int startCellPosition = new Vector2Int(startPlayerPosition.x, startPlayerPosition.y);
                Vector2Int goalCellPosition = new Vector2Int(goalPlayerPosition.x, goalPlayerPosition.y);


                if (startCellPosition == goalCellPosition)
                    return;

                Node[,] grid = TilemapToNodeGrid(tilemap);

                //TileBase clickedTile = tilemap.GetTile(goalPlayerPosition);


                currentPath = AStar.FindPath(grid, startCellPosition, goalCellPosition);
                if (currentPath.Count > 0)
                {
                    currentPathIndex = 0;
                    StartCoroutine(FollowPath());


                }
            }
        }
    }

    private IEnumerator FollowPath()
    {
        isMoving = true;

        // 경로 인덱스를 전부 탐색했거나 이동가능 횟수를 다 쓸떄까지 반복
        while (currentPathIndex < currentPath.Count && GameManager.instance.canMoveCount>=0)
        {

            Vector2Int targetGridPosition = currentPath[currentPathIndex];

            Vector3 targetPosition = tilemap.GetCellCenterWorld(new Vector3Int(targetGridPosition.x, targetGridPosition.y, 0));

            // 방향에 따라 캐릭터 전환
            if (targetPosition.x > nowTurnPlayer.transform.position.x)
            {
                FlipCharacter(false); // 오른쪽으로 이동할 때는 Flip하지 않음
            }
            else
            {
                FlipCharacter(true); // 왼쪽으로 이동할 때 Flip
            }

            while (Vector2.Distance(nowTurnPlayer.transform.position, targetPosition) > 0.1f)
            {
                nowTurnPlayer.transform.position = Vector2.MoveTowards(nowTurnPlayer.transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            GameManager.instance.canMoveCount--;
            PlayerDataManager.instance.playerInventories[GameManager.instance.currentPlayerIndex].playerPosition = currentPath[currentPathIndex];
            print(GameManager.instance.currentPlayerIndex);
            print(currentPathIndex);

            currentPathIndex++;
            
            GameManager.instance.CheckCollision();
            yield return null;
        }

        isMoving = false;
    }

    // 클릭된 위치에 타일이 설치되어 있는지 확인하는 함수
    private bool IsTileInstalledAtPosition(Vector2 clickPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(clickPosition);
        TileBase tile = tilemap.GetTile(cellPosition);

        return tile != null;
    }



    private Node[,] TilemapToNodeGrid(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;

        Node[,] nodeGrid = new Node[bounds.size.x, bounds.size.y];

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y);

                TileBase tile = tilemap.GetTile(cellPosition);
                bool isWalkable = (tile != null && tile != Water);

                //print("검사중인 셀 포지션 " + cellPosition + "? : " +isWalkable);
                nodeGrid[x, y] = new Node(new Vector2Int(x, y), isWalkable);
            }
        }

        return nodeGrid;
    }

    public Vector3 CellToWorld(Vector3Int cellPosition)
    {
        // 타일맵의 Grid 정보 가져오기
        GridLayout gridLayout = tilemap.layoutGrid;

        // 셀의 중심 좌표를 월드 좌표로 변환
        Vector3 cellCenterWorld = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(cellPosition + new Vector3(0.5f, 0.5f, 0)));

        return cellCenterWorld;
    }


    void FlipCharacter(bool isFacingLeft)
    {
        // 캐릭터의 스케일을 반전
        Vector2 scale = nowTurnPlayer.transform.localScale;
        scale.x = isFacingLeft ? 1 : -1;
        nowTurnPlayer.transform.localScale = scale;
    }
}