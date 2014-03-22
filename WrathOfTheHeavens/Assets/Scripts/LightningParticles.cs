using UnityEngine;
using System.Collections;

public class LightningParticles : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		//Change Foreground to the layer you want it to display on 
		//You could prob. make a public variable for this
		particleSystem.renderer.sortingLayerName = "Lightning";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
