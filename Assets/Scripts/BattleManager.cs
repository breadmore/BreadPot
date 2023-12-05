using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;


public class BattleManager : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase selectedTile;

    public Color highlightColor; // 강조 할 타일 색

    public GameObject objectPrefab;
    public GameObject enemyPrefab;

    private bool battleStart = false;
    private float moveSpeed = 5.0f;

    public class PositionData
    {
        public Vector3Int[] positions;

        public PositionData(Vector3Int[] positions)
        {
            this.positions = positions;
        }
    }
    // 2D 타일에서 오브젝트들이 배치될 타일의 포지션을 저장
    private PositionData[,] positions = new PositionData[2, 2];

    // 사용된 타일의 포지션 저장 (중복 방지)
    private List<Vector3Int> usedPositions = new List<Vector3Int>();


    // positions [Object Type] [Attack Range]
    private void InitializePositions()
    {
        positions[0, 0] = new PositionData(new Vector3Int[]
        {
            new Vector3Int(3, 4, 0),
            new Vector3Int(4, 6, 0),
            new Vector3Int(5, 8, 0),
            new Vector3Int(6, 10, 0)
        });

        positions[0, 1] = new PositionData(new Vector3Int[]
        {
            new Vector3Int(5, 4, 0),
            new Vector3Int(6, 6, 0),
            new Vector3Int(7, 8, 0),
            new Vector3Int(8, 10, 0)
        });

        positions[1, 0] = new PositionData(new Vector3Int[]
        {
            new Vector3Int(17, 4, 0),
            new Vector3Int(16, 6, 0),
            new Vector3Int(15, 8, 0),
            new Vector3Int(14, 10, 0)
        });

        positions[1, 1] = new PositionData(new Vector3Int[]
        {
            new Vector3Int(15, 4, 0),
            new Vector3Int(14, 6, 0),
            new Vector3Int(13, 8, 0),
            new Vector3Int(12, 10, 0)
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        StartBattleEffect();
        FillTilemap();
        InitializePositions();
        HighlightTilemap();
        PlaceObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBattleEffect()
    {
        battleStart = true;

    }

    private void FillTilemap()
    {
        //Vector3Int tilemapSize = tilemap.size;

        for (int x = 0; x <= 20; x++)
        {
            for (int y = 0; y <= 15; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, selectedTile);
            }
        }
    }

    void PlaceObjects()
    {
        //0
        SetObject(objectPrefab,AttackRange.Long, ObjectType.Player);
        SetObject(objectPrefab,AttackRange.Long, ObjectType.Player);

        //1
        SetObject(objectPrefab,AttackRange.Short, ObjectType.Player);
        SetObject(objectPrefab, AttackRange.Short, ObjectType.Player);

        //0
        SetObject(enemyPrefab, AttackRange.Long, ObjectType.Enemy);
        SetObject(enemyPrefab, AttackRange.Long, ObjectType.Enemy);

        //1
        SetObject(enemyPrefab, AttackRange.Short, ObjectType.Enemy);
        SetObject(enemyPrefab, AttackRange.Short, ObjectType.Enemy);
    }

    private void SetObject(GameObject _gameObject, AttackRange attackRange , ObjectType objectType)
    {
        Vector3 tilePosition;

        Vector3Int[] setPosition = positions[(int)objectType, (int)attackRange].positions;

        setPosition = setPosition.OrderBy(x => Random.value).ToArray();

        foreach (Vector3Int position in setPosition)
        {
            if (!usedPositions.Contains(position))
            {
                tilePosition = tilemap.GetCellCenterWorld(position);

                GameObject spawnObject;

                // 오브젝트를 해당 좌표에 생성
                spawnObject = Instantiate(_gameObject, tilePosition, Quaternion.identity);
                Vector3 objectScale = spawnObject.transform.localScale;

                // 플레이어면 좌우반전
                objectScale.x = objectType == ObjectType.Player ? objectScale.x *= -1 : objectScale.x *= 1;
                spawnObject.transform.localScale = objectScale;

                // 이 좌표 저장
                usedPositions.Add(position);

                break;
            }
        }
    }

    void HighlightTilemap()
    {
        // PositionData 배열을 평면화 해서 저장
        var allPositions = positions.Cast<PositionData>().SelectMany(p => p.positions);

        foreach (Vector3Int position in allPositions)
        {
            HighlightTile(position);
        }
    }

    void HighlightTile(Vector3Int position)
    {
        TileBase tile = tilemap.GetTile(position);

        if (tile != null)
        {
            BoundsInt bounds = new BoundsInt(position.x, position.y, 0, 1, 1, 1);

            for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
            {
                for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
                {
                    Color color = highlightColor;
                    tilemap.SetTileFlags(new Vector3Int(x, y, 0), TileFlags.None);
                    tilemap.SetColor(new Vector3Int(x, y, 0), color);
                }
            }
        }
    }
}
