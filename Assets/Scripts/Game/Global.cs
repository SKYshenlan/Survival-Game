using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace SurvivalGame
{
    public class Global
    {
        /// <summary>
        /// 经验 主动通知UI发生改变的响应式数据容器
        /// </summary>
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);
        /// <summary>
        /// 等级
        /// </summary>
        public static BindableProperty<int> Leve = new BindableProperty<int>(1);
        /// <summary>
        /// 攻击力
        /// </summary>
        public static BindableProperty<float> Atk = new BindableProperty<float>(1);
        /// <summary>
        /// 倒计时
        /// </summary>
        public static BindableProperty<float> Second = new BindableProperty<float>(0);
    }
}
