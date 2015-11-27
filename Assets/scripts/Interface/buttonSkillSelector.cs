using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonSkillSelector : MonoBehaviour {

	public SkillType skill;


	public void SelectSkill()
	{
		DeckSelectorManager.instance.setSkill (skill);
		GetComponent<Button> ().interactable = false;
	}
}
