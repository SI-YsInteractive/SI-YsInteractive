using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

    /**Drain time (->when not charging) = chargeTime * drainMultiplier;*/ 
    public float drainMultiplier;

    //Skill list.
	[Header("Attack rapide")]
	public float attackRapideDamage;
    /*[Header("Attack puissante")]
	[Header("Bouclier basique")]
	[Header("Bouclier fort")]
	[Header("Boule de feu")]
	[Header("Lance de foudre")]
	[Header("Intervention divine")]
	[Header("Coup de griffe")]
	[Header("Morsure")]
	[Header("Esquive")]
	[Header("Contre attaque")]
	[Header("Mode chasse")]
	[Header("Coup de grace")]
	[Header("Toile protectrice")]
	[Header("Poison paralisant")]
	[Header("Poison zone")]
	[Header("Jet d'acide")]*/

    //The public instance.
    public static SkillManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    //Return the public instance of the manager.
    public static SkillManager getInstance() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType(typeof(SkillManager)) as SkillManager;

            if (instance == null) {
                GameObject go = new GameObject("skillManager");
                instance = go.AddComponent<SkillManager>();
            }
        }
        return instance;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
