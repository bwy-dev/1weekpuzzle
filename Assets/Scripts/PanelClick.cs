using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelClick : MonoBehaviour {

	public GameObject playerChar;
	private CharacterMovement cm;

	void Awake()
	{
		cm = playerChar.GetComponent<CharacterMovement>();
	}

	void OnMouseDown()
	{
		cm.MoveCharacter(this.gameObject);
	}

}
