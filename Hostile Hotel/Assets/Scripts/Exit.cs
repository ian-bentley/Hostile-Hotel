using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] RoomName roomName;

    public void Use()
    {
        GameManager.Instance.StartCoroutine("LoadRoom", roomName);
    }
}
