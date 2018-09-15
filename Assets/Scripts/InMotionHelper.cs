using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This is pointless and overcomplicated, but it contains some interesting code snippets to be preserved for future reference.

public class InMotionHelper : MonoBehaviour
{
	public bool ret;

	public bool InMotion(GameObject go)
	{
		StartCoroutine(CheckLocation(go, (returnValue) =>{
			ret = returnValue;
			}));
		
		return ret;
	}

	private IEnumerator CheckLocation(GameObject go, System.Action<bool> callback)
	{
		Vector3 startLocation = go.transform.position;
		yield return new WaitForSeconds(0.01f);
		Vector3 endLocation = go.transform.position;
		if (startLocation == endLocation)
		{
			callback(false);
		}
		else
		{
		 	callback(true);
		}
	}
}

