using UnityEngine;

public class Spawner_Platform : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    public float spawnCooltimeMin = 1.25f;
    public float spawnCooltimeMax = 2.25f;
    private float spawnCooltime;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private readonly float xPos = 20f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private readonly Vector2 poolPos = new Vector2(0f, -25f);
    private float lastSpawnTime;

    void Start()
    {
        platforms = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPos, Quaternion.identity);
        }
        lastSpawnTime = 0f;
        spawnCooltime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsGameover()) return;

        if (Time.time >= lastSpawnTime + spawnCooltime)
        {
            lastSpawnTime = Time.time;
            spawnCooltime = Random.Range(spawnCooltimeMin, spawnCooltimeMax);
            float yPos = Random.Range(yMin, yMax);
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector3(xPos, yPos);
            currentIndex++;
            if (currentIndex >= count) currentIndex = 0;

        }

    }
}
