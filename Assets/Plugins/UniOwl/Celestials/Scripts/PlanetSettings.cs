using UnityEngine;
using Random = UnityEngine.Random;

namespace UniOwl.Celestials
{
    [CreateAssetMenu(menuName = "Game/Celestials/Planet Settings", fileName = "SO_Planet")]
    public class PlanetSettings : ScriptableObject
    {
        [SerializeField]
        private Planet _planet;

        [SerializeField]
        private ModelSettings _model;
        [SerializeField]
        private TextureSettings _textures;
        [SerializeField]
        private PhysicalSettings _physical;
        [SerializeField]
        private TerrainGeneratorSettings _generation;
        [SerializeField]
        private AppearanceSettings _appearance;
        
        [SerializeField]
        public Color GrassColor, RockColor;

        public ModelSettings Model => _model;
        public TextureSettings Textures => _textures;
        public PhysicalSettings Physical => _physical;
        public TerrainGeneratorSettings Generation => _generation;
        public AppearanceSettings Appearance => _appearance;

        [Range(0f, 1f)]
        public float tempLevel, seaLevel, atmosphereLevel, overallLevel;
        
        public Planet Planet
        {
            get => _planet;
            set => _planet = value;
        }

        private void OnEnable()
        {
            if (_generation.seed == 0)
                _generation.seed = Random.Range(int.MinValue, int.MaxValue);
        }
    }
}
