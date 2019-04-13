using System;
using Unity.Entities;

// Serializable attribute is for editor support.
namespace ecs.cube
{
    [Serializable]
    public struct RotationSpeed : IComponentData
    {
        public float radiansPerSecond;
    }
}
