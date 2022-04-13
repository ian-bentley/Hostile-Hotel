using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] ItemType _storedItemType;
    [SerializeField] ItemType _keyItemType;
    [SerializeField] Sprite _unlockedSprite;

    bool _locked;

    void Awake()
    {
        if (_keyItemType != ItemType.Null) // has a key type
        {
            Locked = true;
        }
    }

    public ItemType StoredItemType
    {
        get => _storedItemType;
        set => _storedItemType = value;
    }

    public bool Locked
    {
        get => _locked;
        set => _locked = value;
    }

    public ItemType KeyItemType
    {
        get => _keyItemType;
        private set => _keyItemType = value;
    }

    public Sprite UnlockedSprite
    {
        get => _unlockedSprite;
        set => _unlockedSprite = value;
    }

    public void Unlock()
    {
        _locked = false;
        GetComponent<SpriteRenderer>().sprite = UnlockedSprite;
    }

    public GameObject GetData()
    {
        return this.gameObject;
    }

    public void LoadData(InteractableObject interactableObject, Sprite spriteData)
    {
        StoredItemType = interactableObject.StoredItemType;
        KeyItemType = interactableObject.KeyItemType;
        UnlockedSprite = interactableObject.UnlockedSprite;
        Locked = interactableObject.Locked;
        GetComponent<SpriteRenderer>().sprite = spriteData;
    }
}
