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
        /// <summary>
        /// 闪烁
        /// </summary>
        public static EasyEvent FlashScreen = new EasyEvent();
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            #region 回调
            var enemyList = FindObjectOfType<EnemyList>();
            EnemyList.EnemyCount.RegisterWithInitValue(count =>
            {
                enemyCount.text = $"敌人「{count}」";

            }).UnRegisterWhenDisabled(gameObject);//gameObject被销毁或隐藏时注销事件
            Global.Second.RegisterWithInitValue(_time =>
            {
                if (Time.frameCount % 30 == 0)
                {
                    var currenSecond = Mathf.FloorToInt(_time);
                    var seconds = currenSecond % 60;
                    Global.minutes.Value = currenSecond / 60;
                    time.text = $"「{Global.minutes.Value:00}:{seconds:00}」";
                }

            }).UnRegisterWhenDisabled(gameObject);//gameObject被销毁或隐藏时注销事件
            //注册并执行回调
            Global.Leve.RegisterWithInitValue(Leve =>
            {
                leve.text = $"等级「{Leve}」";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
            Global.Leve.Register(lv =>
            {
                Debug.Log("a");
                Time.timeScale = 0;
                ExpUpgrade.Show();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //注册并执行回调
            Global.Exp.RegisterWithInitValue(exp =>
            {
                ExpBgValue.fillAmount = exp / (float)Global.GetExp();
                if (exp >= Global.GetExp())
                {
                    int LV = Global.Leve.Value;
                    Global.Exp.Value = 0;
                    Global.Leve.Value++;
                    //Global.Interface.GetSystem<ExpUpgradeSystem>().Roll();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
            Global.Coins.RegisterWithInitValue(_coins =>
            {
                coins.text = $"金币「{_coins}」";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
            ActionKit.OnUpdate.Register(() =>
            {
                Global.Second.Value += Time.deltaTime;
                //当波次达到条件、敌人是空并且敌人数量为0即可达成通关条件
                if (enemyList.flag && enemyList.CcurrentWave == null && EnemyList.EnemyCount.Value == 0)
                {
                    UIKit.OpenPanel<UIGamePassPanel>();
                }

            }).UnRegisterWhenGameObjectDestroyed(gameObject); //gameObject被销毁或隐藏时注销事件

            FlashScreen.Register(() =>
            {
                //创建一个动作序列
                ActionKit.Sequence()
                //从0到0.5，持续时间0.1秒
                .Lerp(0, 0.5f, 0.1f, alpha => ScreenColor.ColorAlpha(alpha))
                //从0.5到0，持续时间0.2秒 结束设置为透明
                .Lerp(0.5f, 0, 0.2f, alpha => ScreenColor.ColorAlpha(alpha), () => ScreenColor.ColorAlpha(0))
                .Start(this);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            #endregion
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
