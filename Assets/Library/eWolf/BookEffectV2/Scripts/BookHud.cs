﻿using eWolf.BookEffectV2.Interfaces;
using UnityEngine;

namespace eWolf.BookEffectV2
{
    public class BookHud : MonoBehaviour
    {
        public GameObject BookObject;
        private IBookControl _bookControl;
        GameObject clickedGameObject;
        public int nowPage;
        public AudioSource page1, page3;

        public float MaxDistance, MuteDistance;
        public GameObject PlayerObj;

        /*       public void OnGUI()
               {
                   if (_bookControl.IsBookOpen)
                   {
                       if (GUI.Button(new Rect(10, 80, 120, 48), "Close Book"))
                       {
                           _bookControl.CloseBook();
                       }
                   }
                   else
                   {
                       if (GUI.Button(new Rect(10, 10, 120, 48), "Open Book"))
                       {
                           _bookControl.OpenBook();
                       }
                       if (GUI.Button(new Rect(200, 10, 120, 48), "Open Book Page 0"))
                       {
                           _bookControl.OpenBookAtPage(0);
                       }
                       if (GUI.Button(new Rect(330, 10, 120, 48), "Open Book Page 2"))
                       {
                           _bookControl.OpenBookAtPage(2);
                       }
                       if (GUI.Button(new Rect(460, 10, 120, 48), "Open Book Page 4"))
                       {
                           _bookControl.OpenBookAtPage(4);
                       }
                   }

                   if (_bookControl.CanTurnPageForward)
                   {
                       if (GUI.Button(new Rect(200, 80, 80, 40), "Turn"))
                       {
                           _bookControl.TurnPage();
                       }
                   }
                   if (_bookControl.CanTurnPageBackWard)
                   {
                       if (GUI.Button(new Rect(300, 80, 80, 40), "Turn-Back"))
                       {
                           _bookControl.TurnPageBack();
                       }
                   }

                   if (GUI.Button(new Rect(10, 200, 80, 40), "Speed 1"))
                   {
                       _bookControl.SetSpeed(1);
                   }
                   if (GUI.Button(new Rect(10, 250, 80, 40), "Speed 2"))
                   {
                       _bookControl.SetSpeed(2);
                   }
                   if (GUI.Button(new Rect(10, 300, 80, 40), "Speed 4"))
                   {
                       _bookControl.SetSpeed(4);
                   }
               }*/

        public void Start()
        {
            _bookControl = BookObject.GetComponent<IBookControl>();
        }

        public void Update()
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

                if (clickedGameObject != null)
                {
                    Debug.Log(clickedGameObject.name);
                }
                
                if (clickedGameObject.CompareTag("right"))
                {
                    right();
                }
                else if (clickedGameObject.CompareTag("left"))
                {
                    left();
                }
            }

            float dist = Vector3.Distance(this.transform.position, PlayerObj.transform.position);
            if (dist < MaxDistance)
            {
                page1.volume = 1.0f;
                page3.volume = 1.0f;
            }
            else if (dist > MuteDistance)
            {
                page1.volume = 0.0f;
                page3.volume = 0.0f;
            }
            else
            {
                float tmp = (MuteDistance - dist) / (MuteDistance - MaxDistance);
                page1.volume = tmp;
                page3.volume = tmp;
            }
        }

        void right() {
            if (nowPage == 0)
            {
                _bookControl.OpenBook();
                page1.time = 0.0f;
                page1.Play();
                page3.Stop();
                nowPage = 1;
            }
            else if(nowPage == 1)
            {
                _bookControl.TurnPage();
                page3.time = 0.0f;
                page3.Play();
                page1.Stop();
                nowPage = 2;
            }
        }

        void left()
        {
            if (nowPage == 1)
            {
                _bookControl.CloseBook();
                page1.Stop();
                page3.Stop();
                nowPage = 0;
            }
            else if (nowPage == 2)
            {
                _bookControl.TurnPageBack();
                page1.time = 0.0f;
                page1.Play();
                page3.Stop();
                nowPage = 1;
            }
        }
    }
}