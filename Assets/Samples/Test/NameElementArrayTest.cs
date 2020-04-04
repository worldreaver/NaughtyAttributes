using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class NameElementArrayTest : MonoBehaviour
{
    [NamedArray(typeof(WaveNameIndex)), ReorderableList] public List<Editor_UnitWave> Units;

    [NamedArray(new string[] {"First", "Second", "Third"})]
    public int[] labeledValues;

    private enum Order
    {
        First,
        Second,
        Third
    }

    [NamedArray(typeof(Order))] public int[] enumLabeledValues;


    [Serializable]
    public class Editor_UnitWave
    {
        public int id;
        public int level;
        public float timeDelaySpawn;
    }

    public enum WaveNameIndex
    {
        Wave1,
        Wave2,
        Wave3,
        Wave4,
        Wave5,
        Wave6,
        Wave7,
        Wave8,
        Wave9,
        Wave10,
    }
}