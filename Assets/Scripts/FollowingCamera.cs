using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    private float scroll;
    public float scrollNow, max;
    private Vector3 startPos;
    public Vector3 endPos;
    private Vector3 startRotate;
    public Vector3 endRotate;
    private float startFoV;
    public float endFoV;

    private void Start()
    {
        startPos = this.transform.localPosition;
        startRotate = this.transform.localRotation.eulerAngles;
        startFoV = Camera.main.fieldOfView;
    }
    
    void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        scrollNow += scroll;
        if (scrollNow <= 0.0f) { scrollNow = 0.0f; }
        if (scrollNow >= max) { scrollNow = max; }

        Vector3 difPos = endPos - startPos;
        Camera.main.transform.localPosition = startPos + difPos * (scrollNow / max);

        Vector3 difRotate = endRotate - startRotate;
        Camera.main.transform.localRotation = Quaternion.Euler(startRotate + difRotate * (scrollNow / max));

        float difFoV = endFoV - startFoV;
        Camera.main.fieldOfView = startFoV + difFoV * (scrollNow / max);
    }
}
