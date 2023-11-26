using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonDontDestroy<CharacterManager>
{
    
    public List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
