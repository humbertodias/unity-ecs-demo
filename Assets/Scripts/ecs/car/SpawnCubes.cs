using UnityEngine;

namespace ecs.car
{

    public class SpawnCubes : MonoBehaviour
    {
        public GameObject cube;

        public int rows;

        public int cols;

        // Start is called before the first frame update
        void Start()
        {
            for (int x = 0; x < rows; x++)
            {
                for (int z = 0; z < cols; z++)
                {
                    GameObject instance = Instantiate(cube);

                    float y = Mathf.PerlinNoise(x * 0.21f, z * 0.21f);
                    Vector3 pos = new Vector3(x, y, z);

                    instance.transform.position = pos;
                }
            }
        }

    }

}