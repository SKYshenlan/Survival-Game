using UnityEngine;
using QFramework;
using System;

namespace Brotato
{
	public partial class CameraMove : ViewController
	{
		private Vector2 playPos = Vector2.zero;
		void Start()
		{
			// Code Here
		}
		void Update()
		{
			if (Play.Defaulf)
			{
				playPos = Play.Defaulf.transform.position;
				transform.PositionX((1.0f - Mathf.Exp( -Time.deltaTime*20)).Lerp(transform.position.x,playPos.x));
                transform.PositionY((1.0f - Mathf.Exp( -Time.deltaTime * 20)).Lerp(transform.position.y, playPos.y));
            }
		}
	}
}
