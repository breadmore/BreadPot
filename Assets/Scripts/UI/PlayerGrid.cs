using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerGrid : MonoBehaviour
{
    // 초상화
    [Header("초상화")]
    public GameObject portraitImage;
    public Slider healthBar;
    public Slider expBar;

    // 집중력
    [Header("집중력")]
    public GameObject concentrationGridParent;
    public GameObject concentrationGridPrefab;

    // 플레이어 데이터
    [Header("플레이어")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI attackDamageText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI magicDefenseText;
    public TextMeshProUGUI evasionText;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
