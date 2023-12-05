using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridParent : Singleton<PlayerGridParent>
{
    public List<PlayerGrid> playerGrids;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshPlayerGrid()
    {
        for(int i=0; i<Consts.MAX_NUMBER_PARTY; i++)
        {
            playerGrids[i].nameText.text = PlayerDataManager.instance.characterAttributes[i].Name;
            playerGrids[i].attackDamageText.text = PlayerDataManager.instance.characterAttributes[i].AttackDamage.ToString();
            playerGrids[i].defenseText.text = PlayerDataManager.instance.characterAttributes[i].Defense.ToString();
            playerGrids[i].magicDefenseText.text = PlayerDataManager.instance.characterAttributes[i].MagicalDefense.ToString();
            playerGrids[i].evasionText.text = PlayerDataManager.instance.characterAttributes[i].Evasion.ToString();
            playerGrids[i].goldText.text = PlayerDataManager.instance.playerInventories[i].gold.ToString();
        }
    }
}
