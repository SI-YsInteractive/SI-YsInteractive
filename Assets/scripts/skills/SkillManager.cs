using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {
	public static SkillManager instance = null;
	
	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
	}
	
	//Return the public instance of the manager.
	public static SkillManager getInstance() {
		if (instance == null) {
			instance = GameObject.FindObjectOfType(typeof(SkillManager)) as SkillManager;
			
			if (instance == null)
			{
				GameObject go = new GameObject("SkillManager");
				instance = go.AddComponent<SkillManager>();
			}
		}
		return instance;
	}

    /**The life cost of the skill per seconds. If negative, it becomes a life gain.*/
    public float boostLifeCostPerSecond;
    /**Drain time (->when not charging) = chargeTime * drainMultiplier;*/
    public float drainMultiplier;
    public float LifeCostPerSecond;
    public float BoostedChargeMultiplier;

    //Skill list.
	[Header("Attack rapide")]
	public float attackRapideDamage;
	public float attackRapideChargeTime;
	public DamageType attackRapideDamageType;
    [Header("Attack puissante")]
	public float attackPuissanteDamage;
	public float attackPuissanteChargeTime;
	public DamageType attackPuissanteDamageType;
	[Header("Bouclier basique")]
	public float bouclierBasiqueChargeTime;
	public float bouclierBasiqueStandardProtection;
	public float bouclierBasiqueSpecialProtection;
	[Header("Bouclier fort")]
	public float bouclierFortChargeTime;
	public float bouclierFortStandardProtection;
	public float bouclierFortSpecialProtection;
	[Header("Boule de feu")]
	public float bouleDeFeuDamage;
	public float bouleDeFeuChargeTime;
	public DamageType bouleDeFeuDamageType;
	[Header("Lance de foudre")]
	public float lanceDeFoudreDamage;
	public float lanceDeFoudreChargeTime;
	public DamageType lanceDeFoudreDamageType;
	[Header("Intervention divine")]
	public float interventionDivineChargeTime;
	[Header("Coup de griffe")]
	public float coupDeGriffeDamage;
	public float coupDeGriffeChargeTime;
	public DamageType coupDeGriffeDamageType;
	//[Header("Morsure")]
	[Header("Esquive")]
	public float esquiveChargeTime;
	public float esquiveStandardProtection;
	public float esquiveSpecialProtection;
	[Header("Contre attaque")]
	public float contreAttaqueChargeTime;
	public float contreAttaqueDamage;
	public float contreAttaqueStandardProtection;
	public float contreAttaqueSpecialProtection;
	[Header("Mode chasse")]
	public float modeChasseChargeTime;
	public float modeChasseMultiplicateur;
	[Header("Coup de grace")]
	public float coupDeGraceDamage;
	public float coupDeGraceChargeTime;
	public DamageType coupDeGraceDamageType;
	public DamageType coupDeGraceDamageMultiplier;
	[Header("Toile protectrice")]
	public float toileProtectriceChargeTime;
	public float toileProtectriceStandardProtection;
	public float toileProtectriceSpecialProtection;
	public float toileProtectriceSlow;
	[Header("Poison paralisant")]
	public float poisonParalisantChargeTime;
	public float poisonParalisantDuration;
	[Header("Poison zone")]
	public float poisonZoneDamage;
	public float poisonZoneChargeTime;
	public DamageType poisonZoneDamageType;
	[Header("Jet d'acide")]
	public float jetAcideChargeTime;
	public float jetAcideDuration;
	public float jetAcideDamageToProtection;

    //The public instance.


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
