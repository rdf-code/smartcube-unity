using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBehaviour : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] float timeToMove;

    private Vector2 targetPos, origPos;
    private int distance = 20;
    private bool keepRepeating = true;

    private void Update()
    {
        if (player.firstMove && keepRepeating)
        {
            keepRepeating= false;           // to call it only once in update :(
            StartCoroutine(MoveLiquid());
        }
    }
    private IEnumerator MoveLiquid()
    {

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = new Vector2(transform.position.x ,transform.position.y + distance);

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));   // this makes the liquid move -> a straight line
            elapsedTime += Time.deltaTime;                                                         // for a set period of time 
            yield return null;
        }
        transform.position = targetPos;
    }
}
