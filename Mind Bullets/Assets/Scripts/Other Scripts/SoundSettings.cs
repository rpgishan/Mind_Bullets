using UnityEngine;
using System.Collections;

public class SoundSettings : MonoBehaviour {

	bool isMute;
	public GameObject muteButton,musicButton;
	public AudioSource music;

	public void stopAudio(){
		if (music.isPlaying) {
			music.Stop ();
		} else {
			music.Play ();
		}
	}

	public void mute(){
		isMute = !isMute;
		AudioListener.volume = isMute ? 0 : 1;
	}

}
