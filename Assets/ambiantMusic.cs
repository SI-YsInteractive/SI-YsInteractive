using UnityEngine;
using System.Collections;

public class ambiantMusic : MonoBehaviour {

	public AudioClip menu;
	public AudioClip fight;
	public AudioClip win;

	// Use this for initialization
	void Awake () {
		if (GameObject.FindGameObjectsWithTag ("Music").Length > 1)
			Destroy (this.gameObject);
		DontDestroyOnLoad (gameObject);
	}
	
	void OnLevelWasLoaded(int level) {
		if (level == 3)
		{
			Debug.Log("level main");
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().clip = fight;
			GetComponent<AudioSource>().Play();

		}
		else if (level == 4)
		{
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().clip = win;
			GetComponent<AudioSource>().PlayScheduled(0.11);
		}
		else
		{
			if(GetComponent<AudioSource>().clip != menu)
			{
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().clip = menu;
				GetComponent<AudioSource>().Play();
			}
		}
		
	}
}
