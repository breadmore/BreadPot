using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathHighlighter : MonoBehaviour
{
    public Material highlightedMaterial;
    public Vector2 mousePosition;
    private Tilemap highlightedTilemap;

    private Vector3Int lastHighlightedCell;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // 오브젝트 감지
        if (hit.collider != null)
        {
            Tilemap tilemap = hit.collider.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                // 마우스가 다른 셀로 이동했을 때 복구
                if (tilemap != highlightedTilemap || lastHighlightedCell != tilemap.WorldToCell(mousePosition))
                {
                    RestoreTilemap();
                }

                // 감지된 오브젝트가 Tilemap이라면 강조 효과 적용
                HighlightPath(tilemap, mousePosition);
            }
        }
        else
        {
            // 마우스가 Tilemap 위에서 벗어날 때 복구
            RestoreTilemap();
        }
    }

    void HighlightPath(Tilemap tilemap, Vector3 mousePosition)
    {
        // 마우스 위치를 world 좌표에서 tilemap의 local 좌표로 변환
        Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

        // 강조 효과 적용
        tilemap.SetTileFlags(cellPosition, TileFlags.None);
        tilemap.SetColor(cellPosition, highlightedMaterial.color);

        // 저장
        highlightedTilemap = tilemap;
        lastHighlightedCell = cellPosition;
    }

    void RestoreTilemap()
    {
        // 이전에 강조된 타일이 있으면 복구
        if (highlightedTilemap != null)
        {
            highlightedTilemap.SetTileFlags(lastHighlightedCell, TileFlags.None);
            highlightedTilemap.SetColor(lastHighlightedCell, Color.white);

            // 초기화
            highlightedTilemap = null;
            lastHighlightedCell = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);
        }
    }
}