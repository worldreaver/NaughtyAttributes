using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class HorizontalLineTest : MonoBehaviour
	{
		[Separator("hello", color: EColor.Black)]
		[Header("Black")]
		[Separator(color: EColor.Blue)]
		[Header("Blue")]
		[Separator(color: EColor.Gray)]
		[Header("Gray")]
		[Separator(color: EColor.Green)]
		[Header("Green")]
		[Separator(color: EColor.Indigo)]
		[Header("Indigo")]
		[Separator(color: EColor.Orange)]
		[Header("Orange")]
		[Separator(color: EColor.Pink)]
		[Header("Pink")]
		[Separator(color: EColor.Red)]
		[Header("Red")]
		[Separator(color: EColor.Violet)]
		[Header("Violet")]
		[Separator(color: EColor.White)]
		[Header("White")]
		[Separator(color: EColor.Yellow)]
		[Header("Yellow")]
		[Separator(10.0f)]
		[Header("Thick")]
		public int line0;

		public HorizontalLineNest1 nest1;
	}

	[System.Serializable]
	public class HorizontalLineNest1
	{
		[Separator]
		public int line1;

		public HorizontalLineNest2 nest2;
	}

	[System.Serializable]
	public class HorizontalLineNest2
	{
		[Separator]
		public int line2;
	}
}
