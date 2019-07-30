using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager3 : MonoBehaviour {
	const string VERSION = "0.1.3v";
	string roomName = "playRoom3";
	public Transform spawnPoint;
	bool isSignaled;
	public GameObject player;

	void Start () {
		if (!string.IsNullOrEmpty (GetRoomName.roomName)) {
			roomName = GetRoomName.roomName;
		}
		isSignaled = true;
		Connect ();
	}

	void Connect(){
		PhotonNetwork.ConnectUsingSettings (VERSION);
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby(){		
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 2 };
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		SpawnMe ();
	}

	void SpawnMe(){
		GameObject me;
		if (PhotonNetwork.isMasterClient) {
			me = (GameObject)Instantiate(player,spawnPoint.position, spawnPoint.rotation);
			me.GetComponent<PlayerController3> ().enabled = true;
		} else {
			me = (GameObject)Instantiate(player,spawnPoint.position, new Quaternion (0f, 180f, 0f, 0f));
			GetComponent<PileCounts3> ().enabled = true;
		}

		me.GetComponent<SwitchPlayer3> ().enabled = true;

		if((PhotonNetwork.countOfPlayers == 2) && (isSignaled)) {
			isSignaled = false;
			GetComponent<PhotonView> ().RPC ("StartGame", PhotonTargets.Others, null);
		}
	}

	[PunRPC]
	void StartGame(){
		if (isSignaled) {
			isSignaled = false;
			GetComponent<GameController3> ().enabled = true;
			GetComponent<PileCounts3> ().enabled = true;
		}
	}
}