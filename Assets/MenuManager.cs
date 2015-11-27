using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void StartDeckSelection()
	{
		Application.LoadLevel ("DeckSelection1");
	}

	public void StartFight()
	{
		Application.LoadLevel ("Main");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
