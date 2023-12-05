using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInfo : Singleton<PlayerInfo>
{

    public TextMeshProUGUI nameText;
    public Slider healthBar;
    public Slider expBar;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI vitalityText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI wisdomText;
    public TextMeshProUGUI talentText;
    public TextMeshProUGUI agilityText;
    public TextMeshProUGUI luckText;

    // 플레이어 정보 출력
    public void RefreshPlayerInfo(int currentPlayer)
    {

        nameText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Name;
        strengthText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Strength.ToString();
        vitalityText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Vitality.ToString();
        intelligenceText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Intelligence.ToString();
        wisdomText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Wisdom.ToString();
        talentText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Talent.ToString();
        agilityText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Agility.ToString();
        luckText.text = PlayerDataManager.instance.characterAttributes[currentPlayer].Luck.ToString();
    }
}
