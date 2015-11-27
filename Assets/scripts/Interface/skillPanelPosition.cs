using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class skillPanelPosition : MonoBehaviour {
	public int skillNumber;
	public float length;
	public Text text;
	// Use this for initialization
	void Start () {
		length = Screen.width / 5f;
		string lol = (" " + (skillNumber + 1));
		transform.GetChild (0).GetComponent<Text> ().text += lol;
		GetComponent<RectTransform> ().sizeDelta = new Vector2(length,length);
		GetComponent<RectTransform> ().anchoredPosition = new Vector3(length*skillNumber,GetComponent<RectTransform> ().anchoredPosition.y);
		text = transform.GetChild (1).GetComponent<Text> ();
	}
}
