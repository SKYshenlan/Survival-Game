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
        public static BindableProperty<int> Exp = new BindableProperty<int>();
    }
}
