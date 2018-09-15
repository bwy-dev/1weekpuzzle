using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChecks : MonoBehaviour {
	public GameObject gameOverCanvas;

	public List<GameObject> GameObject = new List<GameObject>();

	// Use this for initialization
	public void CheckDistanceFromGuard(GameObject character, GameObject guard, GameObject guard2 = null) {

		float charGuardDistance = Vector3.Distance(guard.transform.position, character.transform.position);

		if (charGuardDistance < 2.0f)
		{
			gameOverCanvas.SetActive(true);
		}

		if (guard2 != null)
		{
			if(charGuardDistance < 2.0f)
			{
				gameOverCanvas.SetActive(true);
			}
		}
	}
}
