using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] ItemType _storedItemType;
    [SerializeField] ItemType _keyItemType;
    [SerializeField] Sprite _unlockedSprite;
    [SerializeField] string _lockedText;
    [SerializeField] string _unlockedText;
    [SerializeField] string _getItemText;
    [SerializeField] string _inspectText;
    [SerializeField] string _placedItemText;
    [SerializeField] string _badUseText;
    [SerializeField] string _badPlaceText;

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


    public string LockedText
    {
        get => _lockedText;
        set => _lockedText = value;
    }

    public string UnlockedText
    {
        get => _unlockedText;
        set => _unlockedText = value;
    }

    public string GetItemText
    {
        get => _getItemText;
        set => _getItemText = value;
    }

    public string InspectText
    {
        get => _inspectText;
        set => _inspectText = value;
    }

    public string PlacedItemText
    {
        get => _placedItemText;
        set => _placedItemText = value;
    }


    public string BadUseText
    {
        get => _badUseText;
        set => _badUseText = value;
    }

    public string BadPlaceText
    {
        get => _badPlaceText;
        set => _badPlaceText = value;
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
