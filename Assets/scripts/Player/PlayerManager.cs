using UnityEngine;
using System.Collections;
using System;

public class PlayerManager : MonoBehaviour {

    public bool p1Win = false;

    /**List of players. Array size should not exceed 2.*/
    public Player[] players;

    //The public instance.
    public static PlayerManager instance;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
	}

    //Return the public instance of the manager.
	public static PlayerManager getInstance() {
        if (instance == null) {
			instance = GameObject.FindObjectOfType(typeof(PlayerManager)) as PlayerManager;
			
			if (instance == null)
			{
				GameObject go = new GameObject("playerManager");
				instance = go.AddComponent<PlayerManager>();
			}
        }
        return instance;
    }

	void Start()
	{
		GameObject[] goPlayers = GameObject.FindGameObjectsWithTag ("Player");
		players = new Player[2];
		for(int i = 0;i< players.Length;i++) {
			players[goPlayers[i].GetComponent<Player>().playerNumber] = goPlayers[i].GetComponent<Player>();
		}

	}



    /**Send damage to one player and then check for the victory of one of the players.*/
	public void sendDamage(Player target, float dommages, DamageType dType) 
    {
        target.takeDamage(dType, dommages);
    }

    //Lock one's random skill.
    public void sendlockRandomSkill(Player target, float lockDuration) {
        target.lockRandomSkill(lockDuration);
    }

    //Slow one's all skills.
    public void sendSlowAllSkills(Player target, float slowDuration, float slowPower) {
        target.slowAllSkills(slowDuration, slowPower);
    }

    //Slow one's all skills.
    public void sendLockAllSkills(Player target, float lockDuration) {
        target.lockAllSkills(lockDuration);
    }

    /**Get the other player that is not the one in the parameters.*/
    public Player getOtherPlayer(Player p) {
        if(p.playerNumber == 0) {
            return players[1];
        } else {
            return players[0];
        }
    }

    /**Add a player to the list of players at the idx.*/
    public void addPlayer(Player p, int idx) {
        if(idx > 1) {
            Debug.LogError("Trying to add a player to the player manager with the wrong index!");
        } else {
            players[idx] = p;
        }
    }


    public void Win(Player player)
    {
        DontDestroyOnLoad(player.gameObject);
        Destroy(player.gameObject.GetComponent<PlayerMovement>());
        Application.LoadLevel("Win");
    }

}
