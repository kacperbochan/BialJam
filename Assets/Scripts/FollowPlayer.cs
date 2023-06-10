using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private float maxVerticalCameraAngle;
	[SerializeField] private float maxHorizontalCameraAngle;

	private Vector2 rotation;

	//ograniczanie pionowego obrotu kamery
	private float ClampVerticalAngle (float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalCameraAngle, maxVerticalCameraAngle);
    }

    //ograniczanie poziomego obrotu kamery
	private float ClampHorizontalAngle(float angle)
	{
        if(maxHorizontalCameraAngle == 360)
            return angle;
		return Mathf.Clamp(angle, -maxHorizontalCameraAngle, maxHorizontalCameraAngle);
	}

	private Vector2 GetInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
            );
        return input;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

        Vector2 wantedVelocity = GetInput() * sensitivity;

        rotation += wantedVelocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y);
        rotation.x = ClampHorizontalAngle(rotation.x);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}
