using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class MenuLoader : MonoBehaviour {
	float countDown;
	float timer;
	bool loader;
	Renderer ren;
	public Texture[] textures;
	int currentTexture;

	GvrAudioSource rolloverSFX;

	public AudioClip dink;

	void Start () {
		countDown = 3.0f;
		timer = 0.0f;

		loader = false;

		ren = this.gameObject.GetComponent<Renderer> ();

		rolloverSFX = GetComponent<GvrAudioSource> ();
	}

	void Update () {

		if (loader == true) {
			timer += Time.deltaTime;
			if (timer > countDown) {
				loadFromBeginning();

			}

		}
	
	}

	public void enterStart(){
		loader = true;
		currentTexture++;
		currentTexture %= textures.Length;
		ren.material.mainTexture = textures [currentTexture];
		rolloverSFX.PlayOneShot(dink,1.0f);
	}
	public void exitStart(){
		loader = false;
		timer = 0.0f;
		currentTexture++;
		currentTexture %= textures.Length;
		ren.material.mainTexture = textures [currentTexture];
	}

	public void loadFromBeginning(){
		SceneManager.LoadScene ("F_01", LoadSceneMode.Single);
	}


}
