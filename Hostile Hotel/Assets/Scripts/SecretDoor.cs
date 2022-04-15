using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] InteractableObject altar;
    [SerializeField] SpriteRenderer secretDoorSR;
    [SerializeField] BoxCollider2D secretDoorBC2D;

    void Update()
    {
        if (altar.ReceivedItem)
        {
            secretDoorSR.enabled = false;
            secretDoorBC2D.enabled = false;
        }
    }
}
