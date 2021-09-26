using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaSelector : MonoBehaviour
{
	public void Chenge_Scena(int Number)
	{
		SceneManager.LoadScene(Number);
	}
	public void Exit()
	{
		Application.Quit();
	}
}