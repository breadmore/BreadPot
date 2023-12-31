using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectGridParent : MonoBehaviour
{
    public bool[] isGridReady; // 해당 그리드가 준비 됐는지

    public List<CharacterSelectGrid> characterSelectGrids;
    public bool[] isCharacterSelect;
    [SerializeField]
    private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartButton);
        isGridReady = new bool[Consts.MAX_NUMBER_PARTY];
        isCharacterSelect = new bool[CharacterPool.instance.characterPresets.Count];
        for (int i=0; i<Consts.MAX_NUMBER_PARTY; i++)
        {
            isGridReady[i] = false;
            characterSelectGrids[i].gridIndex = i;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        startButton.interactable = IsAnyCharacterNotSelected();
    }

    private bool IsAnyCharacterNotSelected()
    {
        foreach (bool isSelected in isGridReady)
        {
            if (!isSelected)
            {
                return false;
            }
        }
        return true;
    }

    public void ToggleSelectGrids(int gridIndex)
    {
        isGridReady[gridIndex] = !isGridReady[gridIndex];
    }

    
    public void StartButton()
    {
        
        LoadSceneManager.instance.LoadScene("Game");
    }


}
