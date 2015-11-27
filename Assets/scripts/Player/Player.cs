using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {

    /**The starting life of the player, or, ingame, the maximum life of the player*/
    public float startingLife;
    
    //Current life.
    public float life;
    //The player number. It will be the index in the player manager.
    public int playerNumber;

    //List of skills of the player.
    public List<Skill> skills;
    public Skill currentChargingSkill = null;

    public List<Protection> protections = new List<Protection>();
	public int protectionNumber;

    //List of platform of the player.
    public GameObject[] plateforms;

    //The health bar.
	public GameObject healthBar;
    //The boost bar.
    public GameObject boostBar;


    public GameObject model;

    //Return player's life.
    public float getLife() {
        return life;
    }

    /**Make the player take damage (after reducing the damages)*/
    public void takeDamage(DamageType dType, float damages) {
		if (protections.Count > 0) 
		{
			foreach (Protection protect in protections) {
				damages = protect.reduce (damages, dType, this);
			}
		}
		if(damages > 0)
			playHurtAnimation();
        removeLife(damages);
        //ScreenShake
        ScreenShakeManager.getInstance().AddCameraShake(1);
    }

    public void lockRandomSkill(float lockDuration) {
        skills[UnityEngine.Random.Range(0, skills.Count)].lockSkill(lockDuration);
    }

    public void slowAllSkills(float slowDuration, float slowPower) {
        foreach (Skill sk in skills) {
            sk.slowSkill(slowDuration, slowPower);
        }
    }
    public void lockAllSkills(float lockDuration) {
        foreach (Skill sk in skills) {
            sk.lockSkill(lockDuration);
        }
    }

    //To use only if we need a simple way to make protections visually disappear simply.
    /*public void updateProtections() {
            for(int i = protections.Count; i >= 0; i--) {
				protections[i].protectionUpdate();
                if(protections[i].isDisabled()) {
                    protections.RemoveAt(i);
                }
            }
        }*/

    /**Add a protection to the player*/
    public void addProtection(Protection p) {
        protections.Add(p);
    }

    /**Remove some part of player's life*/
    public void removeLife(float minus) {
        
        life = Mathf.Clamp(life - minus, 0, startingLife);
		healthBar.GetComponent<RectTransform> ().localScale = new Vector3(1f,life / startingLife,1f);
		if (life <= 0)
			PlayerManager.instance.Win (PlayerManager.instance.getOtherPlayer (this));
    }

    /**Add some life to the player's life.*/
    public void addLife(float add) {
        life = Mathf.Clamp(life + add, 0, startingLife);
    }

    // Use this for initialization
    void Start() {
        life = startingLife;
		GetComponent<PlayerMovement> ().playerId = playerNumber;
		for (int i = 0; i<plateforms.Length; i++) {

			skills.Add(plateforms[i].GetComponent<plateform>().skill);
		}
    }

    // Update is called once per frame
    void Update() {
		protectionNumber = protections.Count;
        //TODO optimize
        //The angle is between 360 and 270 (360 = minimum boost, 270 = maximum).
        //We have to set it between 0 and 90 first (0 min, 90 max) and then have to normalize to between 0 and 1.
        float boost = Mathf.Abs(this.transform.rotation.eulerAngles.z - 360) / 90;
        if (boost == 4/*(==360 / 90 )*/) { boost = 0; }
        //We don't activate the boost until we reach a value.
        if (boost <= 0.15f) boost = 0;
        if (boostBar) {
            boostBar.GetComponent<RectTransform>().localScale = new Vector3(1f, Mathf.Max(0.10f,boost), 1f);
            boostBar.GetComponent<Image>().color = new Color(255f, 1-(boost*0.75f), 0);
        } else {
            Debug.LogError("No boost bar for player" + playerNumber);
        }
        if (currentChargingSkill) {
            currentChargingSkill.update(this, Time.deltaTime, boost);
        }
        foreach(Skill sk in skills) {
            //We check if the skill is locked or not. If it is, then we drain its charge anyway.
            if ((sk != currentChargingSkill)|| sk.locked) {
                sk.drainCharge(Time.deltaTime);
            }
        }
    }

    public void playAnimationAttack()
    {
        model.GetComponent<Animator>().SetTrigger("attaque");
    }

    public void playDefenseAnimation()
    {
        model.GetComponent<Animator>().SetTrigger("defense");
    }

    public void playHurtAnimation()
    {
        model.GetComponent<Animator>().SetTrigger("hurt");
    }
}
