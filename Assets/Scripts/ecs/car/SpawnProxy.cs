using System.Collections.Generic;
using ecs.car.components;
using Unity.Entities;
using UnityEngine;

namespace ecs.car
{

    public class SpawnProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
    {

        public GameObject cube;
        public int rows;
        public int cols;

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(cube);
        }

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var spawnerData = new Spawner
            {
                Prefab = conversionSystem.GetPrimaryEntity(cube),
                Erows = rows,
                Ecols = cols
            };
            dstManager.AddComponentData(entity, spawnerData);
        }
    }

}