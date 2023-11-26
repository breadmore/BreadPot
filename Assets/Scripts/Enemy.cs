using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int spawnTime;
    private int currentTimeLine;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = GameManager.instance.ReturnTimeLine();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLine = GameManager.instance.ReturnTimeLine();   
    
        if(spawnTime+Consts.DELETE_ENEMY_TIME == currentTimeLine)
        {
            Destroy(gameObject);
        }
    }
}
