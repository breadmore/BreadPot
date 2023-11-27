using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CameraFollow : Singleton<CameraFollow>
{
    public List<Transform> players = new List<Transform>();
    private int currentPlayerIndex = 0;

    private void Start()
    {
        // players 리스트를 초기화
        players = CharacterManager.instance.players.Select(player => player.transform).ToList();
    }

    private void Update()
    {
        if (players == null || currentPlayerIndex >= players.Count)
        {
            return;
        }

        // 선택된 플레이어를 따라가도록 설정
        transform.position = new Vector3(players[currentPlayerIndex].position.x,
            players[currentPlayerIndex].position.y, transform.position.z);
    }

    public void SetPlayer()
    {
        // players 리스트를 초기화
        players = CharacterManager.instance.players.Select(player => player.transform).ToList();
    }

    public void SwitchPlayer(int _currentPlayerIndex)
    {
        currentPlayerIndex = _currentPlayerIndex;
    }
}
