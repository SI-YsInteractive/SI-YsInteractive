using UnityEngine;
using System.Collections;

public class plateform : MonoBehaviour {

	public SkillType skillType; 
	public Skill skill;

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
		if (skill) 
		{
			Texture2D texture = new Texture2D(128, 128);
			transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = texture;
			Vector2 centerPixel = new Vector2(64,64);
			for (int y = 0; y < texture.height; y++) {
				for (int x = 0; x < texture.width; x++) {
					Color color;
					if(Vector2.Distance(centerPixel,new Vector2(x,y)) <= (skill.currentCharge/skill.chargeTime) * Vector2.Distance(centerPixel,new Vector2(0,0)))
					  	color = Color.gray;
					else
						color = Color.white; 
					texture.SetPixel(x, y, color);
				}
			}
			texture.Apply();
		}
	}
	public void setPlayerSkill(GameObject player)
	{
		player.GetComponent<Player>().currentChargingSkill = skill;
	}
	public void playerLeavePlatform(GameObject player)
	{
		player.GetComponent<Player>().currentChargingSkill = null;
	}


}
