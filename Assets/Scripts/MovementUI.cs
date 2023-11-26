using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUI : Singleton<MovementUI>
{
    public MoveStat moveIconPrefab;

    public int dummyMovementStat = 5;
    public float dummyMoveStat = 70;

    public List<MoveStat> moveStats = new List<MoveStat>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < dummyMovementStat; i++)
        {
            MoveStat moveStat = Instantiate(moveIconPrefab,transform);
            moveStats.Add(moveStat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeterminationMovement()
    {
        foreach(MoveStat list in moveStats)
        {
            list.determinationMoveStat(dummyMoveStat);
        }
    }
}
