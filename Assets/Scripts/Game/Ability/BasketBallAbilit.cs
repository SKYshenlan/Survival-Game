using UnityEngine;
using QFramework;
using System.Collections.Generic;
using SurvivalGame;

namespace Brotato
{
	public partial class BasketBallAbilit : ViewController
	{
		private List<Ball> mBall = new List<Ball>();
		void Start()
		{
			Global.BasketBallCount.RegisterWithInitValue(count =>
			{
				if (mBall.Count < count)
				{
                    mBall.Add(Ball.Instantiate()
					.SyncPosition2DFrom(this)
					.Show()
					);
                }
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

        }
	}
}
