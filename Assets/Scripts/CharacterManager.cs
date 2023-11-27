using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    private MoveController moveController;
    public List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        moveController = GetComponent<MoveController>();
        CameraFollow.instance.SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerTurn(int currentPlayerIndex)
    {
        moveController.nowTurnPlayer = players[currentPlayerIndex];
    }

    public void StartBattleScene()
    {
        foreach (GameObject player in players)
        {
            player.transform.position = new Vector2(-10f, 0);
            Vector2 scale = player.transform.localScale;
            scale.x = -1;
        }
    }

}
