using UnityEngine;
using QFramework;
//using System;
//using System;

namespace Brotato
{
	public partial class CameraMove : ViewController
	{
		private Vector2 playPos = Vector2.zero;
		/// <summary>
		/// 当前位置
		/// </summary>
		private Vector3 currentPosition;
		/// <summary>
		/// 是否振动
		/// </summary>
		private bool mShake = false;
		/// <summary>
		/// 振动
		/// </summary>
		private int mShakeFrame = 0;
		/// <summary>
		/// 摄像机
		/// </summary>
		private static CameraMove mDefault = null;
		/// <summary>
		/// 振幅
		/// </summary>
		private float mShakeA = 1.0f;
		public static Transform LBTrans => mDefault.LB;
		public static Transform RTTrans => mDefault.RT;
        private void Awake()
        {
            mDefault = this;
        }
        private void OnDestroy()
        {
            mDefault = null;
        }
		public static void Shake()
		{
            mDefault.mShake = true;
			mDefault.mShakeFrame = 30;
            mDefault.mShakeA = 1.0f;
        }
        void Start()
		{
			Application.targetFrameRate = 60;
		}
		void Update()
		{
			if (Play.Defaulf)
			{
				playPos = Play.Defaulf.transform.position;
				transform.PositionX((1.0f - Mathf.Exp( -Time.deltaTime*20)).Lerp(transform.position.x,playPos.x));
                transform.PositionY((1.0f - Mathf.Exp( -Time.deltaTime * 20)).Lerp(transform.position.y, playPos.y));
				currentPosition = transform.position;
				if (mShake)
				{
                    //计算当前衰减后的强度
                    var shakeA = Mathf.Lerp(mShakeA, 0.0f,mShakeFrame/30.0f);
					//摄像机振动每次随机位置
                    transform.position = new Vector3(currentPosition.x + Random.Range(-shakeA, shakeA), currentPosition.y + Random.Range(-shakeA, shakeA), currentPosition.z);
                }
				mShakeFrame--;
				if(mShakeFrame <= 0)
				{
					mShake = false;
				}
            }
		}
	}
}
