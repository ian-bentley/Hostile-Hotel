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

    public void Load(InteractableObjectData interactableObjectData)
    {
        StoredItemType = interactableObjectData.StoredItemType;
        Locked = interactableObjectData.Locked;
        GetComponent<SpriteRenderer>().sprite = interactableObjectData.Sprite;
    }
}
