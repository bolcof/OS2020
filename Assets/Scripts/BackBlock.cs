using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlock : MonoBehaviour
{
    public MoveScript MS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            MS.lockBack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            MS.lockBack = false;
        }
    }
}
