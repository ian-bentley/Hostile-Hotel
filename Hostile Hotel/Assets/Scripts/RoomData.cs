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

    public RoomData(List<GameObject> interactableObjectsList)
    {
        InteractableObjectDataList = new List<InteractableObjectData>();
        for (int i = 0; i < interactableObjectsList.Count; i++)
        {
            InteractableObjectData interactableObjectData;
            interactableObjectData = new InteractableObjectData(interactableObjectsList[i].GetComponent<InteractableObject>().GetData());
            InteractableObjectDataList.Add(interactableObjectData);
        }
    }
}
