using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyData : MonoBehaviour
{
    public List<DummyEnemy> dummyEnemies = new List<DummyEnemy>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 여기에 필요한 업데이트 로직 추가
    }
}

[System.Serializable]
public class DummyEnemy
{
    public string name;
    public GameObject dummyPrefab;
}