using GameUI;
using QFramework;
using UnityEngine;

namespace Brotato
{
	public partial class GameUIController : ViewController
	{
		void Start()
		{
			// Code Here
			//打开面板
			UIKit.OpenPanel<UIGamePanel>();
		}

        private void OnDestroy()
        {
			//关闭面板
            UIKit.ClosePanel<UIGamePanel>();
        }
    }
}
