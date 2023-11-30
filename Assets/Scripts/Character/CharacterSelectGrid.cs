using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterSelectGrid : MonoBehaviour
{
    
    // 준비 확인용 
    public Sprite falseImage;
    public Sprite trueImage;
    public Image readyImageComponent;

    public TextMeshProUGUI characterName;
    public Transform characterPosition;
    
    public Button leftButton;
    public Button rightButton;

    public Button readyButton;

    private GameObject characterPreset;

    public int gridIndex; // 현재 그리드의 인덱스
    private int currentIndex = 0; // 현재 선택한 영웅 인덱스

    private CharacterSelectGridParent characterSelectGridParent; // 부모 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        characterSelectGridParent = transform.parent.GetComponent<CharacterSelectGridParent>();

        readyButton.onClick.AddListener(ReadyButton);
        leftButton.onClick.AddListener(LeftButton);
        rightButton.onClick.AddListener(RightButton);
        ShowCharacterData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RightButton()
    {
        currentIndex = ++currentIndex % 4;
        ShowCharacterData();
    }

    private void LeftButton()
    {
        currentIndex = (currentIndex - 1 + Consts.MAX_NUMBER_PARTY) % Consts.MAX_NUMBER_PARTY;
        ShowCharacterData();
    }

    // 해당 그리드 준비 버튼
    private void ReadyButton()
    {
        if (!characterSelectGridParent.isCharacterSelect[currentIndex])
        {
            characterSelectGridParent.ToggleSelectGrids(gridIndex);
            characterSelectGridParent.isCharacterSelect[currentIndex] = true;
            UpdateInteractability();
            UpdateReadyImage();
        }else if(characterSelectGridParent.isCharacterSelect[currentIndex] &&
            characterSelectGridParent.isGridReady[gridIndex])
        {
            characterSelectGridParent.ToggleSelectGrids(gridIndex);
            characterSelectGridParent.isCharacterSelect[currentIndex] = false;
            UpdateInteractability();
            UpdateReadyImage();
        }



    }
    private void ShowCharacterData()
    {
        if (CharacterPool.instance.characters != null)
        {
            if (characterPreset != null)
            {
                Destroy(characterPreset);
            }
            Character selectCharacter = CharacterPool.instance.characters[currentIndex];
            characterPreset = Instantiate(CharacterPool.instance.characterPresets[currentIndex].CharacterPrefab,
               characterPosition.position, Quaternion.identity, GameObject.Find("Canvas").transform.parent);

        }
    }

    public void UpdateInteractability()
    {
        leftButton.interactable = !characterSelectGridParent.isGridReady[gridIndex];
        rightButton.interactable = !characterSelectGridParent.isGridReady[gridIndex];
    }

    private void UpdateReadyImage()
    {
        if (characterSelectGridParent.isCharacterSelect[currentIndex])
        {
            // true이면 trueImage를 나타냄
            readyImageComponent.sprite = trueImage;
        }
        else
        {
            // false이면 falseImage를 나타냄
            readyImageComponent.sprite = falseImage;
        }
    }


}
