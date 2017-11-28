using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlacingObjects : MonoBehaviour {

	public GameObject myBomb = null;
	public static bool allowClick = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && allowClick) {
			var pos = Camera.main.ScreenPointToRay (Input.mousePosition); //Tableau donnant la position de la souris
			ListBombs.l_bombs.Add(pos);
			ListBombs.listRange++;
			Instantiate (myBomb, pos.origin, transform.rotation);

		}

	}
}
