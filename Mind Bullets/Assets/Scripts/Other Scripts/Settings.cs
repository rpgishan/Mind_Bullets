using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour {

	bool isButtonAvailable;
	public static string roomName;
	public GameObject muteButton,musicButton,enterButton;
	public InputField roomNameTextBox;

	// Use this for initialization
	void Start () {
		//roomNameTextBox.shouldHideMobileInput=true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeTheScene(int sceneNo){
		Application.LoadLevel (sceneNo);
	}

	public void showButtons(){
		roomNameTextBox.gameObject.SetActive (true);
		enterButton.gameObject.SetActive (true);

	}

	public void getTextBoxData(){
		roomName = (roomNameTextBox.text != null) ? roomNameTextBox.text : "playRoom";
	}

	public void settingButtonsHideShow(){
		isButtonAvailable = !isButtonAvailable;
		if(isButtonAvailable){
			muteButton.SetActive(true);
			musicButton.SetActive(true);
		}else{
			muteButton.SetActive(false);
			musicButton.SetActive(false);
		}
	}


}
