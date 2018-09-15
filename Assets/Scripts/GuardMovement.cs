using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardMovement : MonoBehaviour {

	public GameObject basePanelParent;
	public GameObject panelToLookAt;
	public GameObject gameOverCanvas;

	public List <GameObject> basePanels = new List<GameObject>();
	public LayerMask lm;
	public bool isLooping;
	public int turnNumber = 0;
	public float lookDistanceZ;
	public float lookDistanceX;

	private Vector3 currentPosition;
	private Vector3 panelToLookAtPosition;

	void Awake()
	{

		IncreaseMoveStep(0f);

		StartCoroutine(CheaperUpdate());
	}


	public void IncreaseMoveStep(float moveTime)
	{
		GameObject panel = basePanels[turnNumber];
		
		StartCoroutine(MoveOverSeconds(this.gameObject, panel.transform.position, moveTime));

		if (turnNumber< basePanels.Count -1)
		{
			turnNumber ++;
		}
		else if (turnNumber == (basePanels.Count -1))
		{
			turnNumber= 0;
		}

		Invoke("checkRaycast", 0.1f);

	}

	

	IEnumerator CheaperUpdate()
	{
		while(true)
		{
			GameObject panel = basePanels[turnNumber];

			if(panelToLookAt != null)
			{
				currentPosition = transform.TransformPoint(Vector3.zero);
				panelToLookAtPosition = panelToLookAt.transform.TransformPoint(Vector3.zero);
				float guardDistanceZ = panelToLookAtPosition.z - currentPosition.z;
				float guardDistanceX = panelToLookAtPosition.x - currentPosition.x;

				if (guardDistanceZ <= lookDistanceZ && guardDistanceZ >= - lookDistanceZ)
				{
					if (guardDistanceX <= lookDistanceX && guardDistanceX >= - lookDistanceX)
						{
							transform.LookAt(panelToLookAt.transform);
						}
					else
						{
							transform.LookAt(panel.transform);
						}
				}
				else
				{
					transform.LookAt(panel.transform);
				}
			}
			else
			{
				transform.LookAt(panel.transform);
			}
			yield return new WaitForSeconds(0.05f);
		}
		
		
		
	}

	void checkRaycast()
	{
		RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lm) && hit.transform.tag == "Player")
        {
            Debug.Log("Did Hit" + this.gameObject.name);
            gameOverCanvas.SetActive(true);
        }
        else
        {
            Debug.Log("Did not Hit");
        }
	}

	public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
		 {
		     float elapsedTime = 0;
		     Vector3 startingPos = objectToMove.transform.position;
		     while (elapsedTime < seconds)
		     {
		         objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
		         elapsedTime += Time.deltaTime;
		         yield return new WaitForEndOfFrame();
		     }
		     objectToMove.transform.position = end;
		 }
}
