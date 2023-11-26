using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private bool battleStart = false;
    private float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.instance.StartBattleScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleStart)
        {
            foreach (GameObject player in CharacterManager.instance.players)
            {
                // 만약 원하는 위치에 도달하면 이동 중지 또는 다른 동작 수행
                if (player.transform.position.x <= -3.0f)
                {
                    player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
            }
            //battleStart = true;
        }
    }

    public void StartBattleEffect()
    {

        
        battleStart = true;


    }
}
