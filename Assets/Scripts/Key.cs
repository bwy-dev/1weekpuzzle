using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public GameObject player;
	public GameObject victoryPanel;

	void Update () 
	{
		if(Vector3.Distance(player.transform.position, transform.position) <= 1)
		{
			victoryPanel.SetActive(true);
			Destroy(this.gameObject, 0.5f);
		}
	}
}
