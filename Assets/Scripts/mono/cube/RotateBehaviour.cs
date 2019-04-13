using Unity.Mathematics;
using UnityEngine;

namespace mono.cube
{

    public class RotateBehaviour : MonoBehaviour
    {
        // Data
        [SerializeField] public float degreesPerSecond;

        void Update()
        {
            // Behaviour - Provides functionality to the GameObject
            // Uses Data
            var radiansPerSecond = math.radians(degreesPerSecond);
            var rotation = math.mul(math.normalize(this.transform.rotation),
                quaternion.AxisAngle(math.up(), radiansPerSecond * Time.deltaTime));
            transform.rotation = rotation;
        }

    }
}