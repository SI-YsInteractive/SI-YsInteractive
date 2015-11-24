using UnityEngine;
using System.Collections;

public class plateform : MonoBehaviour {

	public SkillType skillType; 
	private Skill skill;

	void Awake()
	{
		switch (skillType) {

		case SkillType.ATTACK:
			skill = gameObject.AddComponent<AttackSkill>();
			break;
		case SkillType.DEFENSE:
			break;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setPlayerSkill(GameObject player)
	{
		//player.GetComponent<Player>().skill = skill;
		//player.GetComponent<Player>().currentSkill = skillType;
	}

}
