using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PLayer11 : MonoBehaviour
{
	private Transform _transform;
	private float _speed = 10f;

	private void Awake()
	{
		_transform = transform;
	}

	private void Update()
	{
		var dirVertical   = Input.GetAxisRaw("Vertical");
		var dirHorizontal = Input.GetAxisRaw("Horizontal");
		if (dirHorizontal == 0f && dirVertical == 0f)
		{
			return;
		}
		var dirVect = (_transform.forward * dirVertical + _transform.right * dirHorizontal).normalized;

		var        vectUp = Vector3.up * 0.45f;
		RaycastHit hit;

		Debug.DrawRay(_transform.position + vectUp, dirVect, Color.red, 1f);
		if (Physics.Raycast(_transform.position + vectUp, dirVect, out hit, 1))
		{
			if (hit.transform.gameObject.layer != 3) return;
		}
		transform.position += _speed * Time.deltaTime * dirVect;
	}
}
