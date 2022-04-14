using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData
{
    List<InteractableObjectData> _interactableObjectDataList;

    public List<InteractableObjectData> InteractableObjectDataList
    {
        get => _interactableObjectDataList;
        set => _interactableObjectDataList = value;
    }

    public RoomData(List<InteractableObject> interactableObjectsList)
    {
        _interactableObjectDataList = new List<InteractableObjectData>();

        foreach (InteractableObject io in interactableObjectsList)
        {
            InteractableObjectDataList.Add(new InteractableObjectData(io));
        }
    }
}
