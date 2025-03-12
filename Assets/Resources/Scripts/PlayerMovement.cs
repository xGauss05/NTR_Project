using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float movementSpeed = 2f;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rigidBody;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		MovePlayer();
	}

	// Update is called once per frame
	void Update()
	{
		GetInputs();
		LimitSpeed();
	}

	void GetInputs()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	void MovePlayer()
	{
		// calculate movement direction
		moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

		rigidBody.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
	}

	void LimitSpeed()
	{
		Vector3 flatVelocity = new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z);

		// limit velocity if needed
		if (flatVelocity.magnitude > movementSpeed)
		{
			Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
			rigidBody.velocity = new Vector3(limitedVelocity.x, rigidBody.velocity.y, limitedVelocity.z);
		}
	}
}
