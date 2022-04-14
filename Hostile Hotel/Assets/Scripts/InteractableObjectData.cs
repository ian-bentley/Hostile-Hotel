using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectData
{
    ItemType _storedItemType;
    ItemType _keyItemType;
    bool _locked;
    Sprite _sprite;

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

    public Sprite Sprite
    {
        get => _sprite;
        set => _sprite = value;
    }

    public InteractableObjectData(InteractableObject interactableObject)
    {
        StoredItemType = interactableObject.StoredItemType;
        Locked = interactableObject.Locked;
        Sprite = interactableObject.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
