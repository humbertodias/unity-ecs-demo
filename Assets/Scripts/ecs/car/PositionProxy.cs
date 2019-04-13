using ecs.car.components;
using Unity.Entities;
using UnityEngine;

namespace ecs.car
{
    [RequiresEntityConversion]
    public class PositionProxy : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var data = new PerlinPosition { };
            dstManager.AddComponentData(entity, data);
        }
    }

}