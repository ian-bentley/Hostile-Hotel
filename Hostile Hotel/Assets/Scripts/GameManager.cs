using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum RoomName { AltarRoom, Bedroom, CrawlSpace, DiningRoom, Hallway, Library }

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                GameObject.DontDestroyOnLoad(go);
                go.AddComponent<GameManager>();
                instance = go.GetComponent<GameManager>();
            }

            return instance;
        }
    }

    PlayerData playerData;

    RoomData roomDataAltarRoom;
    RoomData roomDataBedroom;
    RoomData roomDataCrawlSpace;
    RoomData roomDataDiningRoom;
    RoomData roomDataHallway;
    RoomData roomDataLibrary;

    RoomName currentRoomName = RoomName.Bedroom;

    public IEnumerator LoadRoom(RoomName roomName)
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        Room currentRoom = FindObjectOfType<Room>();

        // Save player data
        playerData = new PlayerData(player.Inventory, player.HeldItemSoltNum);

        //Save room data of current room
        switch (currentRoomName)
        {
            case RoomName.AltarRoom:
                if (currentRoom.InteractableObjectsList != null)
                    roomDataAltarRoom = new RoomData(currentRoom.InteractableObjectsList);
                break;
            case RoomName.Bedroom:
                if (currentRoom.InteractableObjectsList != null)
                    roomDataBedroom = new RoomData(currentRoom.InteractableObjectsList);
                break;
            case RoomName.CrawlSpace:
                if (currentRoom.InteractableObjectsList != null)
                    roomDataCrawlSpace = new RoomData(currentRoom.InteractableObjectsList);
                break;
            case RoomName.DiningRoom:
                if (currentRoom.InteractableObjectsList != null)
                    roomDataDiningRoom = new RoomData(currentRoom.InteractableObjectsList);
                break;
            case RoomName.Hallway:
                if (currentRoom.InteractableObjectsList != null)
                    roomDataHallway = new RoomData(currentRoom.InteractableObjectsList);
                break;
            case RoomName.Library:
                if (currentRoom.InteractableObjectsList != null)
                    roomDataLibrary = new RoomData(currentRoom.InteractableObjectsList);
                break;
        }

        // Load new room
        switch (roomName)
        {
            case RoomName.AltarRoom:
                SceneManager.LoadScene("Altar Room");
                while (SceneManager.GetActiveScene().name != "Altar Room")
                {
                    yield return null;
                }

                if (roomDataAltarRoom != null)
                {
                    currentRoom = FindObjectOfType<Room>();
                    currentRoom.Load(roomDataAltarRoom);
                }

                //Load player data
                player = FindObjectOfType<PlayerController>();
                player.Load(playerData);

                break;
            case RoomName.Bedroom:
                SceneManager.LoadScene("Bedroom");
                while (SceneManager.GetActiveScene().name != "Bedroom")
                {
                    yield return null;
                }

                if (roomDataBedroom != null)
                {
                    currentRoom = FindObjectOfType<Room>();
                    currentRoom.Load(roomDataBedroom);
                }

                //Load player data
                player = FindObjectOfType<PlayerController>();
                player.Load(playerData);

                break;
            case RoomName.CrawlSpace:
                SceneManager.LoadScene("Crawl Space");
                while (SceneManager.GetActiveScene().name != "Crawl Space")
                {
                    yield return null;
                }

                if (roomDataCrawlSpace != null)
                {
                    currentRoom = FindObjectOfType<Room>();
                    currentRoom.Load(roomDataCrawlSpace);
                }

                //Load player data
                player = FindObjectOfType<PlayerController>();
                player.Load(playerData);

                break;
            case RoomName.DiningRoom:
                SceneManager.LoadScene("Dining Room");
                while (SceneManager.GetActiveScene().name != "Dining Room")
                {
                    yield return null;
                }

                if (roomDataDiningRoom != null)
                {
                    currentRoom = FindObjectOfType<Room>();
                    currentRoom.Load(roomDataDiningRoom);
                }

                //Load player data
                player = FindObjectOfType<PlayerController>();
                player.Load(playerData);

                break;
            case RoomName.Hallway:
                SceneManager.LoadScene("Hallway");
                while (SceneManager.GetActiveScene().name != "Hallway")
                {
                    yield return null;
                }

                if (roomDataHallway != null)
                {
                    currentRoom = FindObjectOfType<Room>();
                    currentRoom.Load(roomDataHallway);
                }

                //Load player data
                player = FindObjectOfType<PlayerController>();
                player.Load(playerData);

                break;
            case RoomName.Library:
                SceneManager.LoadScene("Library");
                while (SceneManager.GetActiveScene().name != "Library")
                {
                    yield return null;
                }

                if (roomDataLibrary != null)
                {
                    currentRoom = FindObjectOfType<Room>();
                    currentRoom.Load(roomDataLibrary);
                }

                //Load player data
                player = FindObjectOfType<PlayerController>();
                player.Load(playerData);

                break;
        }

        currentRoomName = roomName;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
