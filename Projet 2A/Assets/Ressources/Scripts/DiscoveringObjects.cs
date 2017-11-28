using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveringObjects : MonoBehaviour {

	public GameObject myTick = null;
	private float maxRay = 0f;
	private int listRange;

	bool checkRayon(float maxRay, Ray pos, List<Ray> l_bombs, int listRange){
		int c = 0;
		for (int i = 0; i < listRange; i++) {
			float dist_x = Mathf.Abs (pos.origin.x - l_bombs [i].origin.x);
			float dist_y = Mathf.Abs (pos.origin.y - l_bombs [i].origin.y);
			if (Mathf.Max(dist_x,dist_y) < maxRay) {
				c++;
			}
			Debug.Log ("i = " + i + " maxRay = " + maxRay + " dist_x = " + dist_x + " dist_y = " + dist_y);

		}

		Debug.Log (" c = " + c);
		if (c == listRange) {
			return true;
		}
		else{
			return false;
		}
	}

	// Use this for initialization
	void Start () {
		maxRay = Camera.main.orthographicSize * 2; 
	}


	// Update is called once per frame
	void Update () {
		List<Ray> l_bombs = ListBombs.l_bombs;
		if (Input.GetMouseButtonDown (0) && !PlacingObjects.allowClick) {
			listRange = ListBombs.listRange;
			var pos = Camera.main.ScreenPointToRay (Input.mousePosition); //Tableau donnant la position de la souris
			if(checkRayon(maxRay, pos,l_bombs,listRange) || listRange != 0){
				Instantiate (myTick, pos.origin, transform.rotation);
				listRange--;
			}
					//Instantiate (myTick, ray.origin, transform.rotation);

		}

	}
}
