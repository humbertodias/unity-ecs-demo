using UnityEngine;

public class SpawnerRotateCube : MonoBehaviour
{
    public GameObject cube;

    void Start()
    {
        Spawn(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Spawn(pos.x, pos.y, 0);
        }
    }

    private void Spawn()
    {
        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        float z = 0;
        Spawn(x, y, z);
    }

    private void Spawn(float x, float y, float z)
    {
        GameObject instance = Instantiate(cube);

        Vector3 pos = new Vector3(x, y, z);

        instance.transform.position = pos;
    }
}