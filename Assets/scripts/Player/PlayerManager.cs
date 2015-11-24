using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    /**List of players. Array size should not exceed 2.*/
    public Player[] players;

    //The public instance.
    static private PlayerManager instance;

    //Return the public instance of the manager.
    static public PlayerManager getInstance() {
        if (instance == null) {
            instance = new PlayerManager();
        }
        return instance;
    }

    private PlayerManager() {
        players = new Player[2];
    }

    /**Send damage to one player and then check for the victory of one of the players.*/
	public void sendDamage(Player target, float dommages, DamageType dType) {
        target.takeDamage(dType, dommages);
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

}
