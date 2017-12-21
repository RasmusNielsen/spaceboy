using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	public float smoothTime = 0.1F;
	private Vector3 velocity = Vector3.zero;


	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		//offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		if (player){

			Vector2 newPos2D = Vector2.zero;
			newPos2D.y = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);
			Vector3 newPos = new Vector3 (0 + 1.0F, newPos2D.y, -10);
			transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
	
		}

		//transform.position = new Vector3(0+1f, player.transform.position.y+1.0f, -10);
		//transform.position = Vector3.SmoothDamp (transform.position, player.transform.position, ref velocity, smoothTime);
	}


}
	// LateUpdate is called after Update each frame
//	void LateUpdate () 
//	{
//		if (player) {
//
//		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
//	transform.position = player.transform.position + offset;
//	transform.position = new Vector3(0+1f, player.transform.position.y+1.0f, -10);
//
//
//	//transform.position = Vector2.Lerp(offset, player.transform.position, 15f * Time.deltaTime);
//
//
//
//
