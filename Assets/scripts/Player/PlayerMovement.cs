using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
	public bool rotate = false;
    public bool picked;
    public int playerId;
    public int touchId = -1;
    public float rotationSpeed;
    public float minX;
    public float maxX;

	public float mouseY;
	public float angle = 0f;
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
            if (playerId == 0)
                pos.x = Mathf.Min(pos.x, Screen.width / 2f);
            else
                pos.x = Mathf.Max(pos.x, Screen.width / 2f);   
            pos.z = 10;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = pos;
        }
		else
		{
			if(Input.GetMouseButton(0))
			{
				float tmpPos = Input.mousePosition.y;
				if(playerId == (int)(Input.mousePosition.x/(Screen.width/2f)))
				{
					if(playerId == 0)
					{
						if(mouseY < tmpPos)
							angle = Mathf.Min(angle+rotationSpeed,0f);
						if(mouseY > tmpPos)
                            angle = Mathf.Max(angle - rotationSpeed, -90f);
					}
					else
					{
						if(mouseY > tmpPos)
							angle = Mathf.Min(angle+rotationSpeed,0f);
						if(mouseY < tmpPos)
                            angle = Mathf.Max(angle - rotationSpeed, -90f);
					}
					transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.x,angle);
				}
				mouseY = tmpPos;
			}
		}


        #else
        if (Input.touchCount > 0 && touchId == -1)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
					RaycastHit hit;
					if(Physics.Raycast(ray,out hit))
					{
						if(hit.collider.gameObject == gameObject)
						{
							Down();
							continue;
						}
					}

					if(playerId == (int)(Input.GetTouch(i).position.x/(Screen.width/2f)))
					{
						startRotate();
					}

                }
            }
        }
        if (touchId != -1 && Input.GetTouch(touchId).phase == TouchPhase.Ended)
            Up();

        if (picked)
        {
            Vector3 pos = Input.GetTouch(touchId).position;
            if (playerId == 0)
                    pos.x = Mathf.Min(pos.x, Screen.width / 2f);
                else
                    pos.x = Mathf.Max(pos.x, Screen.width / 2f);   
            pos.z = 10;
            pos = Camera.main.ScreenToWorldPoint(pos);

            transform.position = pos;
        }
		if(rotate)
		{
			float tmpPos = Input.GetTouch(touchId).position.y;
			if(playerId == (int)(Input.GetTouch(touchId).position.x/(Screen.width/2f)))
			{
				if(playerId == 0)
				{
					if(mouseY < tmpPos)
						angle = Mathf.Min(angle+rotationSpeed,0f);
					if(mouseY > tmpPos)
						angle = Mathf.Max(angle-rotationSpeed,-90f);
				}
				else
				{
					if(mouseY > tmpPos)
						angle = Mathf.Min(angle+rotationSpeed,0f);
					if(mouseY < tmpPos)
						angle = Mathf.Max(angle-rotationSpeed,-90f);
				}
				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.x,angle);
			}
			mouseY = tmpPos;

		}
#endif
    }
    void OnMouseDown()
    {
        picked = true;
    }
    void OnMouseUp()
    {
        picked = false;
    }

    void Down()
    {
        try
        {
            touchId = Input.touchCount-1;
        }
        catch (ArgumentException e)
        {
            return;
        }
        picked = true;
    }
	void startRotate()
	{
		touchId = Input.touchCount-1;
		GameObject.FindGameObjectWithTag("Back").GetComponent<Image>().color = Color.green;
		rotate = true;
	}

    void Up()
    {
		touchId = -1;
        picked = false;
		rotate = false;
		GameObject otherPlayer = null;
		foreach(GameObject pl in GameObject.FindGameObjectsWithTag("Player"))
			if(pl.GetComponent<PlayerMovement>() != this)
				otherPlayer = pl;

		if(otherPlayer)
			if(otherPlayer.GetComponent<PlayerMovement>().touchId == 1)
				otherPlayer.GetComponent<PlayerMovement>().touchId = 0;

    }

}
