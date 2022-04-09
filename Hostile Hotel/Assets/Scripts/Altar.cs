using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] SpriteRenderer altarSR;
    [SerializeField] Sprite altarCompleteSprite;

    bool hasCandle;

    public bool HasCandle
    {
        get => hasCandle;
        set => hasCandle = value;
    }

    void Update()
    {
        if (hasCandle)
        {
            altarSR.sprite = altarCompleteSprite;
        }
    }
}
