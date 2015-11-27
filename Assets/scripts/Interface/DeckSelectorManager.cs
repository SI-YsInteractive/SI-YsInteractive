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
	public GameObject backButton;
	// Use this for initialization
	void Start(){
		buildChoices (skillList);
		if(Application.loadedLevelName == "DeckSelection1")
			playerId = 1;
		else
			playerId = 2;

		backButton.GetComponent<Button> ().interactable = false;
	}


	public void setSkill(SkillType skill)
	{
		skills [currentSkill].GetComponent<skillPanelPosition> ().text.text = skill.ToString ();
		currentSkill++;
		backButton.GetComponent<Button> ().interactable = true;
		PlayerPrefs.SetInt ("Player" + playerId + "Skill" + currentSkill,(int)skill);
		string description = "";
		switch (skill)
		{
		case SkillType.AttaqueRapide:
			description = "inflige 4pts de dégats, charge=2s";
			break;
		case SkillType.AttaquePuissante:
			description = "inflige 18pts de dégats, charge=7s";
			break;
		case SkillType.BouclierBasique:
			description = "protège de 3pts de dégats, dure 5s, charge=1s";
			break;
		case SkillType.BouclierFort:
			description = "protège de 12pts de dégats, dure 8 secondes, charge=4s";
			break;
		case SkillType.BouleDeFeu:
			description = "inflige 6pts de dégats, pénètre les protections, charge=6s";
			break;
		case SkillType.LanceDeFoudre:
			description = "inflige 3pts de dégats et bloque une compétence aléatoire pendant 2s, pénètre les protections, charge=6s";
			break;
		case SkillType.EclairDeGlace:
			description = "inflige 1,5pts de dégats, ralentit l'adversaire de 50% pendant 6s, pénètre les protections, charge=6s";
			break;
		case SkillType.CoupDeGriffe:
			description = "inflige 2pts de dégats, plus 5pts sur 10s, charge=2s";
			break;
		case SkillType.Esquive:
			description = "esquive toutes les attaques physiques pendant 2s, charge=3s";
			break;
		case SkillType.ContreAttaque:
			description = "protège de 1pt de dégat et en renvoie 3 pendant 2s, charge=1s";
			break;
		case SkillType.CoupDeGrace:
			description = "inflige 3pts de dégat, dommages x2 si l'ennemi est ralenti/sonné, charge=2s";
			break;
		case SkillType.ToileProtectrice:
			description = "protège 3pts de dégats, ralentit de 50% pendant 3s l'adversaire si il attaque, durée=6s, charge=3s";
			break;
		case SkillType.PoisonParalysant:
			description = "paralyse l'adversaire pendant 6s, charge=6s";
			break;
		}
		skills [currentSkill-1].GetComponent<skillPanelPosition> ().description.text = description;
		skills [currentSkill-1].GetComponent<skillPanelPosition> ().description.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(skills [currentSkill-1].GetComponent<RectTransform> ().sizeDelta.x,150f);
		skills [currentSkill-1].GetComponent<skillPanelPosition> ().skill = skill;
		if(currentSkill == 5)
		{
		 	if(Application.loadedLevelName == "DeckSelection1")
				Application.LoadLevel ("DeckSelection2");
			else
				Application.LoadLevel("Main");
		}
	}

	public void back()
	{
		GameObject lastSlot = transform.GetChild (0).GetChild (0).GetChild (currentSkill - 1).gameObject;
		SkillType last = lastSlot.GetComponent<skillPanelPosition> ().skill;
		for(int i = 0;i<skillList.Length;i++)
		{
			if(skillList[i] == last)
			{
				selectionPanel.transform.GetChild(i).GetComponent<Button>().interactable = true;
				lastSlot.GetComponent<skillPanelPosition> ().text.text = "";
				lastSlot.GetComponent<skillPanelPosition> ().description.text = "";
				currentSkill--;
				if(currentSkill == 0)
					backButton.GetComponent<Button> ().interactable = false;
				return;
			}
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
