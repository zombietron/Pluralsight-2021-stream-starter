using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [Tooltip("Add obstacles and enemies to spawn here.")]
    [SerializeField] GameObject[] spawnables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetRandomObjectFromArray(GameObject[] arr)
    {
        int random = Random.Range(0, arr.Length);
        return arr[random];
            
    }

    public void SpawnRandomEnemy()
    {
        GameObject go = Instantiate(GetRandomObjectFromArray(spawnables));

        if(go!=null)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, go.transform.position.y, go.transform.position.z);
            go.transform.position = spawnPos; 
        }
    }

    public IEnumerator BeginSpawningEnemies()
    {
        float delayTime = 2.0f;

        while (true)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(delayTime);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(BeginSpawningEnemies());
    }
}
