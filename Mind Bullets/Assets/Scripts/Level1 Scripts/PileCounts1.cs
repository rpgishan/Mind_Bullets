using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PileCounts1 : MonoBehaviour {
	public Transform gen1;
	public Transform gen2;
	public Transform gen3;

	int currentCount = 0;
	int previousCount = 0;
	bool finalBullet;
	bool finalPlayer;
	bool activePlayer;

	public Text pile1;
	public Text pile2;
	public Text pile3;

	public int winnersSceneNo;
	public int losersSceneNo;


	void Start(){
		this.finalBullet = true;
		this.finalPlayer = false;
		this.activePlayer = false;
	}

	void Update () {
		this.currentCount = gen1.childCount + gen2.childCount + gen3.childCount;

		if ((this.currentCount == 1) && (this.finalBullet == true)) {
			this.finalBullet = false;
			this.finalPlayer = true;
			AutoSwitch ();
		}

		//calling the rpc only when the whole count is decreased by one otherwise network traffic gets high and 
		//data usage becomes very high
		if ((PhotonNetwork.isMasterClient) && (previousCount != currentCount)) {			
			GetComponent<PhotonView> ().RPC ("SetPileCounts", PhotonTargets.All, gen1.childCount.ToString (), gen2.childCount.ToString (), gen3.childCount.ToString ());
			previousCount = currentCount;

			this.activePlayer = GameObject.FindGameObjectWithTag ("PlayerL1").GetComponent<PlayerController1> ().isActiveAndEnabled;
			if ((this.finalPlayer) && (this.activePlayer) && (this.currentCount == 0) && (PhotonNetwork.isMasterClient)){
				//load winner gui
				GetComponent<PhotonView> ().RPC ("Loser", PhotonTargets.Others, null);
				changeTheScene(winnersSceneNo);
				Debug.Log("Winner");
				this.finalPlayer = false;
			}
			if ((this.finalPlayer) && (!this.activePlayer) && (this.currentCount == 0) && (PhotonNetwork.isMasterClient)) {
				//load loser gui
				GetComponent<PhotonView>().RPC("Winner",PhotonTargets.Others,null);
				changeTheScene(losersSceneNo);
				Debug.Log("Loser");
				this.finalPlayer = false;
			}
		}
	}

	//pile counts are updated in both views when this rpc is called
	[PunRPC]
	void SetPileCounts(string first, string second, string third){
		pile1.text = first;
		pile2.text = second;
		pile3.text = third;
	}

	void AutoSwitch(){
		if (this.finalBullet == false) {
			GameObject.FindGameObjectWithTag ("PlayerL1").GetComponent<PhotonView>().RPC ("SwitchTurn", PhotonTargets.All, null);
		}
	}

	[PunRPC]
	void Winner(){
		//Load winner gui
		changeTheScene(winnersSceneNo);
		Debug.Log ("Im the winner");
	}

	[PunRPC]
	void Loser(){
		//load loser gui
		changeTheScene(losersSceneNo);
		Debug.Log ("Im the Loser");
	}

	void changeTheScene(int sceneNo){
		Application.LoadLevel (sceneNo);
	}
}