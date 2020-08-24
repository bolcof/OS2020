using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float latitude = 0; /*緯度*/
    public float longitude = 0; /*経度*/

    public Vector2 direction = Vector2.zero;
    public float radius;

    private void Start()
    {
        latitude = Random.Range(-90, 90);
        longitude = Random.Range(-180, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            latitude += 0.2f;
            if (latitude > 90) {
                latitude = 90;
            }
        }

        if (Input.GetKey("down"))
        {
            latitude -= 0.2f;
            if (latitude < -90)
            {
                latitude = -90;
            }
        }
        if (Input.GetKey("right"))
        {
            longitude += 0.2f;
            if (longitude > 180)
            {
                longitude = 180;
            }
        }
        if (Input.GetKey("left"))
        {
            longitude -= 0.2f;
            if (longitude < -180)
            {
                longitude = -180;
            }
        }

        float x = radius * Mathf.Sin(Mathf.Deg2Rad * (latitude-90)) * Mathf.Cos(Mathf.Deg2Rad * longitude);
        float y = radius * Mathf.Cos(Mathf.Deg2Rad * (latitude-90));
        float z = radius * Mathf.Sin(Mathf.Deg2Rad * (latitude-90)) * Mathf.Sin(Mathf.Deg2Rad * longitude);
        this.gameObject.transform.position = new Vector3(x, y, z);
    }
}
