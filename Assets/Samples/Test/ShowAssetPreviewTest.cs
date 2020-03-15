using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ShowAssetPreviewTest : MonoBehaviour
	{
		[PreviewField(48, 48, AttributeAlign.Left)]
		public Sprite sprite0;
		
		public Sprite material;

		public int damage = 100;
		[PreviewField(align: AttributeAlign.Right)]
		public Sprite prefab0;

		public ShowAssetPreviewNest1 nest1;
	}

	[System.Serializable]
	public class ShowAssetPreviewNest1
	{
		[PreviewField]
		public Sprite sprite1;

		[PreviewField(96, 96)]
		public Sprite prefab1;

		public ShowAssetPreviewNest2 nest2;
	}

	[System.Serializable]
	public class ShowAssetPreviewNest2
	{
		[PreviewField]
		public Sprite sprite2;

		[PreviewField(96, 96)]
		public Sprite prefab2;
	}
}
