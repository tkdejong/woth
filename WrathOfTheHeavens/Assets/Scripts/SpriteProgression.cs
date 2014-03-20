using UnityEngine;
using System.Collections.Generic;

public class SpriteProgression : MonoBehaviour {
	//The sprites in this list will occur in order
	public List<Sprite> spriteOrder;

	int spriteIndex = 0;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	//Change the sprite to the next one in the list
	public void NextSprite() {
		if (spriteIndex < spriteOrder.Count) {
			spriteRenderer.sprite = spriteOrder[spriteIndex];
			spriteIndex++;
		}
	}
}
//""