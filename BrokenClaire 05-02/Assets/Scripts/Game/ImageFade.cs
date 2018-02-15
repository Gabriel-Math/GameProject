using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageFade : MonoBehaviour {

	public Image img;
	Controller pl;

	IEnumerator Start()
	{
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
		Cursor.visible = false;
		pl.enabled = false;
		img.canvasRenderer.SetAlpha (0.0f);
		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		FadeOut ();
		yield return new WaitForSeconds(2.5f);
		img.enabled = false;
		Cursor.visible = true;
		pl.enabled = true;
	}

	void FadeIn() {
		img.CrossFadeAlpha(2f, 1.5f, false);
	}

	void FadeOut() {
		img.CrossFadeAlpha(0f, 2.5f, false);
	}
}