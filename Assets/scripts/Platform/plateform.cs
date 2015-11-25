using UnityEngine;
using System.Collections;

public class plateform : MonoBehaviour {

	public GameObject currentPlayer;
	public SkillType skillType; 
	public Skill skill;

	void Awake()
	{
		switch (skillType) {

		case SkillType.AttaqueRapide:
			skill = gameObject.AddComponent<AttackSkill>();
			AttackSkill attackRapide = (AttackSkill)skill;
			attackRapide.chargeTime = SkillManager.instance.attackRapideChargeTime;
			attackRapide.damages = SkillManager.instance.attackRapideDamage;
			attackRapide.dType = SkillManager.instance.attackRapideDamageType;
			break;
		case SkillType.AttaquePuissante:
			skill = gameObject.AddComponent<AttackSkill>();
			AttackSkill attackPuissante = (AttackSkill)skill;
			attackPuissante.chargeTime = SkillManager.instance.attackPuissanteChargeTime;
			attackPuissante.damages = SkillManager.instance.attackPuissanteDamage;
			attackPuissante.dType = SkillManager.instance.attackPuissanteDamageType;
			break;
		case SkillType.BouclierBasique:
			skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill bouclierBasique = (DefenseSkill)skill;
			bouclierBasique.chargeTime = SkillManager.instance.bouclierBasiqueChargeTime;
			FixedProtection bouclierBasiqueProtection = new FixedProtection();
			bouclierBasiqueProtection.specialAttackFixedProtection = SkillManager.instance.bouclierFortSpecialProtection;
			bouclierBasiqueProtection.standardAttackFixedProtection = SkillManager.instance.bouclierFortStandardProtection;
			bouclierBasique.protectionType = bouclierBasiqueProtection;
			bouclierBasique.chargeTime = SkillManager.instance.bouclierBasiqueChargeTime;
			break;
		case SkillType.BouclierFort:
			break;
		case SkillType.BouleDeFeu:
			break;
		case SkillType.LanceDeFoudre:
			break;
		case SkillType.InterventionDivine:
			break;
		case SkillType.CoupDeGriffe:
			break;
		case SkillType.Morsure:
			break;
		case SkillType.Esquive:
			break;
		case SkillType.ContreAttaque:
			break;
		case SkillType.ModeChasse:
			break;
		case SkillType.CoupDeGrace:
			break;
		case SkillType.ToileProtectrice:
			break;
		case SkillType.PoisonParalisant:
			break;
		case SkillType.PoisonZone:
			break;
		case SkillType.JetAcide:
			break;

		}
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
