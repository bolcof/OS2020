using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject PlayerObj;
    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = PlayerObj.transform.rotation;
        Debug.Log(this.transform.rotation);
    }
}
