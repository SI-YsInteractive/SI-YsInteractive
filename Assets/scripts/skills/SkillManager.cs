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
    public float bouclierBasiqueProtectionDuration;
	[Header("Bouclier fort")]
	public float bouclierFortChargeTime;
	public float bouclierFortStandardProtection;
	public float bouclierFortSpecialProtection;
    public float bouclierFortProtectionDuration;
	[Header("Boule de feu")]
	public float bouleDeFeuDamage;
	public float bouleDeFeuChargeTime;
	public DamageType bouleDeFeuDamageType;
	[Header("Lance de foudre")]
	public float lanceDeFoudreDamage;
	public float lanceDeFoudreChargeTime;
	public DamageType lanceDeFoudreDamageType;
	public float lanceDeFoudreDuration;
    [Header("Eclair de glace")]
    public float eclairDeGlaceDamage;
    public float eclairDeGlaceChargeTime;
    public DamageType eclairDeGlaceDamageType;
    public float eclairDeGlaceSlowMultiplier;
    public float eclairDeGlaceSlowDuration;
	[Header("Intervention divine")]
	public float interventionDivineChargeTime;
	[Header("Coup de griffe")]
	public float coupDeGriffeDamage;
    public float coupDeGriffeChargeTime;
    public int coupDeGriffeNumberOfTicks;
    public float coupDeGriffeTimeBetweenTicks;
    public float coupDeGriffeDamagePerTick;
	public DamageType coupDeGriffeDamageType;
	//[Header("Morsure")]
	[Header("Esquive")]
	public float esquiveChargeTime;
	public float esquiveStandardProtection;
	public float esquiveSpecialProtection;
    public float esquiveProtectionDuration;
	[Header("Contre attaque")]
	public float contreAttaqueChargeTime;
	public float contreAttaqueDamage;
	public float contreAttaqueStandardProtection;
	public float contreAttaqueSpecialProtection;
    public float contreAttaqueProtectionDuration;
	[Header("Mode chasse")]
	public float modeChasseChargeTime;
	public float modeChasseMultiplicateur;
    public float modeChasseDuration;
	[Header("Coup de grace")]
	public float coupDeGraceDamage;
	public float coupDeGraceChargeTime;
	public DamageType coupDeGraceDamageType;
    public float coupDeGraceCriticalDamage;
	[Header("Toile protectrice")]
	public float toileProtectriceChargeTime;
	public float toileProtectriceStandardProtection;
    public float toileProtectriceSpecialProtection;
    public float toileProtectriceProtectionDuration;
    public float toileProtectriceSlowMultiplier;
    public float toileProtectriceSlowDuration;
	[Header("Poison paralisant")]
	public float poisonParalisantChargeTime;
	public float poisonParalisantDamage;
	public DamageType poisonParalisantDamageType;
	public float poisonParalisantDuration;
	[Header("Poison zone")]
	public float poisonZoneDamage;
	public float poisonZoneChargeTime;
	public DamageType poisonZoneDamageType;
	[Header("Jet d'acide")]
	public float jetAcideChargeTime;
	public float jetAcideDuration;
	public float jetAcideDamageToProtection;

	public Sprite[] sprites;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
