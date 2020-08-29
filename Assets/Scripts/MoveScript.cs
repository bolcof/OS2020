using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject Ground;

    void Update()
    {
        if (Input.GetKey("up")){
            Ground.transform.Rotate(new Vector3(0.4f, 0.0f, 0.0f), Space.World);
        }
        if (Input.GetKey("down"))
        {
            Ground.transform.Rotate(new Vector3(-0.4f, 0.0f, 0.0f), Space.World);
        }
        if (Input.GetKey("right"))
        {
            Ground.transform.Rotate(new Vector3(0.0f, 0.8f, 0.0f), Space.World);
        }
        if (Input.GetKey("left"))
        {
            Ground.transform.Rotate(new Vector3(0.0f, -0.8f, 0.0f), Space.World);
        }
    }
}
