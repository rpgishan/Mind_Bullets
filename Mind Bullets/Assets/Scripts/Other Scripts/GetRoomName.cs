using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetRoomName : MonoBehaviour {
	
	public InputField roomNameTextBox;
	public static string roomName = "Playroom";

	public void getTextBoxData(string defaultRoomName){
		roomName = (!string.IsNullOrEmpty(roomNameTextBox.text)) ? roomNameTextBox.text : defaultRoomName;
	}

}
