﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

// This system updates all entities in the scene with both a RotationSpeed and Rotation component.
namespace ecs.cube
{
    public class RotationSpeedSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            // Entities.ForEach processes each set of ComponentData on the main thread. This is not the recommended
            // method for best performance. However, we start with it here to demonstrate the clearer separation
            // between ComponentSystem Update (logic) and ComponentData (data).
            // There is no update logic on the individual ComponentData.
            Entities.ForEach((ref RotationSpeed rotationSpeed, ref Rotation rotation) =>
            {
                var deltaTime = Time.deltaTime;
                rotation.Value = math.mul(math.normalize(rotation.Value),
                    quaternion.AxisAngle(math.up(), rotationSpeed.radiansPerSecond * deltaTime));
            });
        }
    }
}
