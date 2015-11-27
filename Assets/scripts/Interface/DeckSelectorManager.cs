using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeckSelectorManager : MonoBehaviour {
	public static DeckSelectorManager instance;
	
	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
	}
	public int playerId;
	public int currentSkill = 0;
	public GameObject[] skills;
	public SkillType[] skillList;

	public GameObject selectionPanel;
	public GameObject buttonPrefab;
	// Use this for initialization
	void Start(){
		buildChoices (skillList);
		if(Application.loadedLevelName == "DeckSelection1")
			playerId = 1;
		else
			playerId = 2;
	}


	public void setSkill(SkillType skill)
	{
		skills [currentSkill].GetComponent<skillPanelPosition> ().text.text = skill.ToString ();
		currentSkill++;
		PlayerPrefs.SetInt ("Player" + playerId + "Skill" + currentSkill,(int)skill);

		if(currentSkill == 5)
		{
		 	if(Application.loadedLevelName == "DeckSelection1")
				Application.LoadLevel ("DeckSelection2");
			else
				Application.LoadLevel("Main");
		}
	}

	void buildChoices(SkillType[] skillList)
	{
		int numberOfButton = skillList.Length;
		float width = (Screen.width/5f);
		float height = (selectionPanel.GetComponent<RectTransform>().sizeDelta.y/2f);
		int firstLine = Mathf.Min (numberOfButton, 5);
		int secondLine = numberOfButton - 5;
		for (int i = 0; i< firstLine; i++) 
		{
			GameObject inst = Instantiate(buttonPrefab,Vector3.zero,Quaternion.identity) as GameObject;
			inst.transform.parent = selectionPanel.transform;
			inst.GetComponent<RectTransform>().sizeDelta = new Vector2(width,selectionPanel.GetComponent<RectTransform>().sizeDelta.y/2f);
			inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(i*(width),-height*0.5f);
			inst.GetComponent<buttonSkillSelector>().skill = skillList[i];
			inst.transform.GetChild(0).GetComponent<Text>().text = inst.GetComponent<buttonSkillSelector>().skill.ToString();

		}
		for (int i = 0; i< secondLine; i++) 
		{
			GameObject inst = Instantiate(buttonPrefab,Vector3.zero,Quaternion.identity) as GameObject;
			inst.transform.parent = selectionPanel.transform;
			inst.GetComponent<RectTransform>().sizeDelta = new Vector2(width,selectionPanel.GetComponent<RectTransform>().sizeDelta.y/2f);
			inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(i*(width),height*0.5f);
			inst.GetComponent<buttonSkillSelector>().skill = skillList[i+firstLine];
			inst.transform.GetChild(0).GetComponent<Text>().text = inst.GetComponent<buttonSkillSelector>().skill.ToString();
		}
	}




}
