using System;
using UnityEngine;

namespace UniOwl.Celestials
{
    [Serializable]
    public class PhysicalSettings
    {
        [Range(0f, 50f)]
        public float radius;
        [Range(0f, 50f)]
        public float amplitude;
        [Range(0f, 2f)]
        public float seaLevel;
    }
}
