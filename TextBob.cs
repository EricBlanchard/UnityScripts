using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBob : MonoBehaviour {

    public bool initially_going_up = true;
    public float bob_height = 2f;
    private Vector3 offset;
    private Vector3 top_position;
    private Vector3 bottom_position;
    private Vector3 initial_position;
    public float speed = 0.25f;
    private float journey_length;
    private float start_time;
    private bool going_up = true;
    private bool initial_cycle = true;

    void Start()
    {
        Vector3 pos = transform.position;
        top_position = pos + new Vector3(0, bob_height, 0);
        bottom_position = pos - new Vector3(0, bob_height, 0);
        start_time = Time.time;
        initial_position = transform.position;
        if (initially_going_up)
        {
            journey_length = Vector3.Distance(initial_position, top_position);
        }
        else
        {
            journey_length = Vector3.Distance(initial_position, bottom_position);
        }
    }

	void Update()
    {
        float distCovered = (Time.time - start_time) * speed;
        float fracJourney = distCovered / journey_length;

        if (initial_cycle && initially_going_up)
        {
            transform.position = Vector3.Slerp(initial_position, top_position, fracJourney);
        }
        else if (initial_cycle && !initially_going_up)
        {
            transform.position = Vector3.Slerp(initial_position, bottom_position, fracJourney);
        }
        else if (going_up)
        {
            transform.position = Vector3.Slerp(bottom_position, top_position, fracJourney);
        }
        else if (!going_up)
        {
            transform.position = Vector3.Slerp(top_position, bottom_position, fracJourney);
        }

        if (transform.position == top_position)
        {
            going_up = false;
            initial_cycle = false;
            journey_length = Vector3.Distance(bottom_position, top_position);
            start_time = Time.time;
        }
        else if (transform.position == bottom_position)
        {
            going_up = true;
            initial_cycle = false;
            journey_length = Vector3.Distance(top_position, bottom_position);
            start_time = Time.time;
        }
    }
}
