using UnityEngine;

namespace UI.Window.Scripts
{
	public class FakeBranchesAndRepo : MonoBehaviour
	{
		[SerializeField] private GameObject panel;

		public void DoTheThing()
		{
			panel.SetActive(!panel.activeSelf);
		}
	}
}
