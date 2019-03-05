using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeatLine
{
    // Data fields for this class
    [SerializeField]
    // Which key was pressed
    public string keyPressed;
    [SerializeField]
    // Where in the X direction is this beat
    public float x;
    [SerializeField]
    // Where in the Y direction is this beat
    public float y;
    [SerializeField]
    // Where in the Z direction is this beat
    public float z;

    // Construction Method for this class
    public BeatLine(string keyDown, float x2, float y2, float z2)
    {
        keyPressed = keyDown;
        x = x2;
        y = y2;
        z = z2;
    }

}
