using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private string _name;
    private Button _button;

    public string Name => _name;
        
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public ItemButton Init(Sprite sprite, string nameOfItem, UnityAction click)
    {
        _button.image.sprite = sprite;
        _name = nameOfItem;
        _button.onClick.AddListener(click);

        return this;
    }
}