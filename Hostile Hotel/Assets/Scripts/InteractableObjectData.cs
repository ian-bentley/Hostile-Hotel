using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectData
{
    ItemType _storedItemType;
    ItemType _keyItemType;
    Sprite _unlockedSprite;
    bool _locked;
    Sprite _sprite;

    ItemType StoredItemType
    {
        get => _storedItemType;
        set => _storedItemType = value;
    }

    ItemType KeyItemType
    {
        get => _keyItemType;
        set => _keyItemType = value;
    }

    Sprite UnlockedSprite
    {
        get => _unlockedSprite;
        set => _unlockedSprite = value;
    }

    bool Locked
    {
        get => _locked;
        set => _locked = value;
    }

    Sprite Sprite
    {
        get => _sprite;
        set => _sprite = value;
    }

    public InteractableObjectData(GameObject interactableObject)
    {
        StoredItemType = interactableObject.GetComponent<InteractableObject>().StoredItemType;
        KeyItemType = interactableObject.GetComponent<InteractableObject>().KeyItemType;
        UnlockedSprite = interactableObject.GetComponent<InteractableObject>().UnlockedSprite;
        Locked = interactableObject.GetComponent<InteractableObject>().Locked;
        Sprite = interactableObject.GetComponent<SpriteRenderer>().sprite;
    }
}
