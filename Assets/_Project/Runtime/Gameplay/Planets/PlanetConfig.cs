﻿using UnityEngine;

namespace Runtime.Gameplay.Planets
{
    [CreateAssetMenu(menuName = "Gameplay/Planet Config")]
    public class PlanetConfig : ScriptableObject
    {
        public PlanetComponent Prefab => _prefab;
        public float Radius => _radius;
        public float OrbitalSpeed => _orbitalSpeed;

        public PlanetIndicatorConfig Temperature => _temperature;
        public PlanetIndicatorConfig Oxygen => _oxygen;
        public PlanetIndicatorConfig Water => _water;

        [SerializeField] private PlanetComponent _prefab;
        [SerializeField] private float _radius;
        [SerializeField] private float _orbitalSpeed;

        [SerializeField] private PlanetIndicatorConfig _temperature;
        [SerializeField] private PlanetIndicatorConfig _oxygen;
        [SerializeField] private PlanetIndicatorConfig _water;
    }
}