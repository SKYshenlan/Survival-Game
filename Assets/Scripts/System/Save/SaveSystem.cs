using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;
using UnityEngine;

namespace Brotato
{
    /// <summary>
    /// 储存升级数据
    /// </summary>
    public class SaveSystem:AbstractSystem
    {
        public void Save()
        {

        }
        public void Load()
        {

        }
        private HashSet<string> Key = new HashSet<string>();
        public void SaveBool(string key,bool value)
        {
            Key.Add(key);
            PlayerPrefs.SetInt(key,value ? 1 : 0);
        }
        public bool LoadBool(string key, bool value = false)
        {
            Key.Add(key);
            return PlayerPrefs.GetInt(key, value ? 1 : 0) == 1;
        }
        public void SaveInt(string key, int value)
        {
            Key.Add(key);
            PlayerPrefs.SetInt(key, value);
        }
        public int LoadInt(string key, int value = 0)
        {
            Key.Add(key);
            return PlayerPrefs.GetInt(key, value);
        }
        public void SaveString(string key, string value)
        {
            Key.Add(key);
            PlayerPrefs.SetString(key, value);
        }
        public string LoadString(string key, string value = default)
        {
            Key.Add(key);
            return PlayerPrefs.GetString(key, value);
        }

        protected override void OnInit()
        {
            ActionKit.OnGUI.Register(() =>
            {
                if (Input.GetKey(KeyCode.L))
                {
                    foreach (var item in Key)
                    {
                        //调试面板 
                        GUILayout.Label(item + ":" + PlayerPrefs.GetInt(item));
                        GUILayout.Label(item + ":" + PlayerPrefs.GetString(item));
                        GUILayout.Label(item + ":" + PlayerPrefs.GetFloat(item));
                    }
                }
            });
        }
    }
}
