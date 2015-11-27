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
		string description = "";
		switch (skill)
		{
		case SkillType.AttaqueRapide:
			description = "inflige 4 point de dégats, charge en 2 secondes";
			break;
		case SkillType.AttaquePuissante:
			description = "inflige 18 point de dégats, charge en 7 secondes";
			break;
		case SkillType.BouclierBasique:
			description = "protège de 3 point de dégats, charge en 1 secondes, dure 5 secondes";
			break;
		case SkillType.BouclierFort:
			description = "protège de 12 point de dégats, charge en 4 secondes, dure 8 secondes";
			break;
		case SkillType.BouleDeFeu:
			description = "inflige 6 point de dégats, charge en 6 secondes, passe au travers des protections";
			break;
		case SkillType.LanceDeFoudre:
			description = "inflige 3 point de dégats et bloque une compétence aléatoire pendant 2 secondes, charge en 6 secondes, passe au travers des protections";
			break;
		case SkillType.EclairDeGlace:
			description = "inflige 1.5 point de dégats, charge en 6 secondes, ralenti l'adversaire de 50% pendant 6 seconde, passe au travers des protections";
			break;
		case SkillType.CoupDeGriffe:
			description = "inflige 2 point de dégats, plus 5 sur 10 secondes, charge en 2 secondes";
			break;
		case SkillType.Esquive:
			description = "esquive les attaques physiques pendant 2 seconde, charge en 3 secondes";
			break;
		case SkillType.ContreAttaque:
			description = "protège de 1 point de dégat et en renvoie 3 pendant 2 seconde, charge en 1 secondes";
			break;
		case SkillType.CoupDeGrace:
			description = "inflige 3 points de dégat, ou 6 sur un ennemi ralenti, ou sonné, charge en 2 secondes";
			break;
		case SkillType.ToileProtectrice:
			description = "protège de 3 point de dégats, ralenti de 50% pendant 3 secondes l'adversaire si il attaque, dure 6 secondes, charge en 3 secondes";
			break;
		case SkillType.PoisonParalysant:
			description = "sonne l'adversaire pendant 6 secondes, charge en 6 secondes";
			break;
		}
		skills [currentSkill-1].GetComponent<skillPanelPosition> ().description.text = description;
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
