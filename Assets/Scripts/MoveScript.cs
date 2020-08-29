using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public int a;
    public GameObject Ground;

    void Update()
    {
        if (Input.GetKey("up")){
            Ground.transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f));
        }
        if (Input.GetKey("down"))
        {
            Ground.transform.Rotate(new Vector3(-1.0f, 0.0f, 0.0f));
        }
        if (Input.GetKey("right"))
        {
            Ground.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
        }
        if (Input.GetKey("left"))
        {
            Ground.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f));
            {
    }
}
