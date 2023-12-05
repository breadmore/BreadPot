using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTest : MonoBehaviour
{
    public SPUM_SpriteList test;
    // Start is called before the first frame update
    void Start()
    {
        ChangeHairEquipment();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 예시: 클릭 시 머리카락 장비를 변경
            ChangeHairEquipment();
        }
    }

    void ChangeHairEquipment()
    {
        // 예시: 변경하고자 하는 머리카락 인덱스와 새로운 파일 경로
        int hairIndexToChange = 0; // 변경하고자 하는 머리카락 인덱스
        string newHairPath = "Assets/Resources/SPUM/SPUM_Sprites/Items/4_Helmet/Helmet_1.png"; // 새로운 머리카락 파일 경로

        // 해당 머리카락에 대한 파일 경로 변경
        test._hairListString[hairIndexToChange] = newHairPath;

        // 변경된 파일 경로를 실제 Sprite로 동기화
        test.SyncPath(test._hairList, test._hairListString);
    }
}
