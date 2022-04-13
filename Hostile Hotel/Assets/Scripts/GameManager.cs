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

    PlayerData playerDataAltarRoom;
    PlayerData playerDataBedroom;
    PlayerData playerDataCrawlSpace;
    PlayerData playerDataDiningRoom;
    PlayerData playerDataHallway;
    PlayerData playerDataLibrary;

    RoomData roomDataAltarRoom;
    RoomData roomDataBedroom;
    RoomData roomDataCrawlSpace;
    RoomData roomDataDiningRoom;
    RoomData roomDataHallway;
    RoomData roomDataLibrary;

    RoomName currentRoomName = RoomName.Bedroom;

    public void LoadPlayer(PlayerData playerData)
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = playerData.Position;
    }

    public IEnumerator LoadRoom(RoomName roomName)
    {
        GameObject player = GameObject.Find("Player");
        Room room = FindObjectOfType<Room>();

        switch (currentRoomName)
        {
            case RoomName.AltarRoom:
                playerDataAltarRoom = new PlayerData(player.transform.position);
                break;
            case RoomName.Bedroom:
                playerDataBedroom = new PlayerData(player.transform.position);
                //roomDataBedroom = room.SaveRoomData();
                roomDataBedroom = new RoomData(room.GetRoomData();
                break;
            case RoomName.CrawlSpace:
                playerDataCrawlSpace = new PlayerData(player.transform.position);
                break;
            case RoomName.DiningRoom:
                playerDataDiningRoom = new PlayerData(player.transform.position);
                break;
            case RoomName.Hallway:
                playerDataHallway = new PlayerData(player.transform.position);
                break;
            case RoomName.Library:
                playerDataLibrary = new PlayerData(player.transform.position);
                break;
        }

        Debug.Log("Saved data for " + currentRoomName + ": " + player.transform.position);

        switch (roomName)
        {
            case RoomName.AltarRoom:
                SceneManager.LoadScene("Altar Room");
                while (SceneManager.GetActiveScene().name != "Altar Room")
                {
                    yield return null;
                }

                player = GameObject.Find("Player");
                //room = FindObjectOfType<Room>();

                //room.LoadRoomData(roomDataAltarRoom);

                if (playerDataAltarRoom == null)
                    playerDataAltarRoom = new PlayerData(player.transform.position);
                LoadPlayer(playerDataAltarRoom);
                Debug.Log("Loaded data for " + roomName + ": " + playerDataAltarRoom.Position);
                break;
            case RoomName.Bedroom:
                SceneManager.LoadScene("Bedroom");
                while (SceneManager.GetActiveScene().name != "Bedroom")
                {
                    yield return null;
                }
                player = GameObject.Find("Player");
                room = FindObjectOfType<Room>();

                if (roomDataBedroom != null)
                    room.LoadRoomData(roomDataBedroom);

                if (playerDataBedroom == null)
                    playerDataBedroom = new PlayerData(player.transform.position);
                LoadPlayer(playerDataBedroom);
                Debug.Log("Loaded data for " + roomName + ": " + playerDataBedroom.Position);
                break;
            case RoomName.CrawlSpace:
                SceneManager.LoadScene("Crawl Space");
                while (SceneManager.GetActiveScene().name != "Crawl Space")
                {
                    yield return null;
                }
                player = GameObject.Find("Player");
                if (playerDataCrawlSpace == null)
                    playerDataCrawlSpace = new PlayerData(player.transform.position);
                LoadPlayer(playerDataCrawlSpace);
                Debug.Log("Loaded data for " + roomName + ": " + playerDataCrawlSpace.Position);
                break;
            case RoomName.DiningRoom:
                SceneManager.LoadScene("Dining Room");
                while (SceneManager.GetActiveScene().name != "Dining Room")
                {
                    yield return null;
                }
                player = GameObject.Find("Player");
                if (playerDataDiningRoom == null)
                    playerDataDiningRoom = new PlayerData(player.transform.position);
                LoadPlayer(playerDataDiningRoom);
                Debug.Log("Loaded data for " + roomName + ": " + playerDataDiningRoom.Position);
                break;
            case RoomName.Hallway:
                SceneManager.LoadScene("Hallway");
                while (SceneManager.GetActiveScene().name != "Hallway")
                {
                    yield return null;
                }
                player = GameObject.Find("Player");

                if (playerDataHallway == null)
                    playerDataHallway = new PlayerData(player.transform.position);
                LoadPlayer(playerDataHallway);
                Debug.Log("Loaded data for " + roomName + ": " + playerDataHallway.Position);
                break;
            case RoomName.Library:
                SceneManager.LoadScene("Library");
                while (SceneManager.GetActiveScene().name != "Library")
                {
                    yield return null;
                }
                player = GameObject.Find("Player");
                if (playerDataLibrary == null)
                    playerDataLibrary = new PlayerData(player.transform.position);
                LoadPlayer(playerDataLibrary);
                Debug.Log("Loaded data for " + roomName + ": " + playerDataLibrary.Position);
                break;
        }

        currentRoomName = roomName;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
