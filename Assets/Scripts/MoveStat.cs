using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveStat : MonoBehaviour
{

    public Sprite successSprite;
    public Sprite failSprite;

    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void determinationMoveStat(float moveStat)
    {
        float randomValue = Random.value;
        if (randomValue <= moveStat / 100.0f)
        {
            image.sprite = successSprite;
        }
        else
        {
            image.sprite = failSprite;
        }
    }

}


