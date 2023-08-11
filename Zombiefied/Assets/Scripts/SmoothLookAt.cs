using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
	public Transform target; // The target object to look at horizontally
	public float rotationSpeed = 2.0f; // Speed of horizontal rotation
	public float rotationThreshold = 30.0f; // Minimum horizontal angle for rotation to start
	public float rotationStopThreshold = 5.0f; // Horizontal angle range within which rotation stops
	private float range = 5.0f; // Speed of rotation


	private void Update()
	{
		if (target != null && Vector3.Distance(target.position, transform.position) < range)
		{
			// Calculate the direction from this object to the target object (ignoring vertical component)
			Vector3 horizontalDirection = target.position - transform.position;
			horizontalDirection.y = 0; // Ignore the vertical component
			horizontalDirection.Normalize(); // Normalize the direction

			// Calculate the angle between this object's forward direction (projected horizontally) and the direction to the target (projected horizontally)
			float angle = Vector3.SignedAngle(transform.forward, horizontalDirection, Vector3.up);

			if (Mathf.Abs(angle) > rotationThreshold)
			{
				// Calculate the rotation to look at the target horizontally
				Quaternion targetRotation = Quaternion.LookRotation(horizontalDirection, Vector3.up);

				// Smoothly interpolate the current horizontal rotation towards the target horizontal rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
			}
			else if (Mathf.Abs(angle) < rotationStopThreshold)
			{
				// If the horizontal angle is within the stop threshold, stop horizontal rotation
				// This can help prevent constant small adjustments
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0), rotationSpeed * Time.deltaTime);
			}
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
