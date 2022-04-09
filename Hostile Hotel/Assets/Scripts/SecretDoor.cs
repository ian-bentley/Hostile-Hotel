using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] Altar altar;
    [SerializeField] SpriteRenderer secretDoorSR;
    [SerializeField] BoxCollider2D secretDoorBC2D;

    void Update()
    {
        if (altar.HasCandle)
        {
            secretDoorSR.enabled = false;
            secretDoorBC2D.enabled = false;
        }
    }
}
