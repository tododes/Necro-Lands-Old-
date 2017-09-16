using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScript : MonoBehaviour {
	public Text loadingText;

	public void LoadScene()
	{
		StartCoroutine (Loading());
	}

	IEnumerator Loading()
	{
		AsyncOperation asy = Application.LoadLevelAsync ("MainScene");

		asy.allowSceneActivation = true;
		yield return asy;
	}
}
