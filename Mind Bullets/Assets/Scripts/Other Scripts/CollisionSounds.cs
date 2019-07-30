using UnityEngine;
using System.Collections;

public class CollisionSounds : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip bullrtCollisionSound;


	public void onCollision(Collision collision){
		if (!audioSource.isPlaying) {
			audioSource.PlayOneShot (bullrtCollisionSound, 1.0F);
		}
	}

	void OnTriggerEnter (Collider other) 
	{
		if(other.gameObject.tag == "Table")
		{
			audioSource.PlayOneShot (bullrtCollisionSound, 1.0F);
		}

	}
}
