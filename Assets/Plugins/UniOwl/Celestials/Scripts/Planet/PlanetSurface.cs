﻿using System;
using UniOwl.Components;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UniOwl.Celestials
{
    using static ColorUtils;
    
    [SearchMenu("Planet", "Surface")]
    [DisallowMultiple]
    public class PlanetSurface : PlanetComponent
    {
        private static readonly int s_rimColor = Shader.PropertyToID("_RimColor");
        private static readonly int s_grassColor = Shader.PropertyToID("_GrassColor");
        private static readonly int s_sandColor = Shader.PropertyToID("_SandColor");
        private static readonly int s_snowColor = Shader.PropertyToID("_SnowColor");
        private static readonly int s_dryColor = Shader.PropertyToID("_DryColor");
        private static readonly int s_rockColor = Shader.PropertyToID("_RockColor");
        private static readonly int s_tempTint = Shader.PropertyToID("_TempTint");
        private static readonly int s_overallLevel = Shader.PropertyToID("_OverallLevel");
        private static readonly int s_heightRangeSand = Shader.PropertyToID("_HeightRangeSand");
        private static readonly int s_heightRangeSnow = Shader.PropertyToID("_HeightRangeSnow");
        private static readonly int s_slopeRange = Shader.PropertyToID("_SlopeRange");
        private static readonly int s_tempLevel = Shader.PropertyToID("_TempLevel");

        [SerializeField]
        private ModelSettings _model;
        [SerializeField]
        private TextureSettings _textures;
        [SerializeField]
        private TerrainGeneratorSettings _generation = new()
        {
            seed = 0,
            frequency = 1f,
            persistence = 0.5f,
            lacunarity = 2f,
            octaves = 1,
            redistributionPower = 1f,
            erosionPower = 0f,
            warpingOffset = float3.zero,
            warpingStrength = 0f,
        };
        
        #if UNITY_EDITOR
        [SerializeField]
        private bool _updateTerrain;
        public bool UpdateTerrain => _updateTerrain;
        #endif
        
        public ModelSettings Model => _model;
        public TextureSettings Textures => _textures;
        public TerrainGeneratorSettings Generation => _generation;

        [Header("Appearance")]
        [SerializeField]
        private Color rimColor = HexToRGBA("38434C");
        [SerializeField]
        private Color grassColor = HexToRGBA("56BC4F");
        [SerializeField]
        private Color sandColor = HexToRGBA("56BC4F");
        [SerializeField]
        private Color snowColor = HexToRGBA("FFFFFF");
        [SerializeField]
        private Color dryColor = HexToRGBA("CDB375");
        [SerializeField]
        private Color rockColor = HexToRGBA("8E8E8E");

        [SerializeField, MinMaxSlider(0f, 1f)]
        [InspectorName("Sand Range (In Radii)")]
        private Vector2 heightRangeSand = new Vector2(0f, 0.2f);
        [SerializeField, MinMaxSlider(0f, 1f)]
        [InspectorName("Snow Range (In Radii)")]
        private Vector2 heightRangeSnow = new Vector2(0.8f, 1f);
        [SerializeField, MinMaxSlider(0f, 90f)]
        [InspectorName("Slope Range (Degrees)")]
        private Vector2 slopeRange = new Vector2(0f, 90f);

        private void OnEnable()
        {
            if (_generation.seed == 0)
                _generation.seed = unchecked((uint)Random.Range(int.MinValue, int.MaxValue));
        }

        public override void UpdateVisual(GameObject editableGO)
        {
            var mats = PlanetAssetUtils.GetMaterialsInChildren(editableGO);

            var planet = editableGO.GetComponentInParent<Planet>();

            foreach (var mat in mats)
            {
                mat.SetColor(s_rimColor, rimColor);
                mat.SetColor(s_grassColor, grassColor);
                mat.SetColor(s_snowColor, snowColor);
                mat.SetColor(s_sandColor, sandColor);
                mat.SetColor(s_dryColor, dryColor);
                mat.SetColor(s_rockColor, rockColor);

                Color tint = PlanetAssetUtils.GetTemperatureTint(Planet, planet);
                mat.SetColor(s_tempTint, tint);

                mat.SetFloat(s_overallLevel, PlanetAssetUtils.GetOverallLevel(Planet, planet));
                mat.SetFloat(s_tempLevel, PlanetAssetUtils.GetTemperatureLevel(Planet, planet));
                mat.SetVector(s_heightRangeSand, heightRangeSand);
                mat.SetVector(s_heightRangeSnow, heightRangeSnow);
                mat.SetVector(s_slopeRange, slopeRange);
            }
        }
    }
}