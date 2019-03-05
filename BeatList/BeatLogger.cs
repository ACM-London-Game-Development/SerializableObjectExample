using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Beat Logger is attached to the player that is moving through the scene
// It captures key presses in the Left and Right direction and then records them to the attached BeatList object
public class BeatLogger : MonoBehaviour
{

    public BeatList m_BeatList;

    // Start is called before the first frame update
    void Start()
    {
        if (m_BeatList == null)
        {
            Debug.LogError("No BeatList on Beat Logger");
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            AddBeat("left");
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            AddBeat("right");
        }
    }

    void AddBeat(string newString)
    {
        if (m_BeatList != null)
        {
            m_BeatList.beatLines.Add(new BeatLine(newString, transform.position.x, transform.position.y, transform.position.z));
        }
    }

    // Sets the BeatList to dirty on exitting playmode to ensure that written changes are saved
    private void OnDestroy()
    {
        EditorUtility.SetDirty(m_BeatList);
    }

}
