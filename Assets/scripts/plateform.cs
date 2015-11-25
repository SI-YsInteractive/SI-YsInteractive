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
			AttackSkill tmpSkill = (AttackSkill)skill;
			tmpSkill.lifeCost = 20f;
			tmpSkill.chargeTime = 0f;
			tmpSkill.boostedChargeMultiplier = 0f;
			tmpSkill.damages = 0f;
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
