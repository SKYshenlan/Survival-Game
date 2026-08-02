using GameUI;
using QFramework;
using UnityEngine;

namespace Brotato
{
	public partial class GameStart : ViewController
	{
        void Start()
		{
			UIKit.OpenPanel<UIStartScreen>();
		}
	}
}
