using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CreateObstacles takes a BeatList and a GameObject to use as the Obstacle
// On invokation of the CreateBeats method, it instantiates as many Obstacles as are in the BeatList
// Intended to be used from the Editor
public class CreateObstacles : MonoBehaviour
{

    public BeatList m_BeatList;
    public GameObject obstacle;

    public bool createNewParent = false;
    GameObject parentObject;
    public string newParentName = "New Obstacles";
    public Vector3 newParentLocation = Vector3.zero;

    // Start is called before the first frame update
    void Awake()
    {
        if (m_BeatList == null || m_BeatList.beatLines.Count == 0)
        {
            Debug.LogError("Can't Create Obstacles, Absent or zero count beat list");
        }
        if (obstacle == null)
        {
            Debug.LogError("No Obstacle Prefab to instatiate");
        }
    }

    // Create Beats iterates through the attached BeatList and Instantiates obstacles at the locations defined
    // This script is intended to be triggered from the Inspector via the Custom Editor button
    [ContextMenu("CreateBeats", false, 151)]
    public void CreateBeats()
    {
        if (m_BeatList == null || obstacle == null)
        {
            Debug.LogError("No Obstacle or BeatList attached");
            return;
        }
        else
        {
            if (createNewParent)
            {
                parentObject = new GameObject(newParentName);
                parentObject.transform.SetParent(this.transform);
                parentObject.transform.SetPositionAndRotation(newParentLocation, Quaternion.identity);

                foreach (BeatLine beat in m_BeatList.beatLines)
                {
                    GameObject o = Instantiate(obstacle, new Vector3(beat.x + newParentLocation.x, beat.y + newParentLocation.y, beat.z + newParentLocation.z), Quaternion.identity);
                    o.transform.SetParent(parentObject.transform);
                }
            }
            else
            {
                foreach (BeatLine beat in m_BeatList.beatLines)
                {
                    GameObject o = Instantiate(obstacle, new Vector3(beat.x, beat.y, beat.z), Quaternion.identity);
                    o.transform.SetParent(this.transform);
                }
            }


        }
    }
}
