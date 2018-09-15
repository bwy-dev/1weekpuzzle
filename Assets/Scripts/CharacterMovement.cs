using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

	public GameObject playerChar;
	public GameObject guard;
	public GameObject guard2;
	public GameObject gameOverCanvas;
	public GameObject victoryCanvas;
	public Vector3 movementOffset; 
	public float moveTime;
	public int turnNumber = 11;
	public Text turnNumberCount;

	private GuardMovement gm;
	private GuardMovement gm2;
	private CharacterChecks cc;


	void Awake()
	{
		gm = guard.GetComponent<GuardMovement>();
		if(guard2 != null)
		{
			gm2 = guard2.GetComponent<GuardMovement>();
		}

		cc = playerChar.GetComponent<CharacterChecks>();
		turnNumberCount.text = turnNumber.ToString();

	}

	public void MoveCharacter(GameObject panel)
	{

		Vector3 playerCharPos = playerChar.transform.position;
		Vector3 panelPos = panel.transform.position;
		float playerDistanceX = panelPos.x - playerCharPos.x;
		float playerDistanceZ = panelPos.z - playerCharPos.z;

		if (playerDistanceX <= 2.75f && playerDistanceX >= -2.75f)
		{
			if (playerDistanceZ <= 0.5f && playerDistanceZ >= -0.5f)
			{
				StartCoroutine(MoveOverSeconds(playerChar, (panelPos - movementOffset), moveTime));
			}	
		}
		
		if (playerDistanceZ <= 2.75f && playerDistanceZ >= -2.75f)
		{
			if (playerDistanceX <= 0.5f && playerDistanceX >= -0.5f)
			{
				StartCoroutine(MoveOverSeconds(playerChar, (panelPos - movementOffset), moveTime));
			}	
		}

		turnNumber = turnNumber -1;
		turnNumberCount.text = turnNumber.ToString();
		Invoke("CheckTurnCount", 0.5f);
		
		Invoke("IncreaseGuardStep", moveTime);
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

	    cc.CheckDistanceFromGuard(playerChar, guard);
		if(guard2 != null)
		{
			cc.CheckDistanceFromGuard(playerChar, guard, guard2);
		}
	}

	private void IncreaseGuardStep()
	{
		gm.IncreaseMoveStep(moveTime);

		if(gm2 != null)
		{
			gm2.IncreaseMoveStep(moveTime);
		}
	}
	
	private void CheckTurnCount()
	{
		if (turnNumber == 0)
		{
			if(victoryCanvas.activeSelf == false)
			{
				gameOverCanvas.SetActive(true);
			}	
		}
	}

}
