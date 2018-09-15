using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVictory : MonoBehaviour {
	
public LayerMask lm;
public GameObject victoryCanvas;

void Awake()
	{
		InvokeRepeating("checkRaycast", 1f, 0.1f);
	}

void checkRaycast()
	{
		RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, lm))
        {
            Debug.Log("Victory");
            victoryCanvas.SetActive(true);
        }
	}
}
