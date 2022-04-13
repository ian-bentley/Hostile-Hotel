using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    Vector3 _position;

    public Vector3 Position
    {
        get => _position;
        set => _position = value;
    }

    public PlayerData(Vector3 position)
    {
        _position = position;
    }

    public PlayerData()
    {
        _position = new Vector3(0, 0, 0);
    }
}
