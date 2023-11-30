using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapCollision : MonoBehaviour
{
    public Tilemap tilemap;  // Unity 에디터에서 할당해야 하는 타일맵
    public GameObject player;
    public GameObject InformationUI;
    private Collider2D playerCollider;
    private void Start()
    {
        
    }
    public void CheckCollision()
    {
        player = CharacterManager.instance.players[GameManager.instance.currentPlayerIndex];
        playerCollider = player.GetComponent<Collider2D>();

        // 타일맵 상에서 플레이어와 "Enemy" 태그를 가진 오브젝트가 동시에 충돌하는지 확인
        Bounds playerBounds = playerCollider.bounds;
        Vector2 playerPosition = playerBounds.center;

        int colliderCount = Physics2D.OverlapCollider(playerCollider, new ContactFilter2D().NoFilter(), new Collider2D[10]);

        // 배열을 사용하여 충돌한 Collider2D에 접근
        Collider2D[] colliders = new Collider2D[10];
        Physics2D.OverlapCollider(playerCollider, new ContactFilter2D().NoFilter(), colliders);

        for (int i = 0; i < colliderCount; i++)
        {
            if (colliders[i].CompareTag("Enemy"))
            {
                //플레이어와 "Enemy" 오브젝트가 동시에 충돌할 때
                Debug.Log("플레이어와 Enemy 오브젝트가 동시에 충돌했습니다!");

                InformationUI.SetActive(true);
                GameManager.instance.onUI = true;

            }
        }
    }

    public void JoinBattle()
    {
        InformationUI.SetActive(false);
        GameManager.instance.onUI = false;
        LoadSceneManager.instance.LoadScene("Battle");
    }

    public void Run()
    {
        InformationUI.SetActive(false);
        GameManager.instance.onUI = false;
    }


}
