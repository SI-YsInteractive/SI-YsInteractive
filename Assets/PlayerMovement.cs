using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
    public bool picked;
    public int playerId;
    private int touchId = -1;
    public float minX;
    public float maxX;
	// Use this for initialization
	void Start () {
        picked = false;
	}

    void Update()
    {
        #if UNITY_EDITOR
            if(picked)
            {
                Vector3 pos = Input.mousePosition;
                if (playerId == 1)
                    pos.x = Mathf.Min(pos.x, Screen.width / 2f);
                else
                    pos.x = Mathf.Max(pos.x, Screen.width / 2f);   
                pos.z = 10;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = pos;
            }
        #else
        if (Input.touchCount > 0 && touchId == -1)
        {
            for (var i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit hit;
                    if(Physics.Raycast(ray,out hit))
                        if(hit.collider.gameObject == gameObject)
                            Down();
                }
            }
        }

        if (touchId != -1 && Input.GetTouch(touchId).phase == TouchPhase.Ended)
            Up();

        if (picked)
        {
            Vector3 pos = Input.GetTouch(touchId).position;
            if (playerId == 1)
                    pos.x = Mathf.Min(pos.x, Screen.width / 2f);
                else
                    pos.x = Mathf.Max(pos.x, Screen.width / 2f);   
            pos.z = 10;
            pos = Camera.main.ScreenToWorldPoint(pos);

            transform.position = pos;
        }
#endif
    }
    #if UNITY_EDITOR
    void OnMouseDown()
    {
        picked = true;
    }
    void OnMouseUp()
    {
        picked = false;
    }

    #else
    void Down()
    {
        try
        {
            touchId = Input.touchCount-1;
            if(touchId == 0)
                GameObject.FindGameObjectWithTag("Back").GetComponent<Image>().color = Color.blue;
            else if(touchId == 1)
                GameObject.FindGameObjectWithTag("Back").GetComponent<Image>().color = Color.red;
            else
                GameObject.FindGameObjectWithTag("Back").GetComponent<Image>().color = Color.yellow;


        }
        catch (ArgumentException e)
        {
            return;
        }
        picked = true;
    }

    void Up()
    {
        picked = false;
    }
    #endif

}
