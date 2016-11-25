using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is the data structure that keeps track of which gameobjects to track and their positions and rotations
[System.Serializable]
public class Replayable_Data
{
    public GameObject go;
    public List<Vector3> positions = new List<Vector3>();
    public List<Quaternion> rotations = new List<Quaternion>();
}

//Every update, while recording is on, stores position and rotation of tracked gameobjects.
//Set playing to true to have those objects go through replay mode
public class Replay_Manager : MonoBehaviour {

    public int frames_to_keep = 180;
    public List<Replayable_Data> replayable_objects = new List<Replayable_Data>();
    public bool recording = true;
    public bool playing = false;
    public int current_frame = 0;

    //This will be the speed of the replay, with 1 being normal, 0 being locked in stasis forever
    public float replay_time = 0.5f;

    void Update()
    {
        if (recording)
        {
            foreach (Replayable_Data data in replayable_objects)
            {
                if (data.positions.Count >= frames_to_keep)
                {
                    data.positions.RemoveAt(frames_to_keep - 1);
                    data.positions.Insert(0, data.go.transform.position);
                }
                else
                {
                    data.positions.Insert(0, data.go.transform.position);
                }

                if (data.rotations.Count >= frames_to_keep)
                {
                    data.rotations.RemoveAt(frames_to_keep - 1);
                    data.rotations.Insert(0, data.go.transform.localRotation);
                }
                else
                {
                    data.rotations.Insert(0, data.go.transform.localRotation);
                }
            }
        }

        if (playing)
        {
            //TODO: Disable player input
            Time.timeScale = (replay_time);
            foreach (Replayable_Data data in replayable_objects)
            {
                data.go.transform.position = data.positions[current_frame];
                data.go.transform.rotation = data.rotations[current_frame];
            }
            current_frame++;
            if (current_frame >= frames_to_keep)
            {
                playing = false;
                recording = true;
                //TODO:  Start Game again
                //TODO:  Enable player input again
                Time.timeScale = 1;
            }
        }
    }
}
