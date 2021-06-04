using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ItemViewer _itemViewer;
    [SerializeField] private ItemButton _button;

   [SerializeField] private List<Item> _items;
    private Level _level;

    private string _randomItemName;
    
    private void Awake() => _level = Level.Easy;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var temp = new List<Item>();

        switch(_level)
        {
            case Level.Easy:
            {
                for (var i = 0; i < 3; i++) 
                    temp.Add(_items[i]);
                break;
            }
            
            case Level.Medium:
            {
                for (var i = 0; i < 6; i++) 
                    temp.Add(_items[i]);
                break;
            }
            
            case Level.Hard:
            {
                for (var i = 0; i < 9; i++) 
                    temp.Add(_items[i]);
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        foreach (var items in temp.ShuffleItem())
        {
            var asset = AssetDatabase.GetAssetPath(items.GetInstanceID());
            Instantiate(_button, _itemViewer.transform).Init(items.Sprite, Path.GetFileNameWithoutExtension(asset), OnButtonClick);
        }
        
        var randomNumber = Random.Range(0, temp.Count);
        var assetPath = AssetDatabase.GetAssetPath(temp[randomNumber].GetInstanceID());
        _randomItemName = Path.GetFileNameWithoutExtension(assetPath);
        
        _text.text = $"Find {_randomItemName}";
    }

    private void OnButtonClick()
    {
        Debug.Log(_button.Name == _randomItemName ? "Clicked!" : "Nope");
    }
}