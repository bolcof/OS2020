using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject Ground;
    public bool isActive;

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                Ground.transform.Rotate(new Vector3(0.4f, 0.0f, 0.0f), Space.World);
            }
            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                Ground.transform.Rotate(new Vector3(-0.4f, 0.0f, 0.0f), Space.World);
            }
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                Ground.transform.Rotate(new Vector3(0.0f, -0.8f, 0.0f), Space.World);
            }
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                Ground.transform.Rotate(new Vector3(0.0f, 0.8f, 0.0f), Space.World);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "PlaneArea")
        {
            this.transform.gameObject.transform.rotation = other.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlaneArea")
        {
            this.transform.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
