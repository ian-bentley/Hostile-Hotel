using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	[SerializeField] List<GameObject> _interactableObjectsList;

    public List<GameObject> InteractableObjectsList
    {
        get => _interactableObjectsList;
        set => _interactableObjectsList = value;
    }

	public void LoadRoomData(RoomData roomData)
	{
        for (int i = 0; i < InteractableObjectsList.Count; i++)
        {
            //InteractableObjectsList[i].GetComponent<InteractableObject>().LoadData(roomData.InteractableObjectsList[i].GetComponent<InteractableObject>().GetData(), roomData.InteractableObjectsList[i].GetComponent<SpriteRenderer>().sprite);
            Debug.Log(roomData.InteractableObjectsList[0].transform.position.x);
        }
	}
	
	public RoomData GetRoomData()
	{
        RoomData roomData;
        List<InteractableObject> interactableObjectsList = new List<InteractableObject>();
        for (int i = 0; i < InteractableObjectsList.Count; i++)
        {
            interactableObjectsList.Add(InteractableObjectsList[i].GetComponent<InteractableObject>().GetData());
        }
        roomData = new RoomData(InteractableObjectsList);
        return roomData;
	}
}
