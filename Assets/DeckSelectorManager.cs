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
	public SkillType[] skill1;
	public SkillType[] skill2;
	public SkillType[] skill3;
	public SkillType[] skill4;
	public SkillType[] skill5;

	public GameObject selectionPanel;
	public GameObject buttonPrefab;
	// Use this for initialization
	void Start(){
		buildChoices (skill1);
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
		switch (currentSkill) {
		case 0:
			buildChoices (skill1);
			break;
		case 1:
			buildChoices (skill2);
			break;
		case 2:
			buildChoices (skill3);
			break;
		case 3:
			buildChoices (skill4);
			break;
		case 4:
			buildChoices (skill5);
			break;
		case 5:
		 	if(Application.loadedLevelName == "DeckSelection1")
				Application.LoadLevel ("DeckSelection2");
			else
				Application.LoadLevel("Main");
			break;
		}
	}

	void buildChoices(SkillType[] skillList)
	{
		for (int child = 0; child< selectionPanel.transform.childCount; child++) 
		{
			Destroy(selectionPanel.transform.GetChild(child).gameObject);
		}
		int numberOfButton = skillList.Length;
		for (int i = 0; i< numberOfButton; i++) 
		{
			GameObject inst = Instantiate(buttonPrefab,Vector3.zero,Quaternion.identity) as GameObject;
			switch(currentSkill)
			{
			case 0:
				inst.GetComponent<buttonSkillSelector>().skill = skill1[i];
				break;
			case 1:
				inst.GetComponent<buttonSkillSelector>().skill = skill2[i];
				break;
			case 2:
				inst.GetComponent<buttonSkillSelector>().skill = skill3[i];
				break;
			case 3:
				inst.GetComponent<buttonSkillSelector>().skill = skill4[i];
				break;
			case 4:
				inst.GetComponent<buttonSkillSelector>().skill = skill5[i];
				break;
			}
			inst.transform.parent = selectionPanel.transform;
			float width = (selectionPanel.GetComponent<RectTransform>().sizeDelta.y);
			inst.GetComponent<RectTransform>().sizeDelta = new Vector2(width,width);
			inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(i*(width),0f);
			inst.transform.GetChild(0).GetComponent<Text>().text = inst.GetComponent<buttonSkillSelector>().skill.ToString();

		}
	}




}
