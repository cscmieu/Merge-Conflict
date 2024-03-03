using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkyBoxes : MonoBehaviour
{
	public static void LoadSkybox(Material skyboxToLoad)
	{
		RenderSettings.skybox = skyboxToLoad;
	}
}
