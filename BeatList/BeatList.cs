using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]

// Adds a button to the create menu to enable creation of new BeatList objects in the project
[CreateAssetMenu(fileName = "New BeatList", menuName = "BeatList")]
public class BeatList : ScriptableObject
{

    [SerializeField]
    // BeatList is a List of BeatLines
    public List<BeatLine> beatLines;

}

