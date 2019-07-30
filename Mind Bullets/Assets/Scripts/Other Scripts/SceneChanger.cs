using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	public void changeTheScene(int sceneNo){
		Application.LoadLevel (sceneNo);
	}
}
