using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MoveController : MonoBehaviour
{
    public Tilemap tilemap;
    public float moveSpeed = 5.0f;

    private bool isMoving = false; // 이동 중인지 여부를 나타내는 변수
    private List<Vector2Int> currentPath; // 이동 경로를 담은 리스트
    private int currentPathIndex; // 현재 이동중인 경로 인덱스

    private void Start()
    {
    }
    private void Update()
    {
        // 이동 중이 아닐 때만 클릭 이벤트 처리
        if (!GameManager.instance.onUI && !isMoving && Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 클릭된 위치가 Tilemap 내에 있는지 확인 및 타일이 설치된 위치인지 확인
            if (IsTileInstalledAtPosition(clickPosition))
            {
                // 내 위치
                Vector3Int startPlayerPosition = tilemap.WorldToCell(transform.position);
                Vector3Int goalPlayerPosition = tilemap.WorldToCell(clickPosition);

                // Vector2Int 형태로 변환함
                Vector2Int startCellPosition = new Vector2Int(startPlayerPosition.x, startPlayerPosition.y);
                Vector2Int goalCellPosition = new Vector2Int(goalPlayerPosition.x, goalPlayerPosition.y);


                if (startCellPosition == goalCellPosition)
                    return;

                int[,] grid = TilemapToGrid(tilemap);
                Node[,] nodeGrid = new Node[grid.GetLength(0), grid.GetLength(1)];
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        nodeGrid[x, y] = new Node(new Vector2Int(x, y), grid[x, y] == 1);
                    }
                }

                //BoundsInt cellBounds = tilemap.cellBounds;

                //int startX = cellBounds.x;
                //int startY = cellBounds.y;
                //int endX = cellBounds.x + cellBounds.size.x;
                //int endY = cellBounds.y + cellBounds.size.y;

                //Debug.Log("Grid Cell Range: X(" + startX + " to " + endX + "), Y(" + startY + " to " + endY + ")");

                currentPath = AStar.FindPath(nodeGrid, startCellPosition, goalCellPosition);
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
        while (currentPathIndex < currentPath.Count)
        {

            Vector2Int targetGridPosition = currentPath[currentPathIndex];

            Vector3 targetPosition = tilemap.GetCellCenterWorld(new Vector3Int(targetGridPosition.x, targetGridPosition.y, 0));

            while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            currentPathIndex++;
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

    

    private int[,] TilemapToGrid(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;

        int[,] grid = new int[bounds.size.x, bounds.size.y];

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x + bounds.x, y + bounds.y);
                TileBase tile = tilemap.GetTile(cellPosition);
                grid[x, y] = (tile != null) ? 1 : 0;
            }
        }

        return grid;
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
        Vector2 scale = transform.localScale;
        scale.x = isFacingLeft ? 1 : -1;
        transform.localScale = scale;
    }
}