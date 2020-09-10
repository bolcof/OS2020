using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_controller : MonoBehaviour
{
    GameObject clickedGameObject;
    public GameObject bookRoot;
    public int nowPage = 0;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }

            if (clickedGameObject.CompareTag("right"))
            {
                right();
            }else if (clickedGameObject.CompareTag("left"))
            {
                left();
            }
        }
    }

    void right()
    {
        if (nowPage == 0)
        {
            //bookRoot.GetComponent<>().OpenBook();
        }
    }

    void left()
    {

    }
}
