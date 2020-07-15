using UnityEngine;

public class ScaleToViewpoint : MonoBehaviour
{
	[HideInInspector]
	public float distanceFromCamera;
	[HideInInspector]
	public float scaleFactor;

	public float objectSize = 10.0f;

	private Vector3 defaultScale;
	private Camera defaultCamera;

	// Start is called before the first frame update
	void Start()
	{
		defaultScale = transform.localScale;
		defaultCamera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		distanceFromCamera = (transform.position - defaultCamera.transform.position).magnitude;
		scaleFactor = distanceFromCamera * objectSize;
		transform.localScale = defaultScale * scaleFactor;
	}
}
