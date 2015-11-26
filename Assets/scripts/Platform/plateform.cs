using UnityEngine;
using System.Collections;

public class plateform : MonoBehaviour {

	public GameObject currentPlayer;
	public SkillType skillType; 
	public Skill skill;
    public GameObject ChargeBar;

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
            bouclierBasique.specialAttackFixedProtection = SkillManager.instance.bouclierBasiqueSpecialProtection;
            bouclierBasique.standardAttackFixedProtection = SkillManager.instance.bouclierBasiqueStandardProtection;
            bouclierBasique.protectionDuration = SkillManager.instance.bouclierBasiqueProtectionDuration;
            bouclierBasique.protectionType = ProtectionType.BouclierBasique;
			bouclierBasique.chargeTime = SkillManager.instance.bouclierBasiqueChargeTime;
			break;
		case SkillType.BouclierFort:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill bouclierFort = (DefenseSkill)skill;
            bouclierFort.chargeTime = SkillManager.instance.bouclierFortChargeTime;
            bouclierFort.specialAttackFixedProtection = SkillManager.instance.bouclierFortSpecialProtection;
            bouclierFort.standardAttackFixedProtection = SkillManager.instance.bouclierFortStandardProtection;
            bouclierFort.protectionDuration = SkillManager.instance.bouclierFortProtectionDuration;
            bouclierFort.protectionType = ProtectionType.BouclierFort;
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
            esquive.specialAttackFixedProtection = SkillManager.instance.esquiveSpecialProtection;
            esquive.standardAttackFixedProtection = SkillManager.instance.esquiveStandardProtection;
            esquive.protectionDuration = SkillManager.instance.esquiveProtectionDuration;
            esquive.protectionType = ProtectionType.Esquive;
            esquive.chargeTime = SkillManager.instance.esquiveChargeTime;
			break;
		case SkillType.ContreAttaque:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill contreAttaque = (DefenseSkill)skill;
            contreAttaque.chargeTime = SkillManager.instance.contreAttaqueChargeTime;
            contreAttaque.specialAttackFixedProtection = SkillManager.instance.contreAttaqueSpecialProtection;
            contreAttaque.standardAttackFixedProtection = SkillManager.instance.contreAttaqueStandardProtection;
            contreAttaque.protectionDuration = SkillManager.instance.contreAttaqueProtectionDuration;
            contreAttaque.damages = SkillManager.instance.contreAttaqueDamage;
            contreAttaque.protectionType = ProtectionType.ContreAttaque;
            contreAttaque.chargeTime = SkillManager.instance.contreAttaqueChargeTime;
			break;
		/*case SkillType.ModeChasse:
			break;*/
		case SkillType.CoupDeGrace:
			skill = gameObject.AddComponent<CriticalAttackSkill>();
			CriticalAttackSkill coupDeGrace = (CriticalAttackSkill)skill;
			coupDeGrace.criticalDamage = SkillManager.instance.coupDeGraceCriticalDamage;
			coupDeGrace.chargeTime = SkillManager.instance.coupDeGraceChargeTime;
			coupDeGrace.damages = SkillManager.instance.coupDeGraceDamage;
			coupDeGrace.dType = SkillManager.instance.coupDeGraceDamageType;
			break;
		case SkillType.ToileProtectrice:
            skill = gameObject.AddComponent<DefenseSkill>();
			DefenseSkill toileProtectrice = (DefenseSkill)skill;
            toileProtectrice.chargeTime = SkillManager.instance.toileProtectriceChargeTime;
            toileProtectrice.specialAttackFixedProtection = SkillManager.instance.toileProtectriceSpecialProtection;
            toileProtectrice.standardAttackFixedProtection = SkillManager.instance.toileProtectriceStandardProtection;
            toileProtectrice.protectionDuration= SkillManager.instance.toileProtectriceProtectionDuration;
            toileProtectrice.protectionType = ProtectionType.ToileProtectrice;
            toileProtectrice.chargeTime = SkillManager.instance.toileProtectriceChargeTime;
			break;
		case SkillType.PoisonParalisant:
			skill = gameObject.AddComponent<StunAttackSkill>();
			StunAttackSkill poisonParalisant = (StunAttackSkill)skill;
			poisonParalisant.chargeTime = SkillManager.instance.poisonParalisantChargeTime;
			poisonParalisant.damages = SkillManager.instance.poisonParalisantDamage;
			poisonParalisant.dType = SkillManager.instance.poisonParalisantDamageType;
			poisonParalisant.lockDuration = SkillManager.instance.poisonParalisantDuration;
			poisonParalisant.random = false;
			break;
		/*case SkillType.PoisonZone:
			break;
		case SkillType.JetAcide:
			break;*/

		}
	}

	
	// Update is called once per frame
	void Update () {
		if (skill) 
		{
            ChargeBar.GetComponent<UnityEngine.UI.Image>().fillAmount = skill.currentCharge / skill.chargeTime;
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
