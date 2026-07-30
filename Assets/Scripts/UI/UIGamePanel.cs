using UnityEngine;
using UnityEngine.UI;
using QFramework;
using SurvivalGame;
using System;
using Brotato;

namespace GameUI
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            // please add init code here
            TextAtk();
			var enemyList = FindObjectOfType<EnemyList>();
			EnemyList.EnemyCount.RegisterWithInitValue(count =>
			{
				enemyCount.text = $"敌人「{count}」";

            }).UnRegisterWhenDisabled(gameObject);//gameObject被销毁或隐藏时注销事件
            Global.Second.RegisterWithInitValue(_time =>
			{
				if(Time.frameCount % 30 == 0)
				{
                    var currenSecond = Mathf.FloorToInt(_time);
                    var seconds = currenSecond % 60;
                    Global.minutes.Value = currenSecond / 60;
                    time.text = $"「{Global.minutes.Value:00}:{seconds:00}」";
                }

            }).UnRegisterWhenDisabled(gameObject);//gameObject被销毁或隐藏时注销事件
            //注册并执行回调
            Global.Exp.RegisterWithInitValue(exp =>
			{
				xp.text = $"经验值「{exp}/{Global.GetExp()}」";
				if (exp >= Global.GetExp())
				{
					int LV = Global.Leve.Value;
					Global.Exp.Value = 0;
					Global.Leve.Value++;
					if (LV != Global.Leve.Value)
					{
						Time.timeScale = 0;
                        Background.Show();
					}
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
			//注册并执行回调
			Global.Leve.RegisterWithInitValue(Leve =>
			{
				leve.text = $"等级「{Leve}」";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
			ActionKit.OnUpdate.Register(() =>
			{
				Global.Second.Value += Time.deltaTime;
				//当波次达到条件、敌人是空并且敌人数量为0即可达成通关条件
				if(enemyList.flag && enemyList.CcurrentWave == null && EnemyList.EnemyCount.Value == 0)
				{
					UIKit.OpenPanel<UIGamePassPanel>();
                }

			}).UnRegisterWhenGameObjectDestroyed(gameObject); //gameObject被销毁或隐藏时注销事件
			//提升攻击力
            BinUp.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                //记录当前等级攻击力
                float _atk = Global.Atk.Value;
                //提升15%的攻击
                Global.Atk.Value += _atk * 0.15f;
                TextAtk();
                Background.Hide();
            });
			//提升攻击速度
            attackSpeed.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                //记录当前等级攻击力
                float Speed = Global.AtkSpeed.Value;
                //提升5%的攻击速度
                Global.AtkSpeed.Value -= Speed * 0.05f;
                TextAtk();
                Background.Hide();
            });
        }

        private void TextAtk()
        {
            atk.text = $"攻击「{Global.Atk.Value.ToString("0.##")}」";
        }

        protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
			Time.timeScale = 1;
		}
	}
}
