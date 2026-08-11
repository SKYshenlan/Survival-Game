using UnityEngine;
using QFramework;

namespace Brotato
{
	public partial class FxController : ViewController
	{
		private static FxController mDefaulf;
        private void Awake()
        {
            mDefaulf = this;
        }
        private void OnDestroy()
        {
            mDefaulf = null;
        }
        public static void Play(SpriteRenderer sprite,Color dissolveColor)
        {
            mDefaulf.EnemyDieFx.Instantiate()
                .Position(sprite.Position())
                .LocalScale(sprite.Scale())
                .Self(self =>
                {
                    self.GetComponent<Dissolve>().DissolveColor = dissolveColor;
                    self.sprite = sprite.sprite;
                }).Show();
        }
    }
}
