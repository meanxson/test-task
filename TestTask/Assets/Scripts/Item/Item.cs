using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using IJunior.TypedScenes;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item", order = 51)]
public class Item : ScriptableObject
{
    public Sprite Sprite;

    [HideInInspector] public string Name;
}
