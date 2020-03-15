using UnityEngine;

namespace NaughtyAttributes.Test
{
    public enum TestEnum2
    {
        ItemA,
        ItemB,
        ItemC,
        ItemD
    }

    public class EnumTest : MonoBehaviour
    {
        [Enum]
        public TestEnum2 flags0;

        public EnumNest1 nest1;
    }

    [System.Serializable]
    public class EnumNest1
    {
        [Enum]
        public TestEnum2 flags1;

        public EnumNest2 nest2;
    }

    [System.Serializable]
    public class EnumNest2
    {
        [Enum]
        public TestEnum2 flags2;
    }
}