using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBlock : MonoBehaviour
{
    public MoveScript MS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            MS.lockFront = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            MS.lockFront = false;
        }
    }
}
