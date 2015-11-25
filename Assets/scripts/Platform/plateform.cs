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
			bouclierBasiqueProtection.specialAttackFixedProtection = SkillManager.instance.bouclierBasiqueSpecialProtection;
			bouclierBasiqueProtection.standardAttackFixedProtection = SkillManager.instance.bouclierBasiqueStandardProtection;
            bouclierBasiqueProtection.startingTimeLeft = SkillManager.instance.bouclierBasiqueProtectionDuration;
			bouclierBasique.protectionType = bouclierBasiqueProtection;
			bouclierBasique.chargeTime = SkillManager.instance.bouclierBasiqueChargeTime;
			break;
		case SkillType.BouclierFort:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill bouclierFort = (DefenseSkill)skill;
            bouclierFort.chargeTime = SkillManager.instance.bouclierFortChargeTime;
			FixedProtection bouclierFortProtection = new FixedProtection();
            bouclierFortProtection.specialAttackFixedProtection = SkillManager.instance.bouclierFortSpecialProtection;
            bouclierFortProtection.standardAttackFixedProtection = SkillManager.instance.bouclierFortStandardProtection;
            bouclierFortProtection.startingTimeLeft = SkillManager.instance.bouclierFortProtectionDuration;
            bouclierFort.protectionType = bouclierFortProtection;
            bouclierFort.chargeTime = SkillManager.instance.bouclierFortChargeTime;
			break;
		case SkillType.BouleDeFeu:
            skill = gameObject.AddComponent<AttackSkill>();
			AttackSkill bouleDeFeu = (AttackSkill)skill;
            bouleDeFeu.chargeTime = SkillManager.instance.bouleDeFeuChargeTime;
            bouleDeFeu.damages = SkillManager.instance.bouleDeFeuDamage;
            bouleDeFeu.dType = SkillManager.instance.bouleDeFeuDamageType;
			break;
		case SkillType.LanceDeFoudre:
            skill = gameObject.AddComponent<StunAttackSkill>();
            StunAttackSkill lanceDeFoudre = (StunAttackSkill)skill;
            lanceDeFoudre.random = true;
            lanceDeFoudre.chargeTime = SkillManager.instance.lanceDeFoudreChargeTime;
            lanceDeFoudre.damages = SkillManager.instance.lanceDeFoudreDamage;
            lanceDeFoudre.dType = SkillManager.instance.lanceDeFoudreDamageType;
			break;
        case SkillType.EclairDeGlace:
            skill = gameObject.AddComponent<SlowAttackSkill>();
            SlowAttackSkill eclairDeGlace = (SlowAttackSkill)skill;
            eclairDeGlace.chargeTime = SkillManager.instance.eclairDeGlaceChargeTime;
            eclairDeGlace.damages = SkillManager.instance.eclairDeGlaceDamage;
            eclairDeGlace.dType = SkillManager.instance.eclairDeGlaceDamageType;
            eclairDeGlace.slowDuration = SkillManager.instance.eclairDeGlaceSlowDuration;
            eclairDeGlace.slowPowerMultiplier = SkillManager.instance.eclairDeGlaceSlowMultiplier;
            break;
		/*case SkillType.InterventionDivine:
			break;*/
		case SkillType.CoupDeGriffe:

            skill = gameObject.AddComponent<BleedAttackSkill>();
            BleedAttackSkill coupDeGriffe = (BleedAttackSkill)skill;
            coupDeGriffe.DamagePerTick = SkillManager.instance.coupDeGriffeDamagePerTick;
            coupDeGriffe.numberOfTicks = SkillManager.instance.coupDeGriffeNumberOfTicks;
            coupDeGriffe.timeBetweenTick = SkillManager.instance.coupDeGriffeTimeBetweenTicks;
            coupDeGriffe.chargeTime = SkillManager.instance.coupDeGriffeChargeTime;
            coupDeGriffe.damages = SkillManager.instance.coupDeGriffeDamage;
            coupDeGriffe.dType = SkillManager.instance.coupDeGriffeDamageType;
			break;
		/*case SkillType.Morsure:
			break;*/
		case SkillType.Esquive:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill esquive = (DefenseSkill)skill;
            esquive.chargeTime = SkillManager.instance.esquiveChargeTime;
			FixedProtection esquiveProtection = new FixedProtection();
            esquiveProtection.specialAttackFixedProtection = SkillManager.instance.esquiveSpecialProtection;
            esquiveProtection.standardAttackFixedProtection = SkillManager.instance.esquiveStandardProtection;
            esquiveProtection.startingTimeLeft = SkillManager.instance.esquiveProtectionDuration;
            esquive.protectionType = esquiveProtection;
            esquive.chargeTime = SkillManager.instance.esquiveChargeTime;
			break;
		case SkillType.ContreAttaque:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill contreAttaque = (DefenseSkill)skill;
            contreAttaque.chargeTime = SkillManager.instance.contreAttaqueChargeTime;
            CounterAttackFixedProtection contreAttackProtection = new CounterAttackFixedProtection();
            contreAttackProtection.specialAttackFixedProtection = SkillManager.instance.contreAttaqueSpecialProtection;
            contreAttackProtection.standardAttackFixedProtection = SkillManager.instance.contreAttaqueStandardProtection;
            contreAttackProtection.startingTimeLeft = SkillManager.instance.contreAttaqueProtectionDuration;
            contreAttackProtection.damages = SkillManager.instance.contreAttaqueDamage;
            contreAttaque.protectionType = contreAttackProtection;
            contreAttaque.chargeTime = SkillManager.instance.contreAttaqueChargeTime;
			break;
		case SkillType.ModeChasse:
			break;
		case SkillType.CoupDeGrace:
			break;
		case SkillType.ToileProtectrice:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill toileProtectrice = (DefenseSkill)skill;
            toileProtectrice.chargeTime = SkillManager.instance.toileProtectriceChargeTime;
            SlowingWebProtection toileProtectriceProtection = new SlowingWebProtection();
            toileProtectriceProtection.specialAttackFixedProtection = SkillManager.instance.toileProtectriceSpecialProtection;
            toileProtectriceProtection.standardAttackFixedProtection = SkillManager.instance.toileProtectriceStandardProtection;
            toileProtectriceProtection.startingTimeLeft = SkillManager.instance.toileProtectriceProtectionDuration;
            toileProtectrice.protectionType = toileProtectriceProtection;
            toileProtectrice.chargeTime = SkillManager.instance.toileProtectriceChargeTime;
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
