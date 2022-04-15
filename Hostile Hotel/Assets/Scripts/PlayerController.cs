using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Null, Candle, Key, Lure }

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] List<ItemType> _inventory;
    [SerializeField] float _speed;

    ItemType _heldItem;
    int _heldItemSoltNum;
    bool isInteracting;

    //Controls
    KeyCode interactKey = KeyCode.F;
    KeyCode inventoryScrollLeftKey = KeyCode.Q;
    KeyCode inventoryScrollRightKey = KeyCode.E;

    public ItemType HeldItem
    {
        get => Inventory[HeldItemSoltNum];
    }

    public List<ItemType> Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }

    public int HeldItemSoltNum
    {
        get => _heldItemSoltNum;
        set => _heldItemSoltNum = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    void Awake()
    {
        Inventory = new List<ItemType>();
        Inventory.Add(ItemType.Null);
        Inventory.Add(ItemType.Key); //temp
        Inventory.Add(ItemType.Lure); //temp
        HeldItemSoltNum = 0;
    }

    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, Input.GetAxisRaw("Vertical") * Speed);
        
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude > 0) // player is moving
        {
            if (Input.GetAxisRaw("Horizontal") > 0) // player moving right
            {
                animator.SetBool("Moving Right", true);
                animator.SetBool("Moving Left", false);
            }
            else
            {
                animator.SetBool("Moving Left", true);
                animator.SetBool("Moving Right", false);
            }
        }
        else
        {
            animator.SetBool("Moving Left", false);
            animator.SetBool("Moving Right", false);
        }

        if (Input.GetKeyDown(inventoryScrollRightKey))
        {
            if (HeldItemSoltNum == Inventory.Count - 1) //if held item position is last position in inventory list
            {
                HeldItemSoltNum = 0; // held item position becomes first position
            }
            else
            {
                HeldItemSoltNum++;
            }
            UpdateHand();
        }

        if (Input.GetKeyDown(inventoryScrollLeftKey))
        {
            if (HeldItemSoltNum == 0) // if held item position is first position
            {
                HeldItemSoltNum = Inventory.Count - 1; // held item position becomes last position
            }
            else
            {
                HeldItemSoltNum--;
            }
            UpdateHand();
        }

        if (Input.GetKeyDown(interactKey))
        {
            isInteracting = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            if (isInteracting)
            {
                if (HeldItem != ItemType.Null) // if holding an item
                {
                    if (other.gameObject.GetComponent<InteractableObject>().KeyItemType != ItemType.Null 
                        && other.gameObject.GetComponent<InteractableObject>().Locked && HeldItem == other.gameObject.GetComponent<InteractableObject>().KeyItemType) // if interactable object has a key and its locked and you are holding the key
                    {
                        other.gameObject.GetComponent<InteractableObject>().Unlock(); //Unlock the object
                        Debug.Log(other.gameObject.GetComponent<InteractableObject>().UnlockedText);
                    }
                    else // if item does not unlock the object
                    {
                        //Player plays dialogue retrieved from object based on the item used
                        Debug.Log(other.gameObject.GetComponent<InteractableObject>().BadUseText);
                    }
                }
                else //if not holding an item
                {
                    if (other.gameObject.GetComponent<InteractableObject>().Locked) //if object is locked
                    {
                        //Player plays dialogue retrieved from the interact locked variable
                        Debug.Log(other.gameObject.GetComponent<InteractableObject>().LockedText);
                    }
                    else //if item is unlocked
                    {
                        if (other.gameObject.GetComponent<InteractableObject>().StoredItemType != ItemType.Null) //if object is storing an item
                        {
                            //Player plays dialogue retrieved from the interact grabbed item variable
                            Debug.Log(other.gameObject.GetComponent<InteractableObject>().GetItemText);
                            Inventory.Add(other.gameObject.GetComponent<InteractableObject>().StoredItemType);
                            other.gameObject.GetComponent<InteractableObject>().StoredItemType = ItemType.Null;
                        }
                        else
                        {
                            //Player plays dialogue retrieved from the interact unlocked variable
                            Debug.Log(other.gameObject.GetComponent<InteractableObject>().InspectText);
                        }
                    }
                }
            }
        }
        else if (other.gameObject.tag == "Exit")
        {
            if (isInteracting)
            {
                other.gameObject.GetComponent<Exit>().Use();
            }
        }

        isInteracting = false;
    }

    public void Load(PlayerData playerData)
    {
        Inventory = new List<ItemType>();

        foreach (ItemType it in playerData.Inventory)
        {
            Inventory.Add(it);
        }

        HeldItemSoltNum = playerData.HeldItemSlotNum;
        UpdateHand();
    }

    void UpdateHand()
    {
        switch(HeldItem)
        {

            case ItemType.Candle:
                animator.SetBool("Has Candle", true);
                animator.SetBool("Has Key", false);
                animator.SetBool("Has Lure", false);
                animator.SetBool("Has Null", false);
                break;
            case ItemType.Key:
                animator.SetBool("Has Candle", false);
                animator.SetBool("Has Key", true);
                animator.SetBool("Has Lure", false);
                animator.SetBool("Has Null", false);
                break;
            case ItemType.Lure:
                animator.SetBool("Has Candle", false);
                animator.SetBool("Has Key", false);
                animator.SetBool("Has Lure", true);
                animator.SetBool("Has Null", false);
                break;
            case ItemType.Null:
                animator.SetBool("Has Candle", false);
                animator.SetBool("Has Key", false);
                animator.SetBool("Has Lure", false);
                animator.SetBool("Has Null", true);
                break;
        }
    }
}
