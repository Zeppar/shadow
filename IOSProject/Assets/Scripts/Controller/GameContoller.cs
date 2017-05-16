using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour {

	public void RestartButtonOnClick() {
		SceneManager.LoadScene (0);
	}
}
