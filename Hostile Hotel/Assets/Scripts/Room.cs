using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	[SerializeField] List<InteractableObject> _interactableObjectsList;

    public List<InteractableObject> InteractableObjectsList
    {
        get => _interactableObjectsList;
        set => _interactableObjectsList = value;
    }

    public void Load(RoomData roomData)
    {
        for (int i = 0; i < InteractableObjectsList.Count; i++)
        {
            InteractableObjectsList[i].Load(roomData.InteractableObjectDataList[i]);
        }
    }
}
