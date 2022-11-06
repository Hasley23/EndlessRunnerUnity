using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // определение переменных
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject[] roads;
    private List<GameObject> curRoads = new List<GameObject>();
    private float spawnPos = 0;
    [SerializeField]
    private float roadLength;
    [SerializeField] private Transform player;
    [SerializeField] private int startRoads = 3;

    // Start is called before the first frame update
    void Start()
    {
        // начальная генерация карты и последующее добавление тайлов карты
        bool isFirstPrefab = true;
        for (int i = 0; i < startRoads; i++)
        {
            if (isFirstPrefab) {
                SpawnRoad(0);
                SpawnRoad(0);
                isFirstPrefab =! isFirstPrefab;
            } else {
                SpawnRoad(Random.Range(0, roads.Length));
            }
            
        }
    }

    // генерация в зависимости от приближения игрока и удаление тайла после прохождения
    void Update()
    {
        if (player.position.z - (roadLength / 2 + 10) > spawnPos - (roadLength * startRoads))
        {
            // следующий тайл дороги генерируется случайно
            SpawnRoad(Random.Range(0, roads.Length));
            GarbageCollector();
        }
    }

    // генерация сдедующей части дороги
    private void SpawnRoad(int roadIndex)
    {
        GameObject nextRoad = Instantiate(roads[roadIndex], transform.forward * spawnPos, transform.rotation);
        curRoads.Add(nextRoad);
        spawnPos += roadLength;
    }

    // сборщик мусора (уже пройденных тайлов)
    private void GarbageCollector()
    {
        Destroy(curRoads[0]);
        curRoads.RemoveAt(0);
    }
}
