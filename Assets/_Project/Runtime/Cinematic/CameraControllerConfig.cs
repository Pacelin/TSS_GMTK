﻿using UnityEngine;

namespace Runtime.Cinematic
{
    [System.Serializable]
    public class CameraControllerConfig
    {
        public float MinDistance => _minDistance;
        public float InitialDistance => _initialDistance;
        public float MaxDistance => _maxDistance;
        public float ZoomStep => _zoomStep;
        public float ZoomSpeed => _zoomSpeed;
        public float RotateSensitivity => _rotateSensitivity;
        
        [SerializeField] private float _minDistance = 0.5f;
        [SerializeField] private float _initialDistance = 1f;
        [SerializeField] private float _maxDistance = 2f;
        [SerializeField] private float _zoomStep = 0.1f;
        [SerializeField] private float _zoomSpeed = 0.1f;
        [SerializeField] private float _rotateSensitivity = 30f;
    }
}