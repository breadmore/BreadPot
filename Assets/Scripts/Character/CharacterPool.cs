using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterPool : SingletonDontDestroy<CharacterPool>
{
    public List<CharacterPreset> characterPresets;
}