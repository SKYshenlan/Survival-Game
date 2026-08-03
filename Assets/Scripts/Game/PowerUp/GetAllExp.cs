using UnityEngine;
using QFramework;

namespace Brotato
{
	public partial class GetAllExp : ViewController
	{
		void Start()
		{
			// Code Here
		}
        /// <summary>
        /// 拾取所有经验
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<pickupRange>())
            {
                AudioKit.PlaySound("get_all_exp");
                foreach (var exp in FindObjectsByType<Exp>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
                {
                    ActionKit.OnUpdate.Register(() =>
                    {
                        var play = Play.Defaulf;
                        if(play)
                        {
                            var dir = play.Position() - exp.Position();
                            exp.transform.Translate(dir.normalized * Time.deltaTime * 10f);
                        }
                    }).UnRegisterWhenGameObjectDestroyed(exp);
                }
                this.DestroyGameObjGracefully();
            }

        }
    }
}
