using Unity.Entities;

namespace ecs.car.components
{

    public struct Spawner : IComponentData
    {
        public Entity Prefab;
        public int Erows;
        public int Ecols;
    }

}