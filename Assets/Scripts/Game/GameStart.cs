using GameUI;
using QFramework;
using UnityEngine;

namespace Brotato
{
	public partial class GameStart : ViewController
	{
        private void Awake()
        {
            ResKit.Init();
        }
        void Start()
		{
			UIKit.OpenPanel<UIStartScreen>();
		}
	}
}
