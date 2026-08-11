using UnityEngine;
using QFramework;
using System.Collections.Generic;
//using System;

namespace Brotato
{

	public partial class EnemyList : ViewController
	{
        [SerializeField]
        LeveWaveConfig config;
        /// <summary>
        /// 敌人队列
        /// </summary>
        private Queue<EnemyWave> mEnemyWaveQueue = new Queue<EnemyWave>();
        private EnemyWave currentWave = null;
        public EnemyWave CcurrentWave => currentWave;
        /// <summary>
        /// 当前时间
        /// </summary>
        private float currentSecond = 0f;
        /// <summary>
        /// 波次时间
        /// </summary>
        private float currentWaveSecond = 0f;
        /// <summary>
        /// 当前波次
        /// </summary>
        private int WaveCount = 0;
        /// <summary>
        /// 总数
        /// </summary>
        private int mTotalCout = 0;
        public bool flag => WaveCount == mTotalCout;
        public static BindableProperty<int> EnemyCount = new BindableProperty<int>(0);
        private void Start()
        {
            //遍历波次集合
            foreach (var group in config.enemy)
            {
                foreach(var item in group.Waves)
                {
                    //将敌人存入队列
                    mEnemyWaveQueue.Enqueue(item);
                    mTotalCout++;
                }
            }
        }
        private void Update()
        {
            if(currentWave == null)
            {
                if(mEnemyWaveQueue.Count > 0)
                {
                    WaveCount++;
                    currentWave = mEnemyWaveQueue.Dequeue();
                    currentSecond = 0;
                    currentWaveSecond = 0;
                }
            }
            if(currentWave != null)
            {
                currentSecond += Time.deltaTime;
                currentWaveSecond += Time.deltaTime;
                
                if (currentSecond >= currentWave.DurationSec)
                {
                    currentSecond = 0f;
                    //获取玩家
                    var play = Play.Defaulf;
                    if (play)
                    {
                        var xOry = RandomUtility.Choose(-1, 1);
                        var pos = Vector2.zero;
                        if(xOry == -1)
                        {
                            pos.x = RandomUtility.Choose(CameraMove.LBTrans.position.x, CameraMove.RTTrans.position.x);
                            pos.y = Random.Range(CameraMove.LBTrans.position.y, CameraMove.RTTrans.position.y);
                        }
                        else
                        {
                            pos.x = Random.Range(CameraMove.LBTrans.position.x, CameraMove.RTTrans.position.x);
                            pos.y = RandomUtility.Choose(CameraMove.LBTrans.position.y, CameraMove.RTTrans.position.y);
                            
                        }
                        //在“pos位置”生成敌人并显示
                        currentWave.EnemyPrefab.Instantiate()
                            .Position(pos)
                            .Self(self =>
                            {
                                var enemy = self.GetComponent<IEnemy>();
                                enemy.SetSpeedScale(currentWave.SpeedScale);
                                enemy.SetHPScale(currentWave.HPScale);
                            })
                            .Show();
                    }
                }
                if (currentWaveSecond >= currentWave.Second)
                {
                    currentWave = null;
                }
            }
            
        }

    }
}
