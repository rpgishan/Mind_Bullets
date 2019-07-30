using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour {
	public Transform gen1;
	public Transform gen2;
	public Transform gen3;

	string pile1Bullet= "Pile1BulletL2";
	string pile2Bullet= "Pile2BulletL2";
	string pile3Bullet= "Pile3BulletL2";
	public int minMargin;
	public int minMarginRestriction;
	bool isMute;
	bool sign = true;

	void Update () {		
		if (sign == true) {
			FirstGen ();
			SeconddGen ();
			ThirdGen ();
			MinMarginGen ();
			MinMarginRestrictionGen ();
			sign = false;
		}		
	}

	void FirstGen(){
		int toGen =  Random.Range(5,6);
		string name = "pile1";
		for (int i = 1; i <= toGen; i++) {
			GameObject newBullet = (GameObject)PhotonNetwork.Instantiate(pile1Bullet, gen1.position, gen1.rotation,0);
			newBullet.name = name.Insert (2, i.ToString ());
			newBullet.GetComponent<BulletController2> ().enabled = true;
			newBullet.transform.SetParent (gen1);
		}
	}

	void SeconddGen(){
		int toGen =  Random.Range(8,12);
		for (int i = 1; i <= toGen; i++) {
			GameObject newBullet =  (GameObject)PhotonNetwork.Instantiate(pile2Bullet, gen2.position, gen2.rotation,0);
			newBullet.GetComponent<BulletController2> ().enabled = true;
			newBullet.transform.SetParent (gen2);
		}
	}

	void ThirdGen(){
		int toGen =  Random.Range(5,6);
		for (int i = 1; i <= toGen; i++) {
			GameObject newBullet =  (GameObject)PhotonNetwork.Instantiate(pile3Bullet, gen3.position, gen3.rotation,0);
			newBullet.GetComponent<BulletController2> ().enabled = true;
			newBullet.transform.SetParent (gen3);
		}
	}

	void MinMarginGen(){
		int min = Random.Range (1, 4);
		int max = Random.Range (1, 4);

		if (min == 1) {
			min = gen1.childCount;
		} else if (min == 2) {
			min = gen2.childCount;
		} else if (min == 3) {
			min = gen3.childCount;
		}
		if (max == 1) {
			max = gen1.childCount;
		} else if (max == 2) {
			max = gen2.childCount;
		} else if (max == 3) {
			max = gen3.childCount;
		}

		this.minMargin = Random.Range (min, max);
		Debug.Log (this.minMargin);
	}

	void MinMarginRestrictionGen(){
		this.minMarginRestriction = Random.Range (2, 4);
		Debug.Log (this.minMarginRestriction);
	}
}