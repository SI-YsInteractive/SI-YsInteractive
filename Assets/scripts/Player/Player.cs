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

    public List<Protection> protections;

    //List of platform of the player.
    public GameObject[] plateforms;

	public GameObject healthBar;

    //Return player's life.
    public float getLife() {
        return life;
    }

    /**Make the player take damage (after reducing the damages)*/
    public void takeDamage(DamageType dType, float damages) {
		if (protections.Count > 0) 
		{
			for (int i = protections.Count; i >= 0; i--) {
				if (!protections [i].isDisabled ()) {
					damages = protections [i].reduce (damages, dType);
				} else {
					protections.RemoveAt (i);
				}
			}
		}
        removeLife(damages);
    }

    public void lockRandomSkill(float lockDuration) {
        skills[UnityEngine.Random.Range(0, skills.Count)].lockSkill(lockDuration);
    }

    /*To use only if we need a simple way to make protections visually disappear simply.
    public void updateProtections() {
            for(int i = protections.Count; i >= 0; i--) {
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
        //TODO: take the power from the angle and use it to determine the boost power (the "0" parameter).
		if(currentChargingSkill)
        	currentChargingSkill.update(this, Time.deltaTime, 0);
        foreach(Skill sk in skills) {
            //We check if the skill is locked or not. If it is, then we drain its charge anyway.
            if (sk != currentChargingSkill || sk.locked) {
                sk.drainCharge(Time.deltaTime);
            }
        }
    }
}
