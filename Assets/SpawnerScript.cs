using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject wall;
    public Transform topSpawner;
    public Transform bottomSpawner;

    private float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnWalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerScript.startGame)
        {
            time = 0;
            return;
        }
        time += Time.deltaTime;
        if (time < 2) return;
        time = 0;
        SpawnWalls();
    }

    void SpawnWalls()
    {
        int topSize = Random.Range(2, 8);
        int downSize = Random.Range(2, 8);
        var wall1 = Instantiate(wall, topSpawner.position, Quaternion.identity);
        wall1.transform.localScale = new Vector3(1, topSize, 1);
        var wall2 = Instantiate(wall, bottomSpawner.position, Quaternion.identity);
        wall2.transform.localScale = new Vector3(1, downSize, 1);
    }
}
