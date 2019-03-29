using System;
using UnityEngine;

public class CanBehaviorOld : MonoBehaviour
{
	public float xSpeed;

	public float ySpeed;

	public float xDecreaseSpeedFactor;

	public float yDecreaseSpeedFactor;

	public float xMinValue;

	public float yMinValue;

	public float rotationSpeed;

	public float rotationSpeedDecreaseFactor;

	public bool isStationary;

	private void Start()
	{
		int num = UnityEngine.Random.Range(0, 4);
		if (base.transform.position.y == -0.7f)
		{
			switch (num)
			{
			case 0:
				this.xSpeed *= 0.9f;
				this.ySpeed *= 1.5f;
				break;
			case 1:
				this.xSpeed *= 1f;
				this.ySpeed *= 1.25f;
				break;
			case 2:
				this.xSpeed *= 1.15f;
				this.ySpeed *= 1f;
				break;
			case 3:
				this.xSpeed *= 0.4f;
				this.ySpeed *= 1.1f;
				break;
			}
		}
		else if (base.transform.position.y == -0.2f)
		{
			switch (num)
			{
			case 0:
				this.xSpeed *= 1.1f;
				this.ySpeed *= 1.05f;
				break;
			case 1:
				this.xSpeed *= 1.2f;
				this.ySpeed *= 0.7f;
				break;
			case 2:
				this.xSpeed *= 0.7f;
				this.ySpeed *= 0.7f;
				break;
			case 3:
				this.xSpeed *= 0.5f;
				this.ySpeed *= 0.5f;
				break;
			}
		}
		else if (base.transform.position.y == 0.5f)
		{
			switch (num)
			{
			case 0:
				this.xSpeed *= 1.15f;
				this.ySpeed *= 0.3f;
				break;
			case 1:
				this.xSpeed *= 1.25f;
				this.ySpeed *= 0.3f;
				break;
			case 2:
				this.xSpeed *= 0.8f;
				this.ySpeed *= 0.2f;
				break;
			case 3:
				this.xSpeed *= 0.6f;
				this.ySpeed *= 0.1f;
				break;
			}
		}
	}

	private void Update()
	{
		if (this.isStationary || Constants.cons.isGameOver || Constants.cons.isGamePaused)
		{
			return;
		}
		base.transform.localPosition += new Vector3(-this.xSpeed, this.ySpeed, 0f) * Time.deltaTime;
		base.transform.Rotate(new Vector3(0f, 0f, this.rotationSpeed));
		this.rotationSpeed -= this.rotationSpeedDecreaseFactor * Time.deltaTime;
		this.rotationSpeed = Mathf.Clamp(this.rotationSpeed, 5f, 100f);
		this.xSpeed -= this.xDecreaseSpeedFactor * Time.deltaTime;
		this.ySpeed -= this.yDecreaseSpeedFactor * Time.deltaTime;
		this.xSpeed = Mathf.Clamp(this.xSpeed, this.xMinValue, 100f);
		this.ySpeed = Mathf.Clamp(this.ySpeed, this.yMinValue, 100f);
	}

	public void CanPressed()
	{
		this.xSpeed = 0.85f;
		this.ySpeed = 0.75f;
		this.rotationSpeed = 25f;
	}

	public void BecomeStationary(Transform place)
	{
		this.isStationary = true;
		this.xSpeed = 0f;
		this.ySpeed = 0f;
		this.rotationSpeed = 0f;
		base.transform.rotation = Quaternion.Euler(Vector3.zero);
		base.transform.position = place.position;
		UnityEngine.Object.Destroy(base.gameObject, 0.5f);
	}


		


}
