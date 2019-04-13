using ecs.car.components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace ecs.car
{

    public class SpawnerSystem : JobComponentSystem
    {

        private EndSimulationEntityCommandBufferSystem m_EntityCommandBufferSystem;

        protected override void OnCreateManager()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        struct SpawnJob : IJobForEachWithEntity<Spawner, LocalToWorld>
        {
            public EntityCommandBuffer commandBuffer;

            public void Execute(Entity entity, int index, [ReadOnly] ref Spawner spawner,
                [ReadOnly] ref LocalToWorld location)
            {
                for (int x = 0; x < spawner.Erows; x++)
                {
                    for (int z = 0; z < spawner.Ecols; z++)
                    {
                        var instance = commandBuffer.Instantiate(spawner.Prefab);
                        var pos = math.transform(location.Value,
                            new float3(x, noise.cnoise(new float2(x, z) * 0.21f), z));

                        commandBuffer.SetComponent(instance, new Translation {Value = pos});
                    }
                }

                commandBuffer.DestroyEntity(entity);
            }

        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new SpawnJob
            {
                commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer()
            }.ScheduleSingle(this, inputDeps);

            m_EntityCommandBufferSystem.AddJobHandleForProducer(job);
            return job;
        }

    }


}