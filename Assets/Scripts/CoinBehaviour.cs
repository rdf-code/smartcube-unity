using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
	[SerializeField] Vector2 movementVector = new Vector3(10f, 10f);
	[SerializeField] float period = 2f;
	float movementFactor; // 0 for not moved, 1 for fully moved											  
	Vector2 startingPos;
	public NumberSquare numberSquare;
	void Start()
	{
		numberSquare.isLocked = true;
		startingPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		//protect against period is zero
		if (period <= Mathf.Epsilon) { return; }  // epsilon is the smallest float so we dont compare floats with == 0
		float cycles = Time.time / period;  // grows continually from 0
		const float tau = Mathf.PI * 2f; // about 6.28
		float rawSinWave = Mathf.Sin(cycles * tau);// goes from -1 to +1

		movementFactor = rawSinWave / 2f + 0.5f;
		Vector2 offset = movementVector * movementFactor;
		transform.position = startingPos + offset;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
        {
			numberSquare.isLocked = false;

		}
    }
}
