using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PileCounts2 : MonoBehaviour {
	public Transform gen1;
	public Transform gen2;
	public Transform gen3;

	int currentCount = 0;
	int previousCount = 0;
	int minMargin;
	int minMarginRestriction;
	int pickCount;
	bool finalBullet;
	bool notFinal;
	bool finalPlayer;
	bool activePlayer;
	bool magicBullet;

	public Text pile1;
	public Text pile2;
	public Text pile3;
	public Text marginText;
	public Text marginRestrictionText;

	public int winnersSceneNo;
	public int losersSceneNo;

	void Start(){
		this.finalBullet = true;
		this.notFinal = true;
		this.minMargin = 0;
		this.minMarginRestriction = 0;
		this.pickCount = 0;
		this.currentCount = 0;
		this.finalPlayer = false;
		this.activePlayer = false;
		this.magicBullet = false;
	}

	void Update () {
		if ((PhotonNetwork.isMasterClient) && (minMargin==0)) {
			this.minMargin = GameObject.FindGameObjectWithTag ("Managers").GetComponent<GameController2> ().minMargin;
			this.minMarginRestriction = GameObject.FindGameObjectWithTag ("Managers").GetComponent<GameController2> ().minMarginRestriction;
		}

		this.currentCount = gen1.childCount + gen2.childCount + gen3.childCount;

		if ((this.currentCount == 1) && (this.finalBullet == true)) {
			this.finalBullet = false;
			this.notFinal = false;
			this.finalPlayer = true;
			AutoSwitchFinal ();
		}else if ((this.currentCount <= this.minMargin) && (previousCount != currentCount) && (this.notFinal == true)) {
			Debug.Log ("in margin");
			Debug.Log (this.pickCount.ToString ());
			if (magicBullet == false) {
				PickChecker ();
			}
		}

		//calling the rpc only when the whole count is decreased by one otherwise network traffic gets high and 
		//data usage becomes very high
		if ((PhotonNetwork.isMasterClient) && (previousCount != currentCount)) {			
			GetComponent<PhotonView> ().RPC ("SetPileCounts", PhotonTargets.All, gen1.childCount.ToString (), gen2.childCount.ToString (), gen3.childCount.ToString (), minMargin.ToString(), minMarginRestriction.ToString());
			previousCount = currentCount;
		}

		//Selecting the winner
		this.activePlayer = GameObject.FindGameObjectWithTag ("PlayerL2").GetComponent<PlayerController2> ().isActiveAndEnabled;
		if ((this.finalPlayer) && (this.activePlayer) && (this.currentCount == 0) && (PhotonNetwork.isMasterClient)){
			//load winner gui
			Debug.Log("Winner");
			GetComponent<PhotonView> ().RPC ("Loser", PhotonTargets.Others, null);
			changeTheScene(winnersSceneNo);
			this.finalPlayer = false;
		}
		if ((this.finalPlayer) && (!this.activePlayer) && (this.currentCount == 0) && (PhotonNetwork.isMasterClient)) {
			//load loser gui
			GetComponent<PhotonView>().RPC("Winner",PhotonTargets.Others,null);
			Debug.Log("Loser");
			changeTheScene(losersSceneNo);
			this.finalPlayer = false;
		}
	}

	//pile counts are updated in both views when this rpc is called
	[PunRPC]
	void SetPileCounts(string first, string second, string third, string bottomMargin, string bottomRestriction){
		pile1.text = first;
		pile2.text = second;
		pile3.text = third;
		marginText.text = bottomMargin;
		marginRestrictionText.text = bottomRestriction;
	}

	[PunRPC]
	public void MagicBulletActivator(bool taken){
		this.magicBullet = taken;
	}

	void AutoSwitchFinal(){
		if (this.finalBullet == false) {
			GameObject.FindGameObjectWithTag ("PlayerL2").GetComponent<PhotonView>().RPC ("SwitchTurn", PhotonTargets.All, null);
		}
	}

	void PickChecker(){		
		if (this.pickCount == this.minMarginRestriction) {
			this.pickCount = 0;
			AutoSwitch ();		
		}
		this.pickCount++;
		Debug.Log (pickCount.ToString ());
	}

	void AutoSwitch(){
		GameObject.FindGameObjectWithTag ("PlayerL2").GetComponent<PhotonView> ().RPC ("SwitchTurn", PhotonTargets.All, null);
	}

	[PunRPC]
	void PickCountReset(){
		Debug.Log ("Awaaa");
		if (this.pickCount != 0) {
			this.pickCount = 1;
		}
	}

	[PunRPC]
	void Winner(){
		//load winner gui
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