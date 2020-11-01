using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnOne, spawnTwo, spawnThree, spawnFour, spawnFive;
    public Vector3 spawnVecOne, spawnVecTwo, spawnVecThree, spawnVecFour, spawnVecFive;
    public Quaternion spawnQuaOne, spawnQuaTwo, spawnQuaThree, spawnQuaFour, spawnQuaFive;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSetter();
        Spawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawning()
    {
        float spawn = Random.Range(1f, 5f);

        if (spawn == 1f)
        {
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
        }
        else if (spawn == 2f)
        {
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
        }
        else if (spawn == 3f)
        {
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaThree);
        }
        else if (spawn == 4f)
        {
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaThree);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaFour);
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
        }
        else if (spawn == 5f)
        {
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaFive);
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaThree);
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaFour);
        }
    }

    void SpawnSetter()
    {
        spawnVecOne = spawnOne.transform.position;
        spawnQuaOne = spawnOne.transform.rotation;
        spawnVecTwo = spawnTwo.transform.position;
        spawnQuaTwo = spawnTwo.transform.rotation;
        spawnVecThree = spawnThree.transform.position;
        spawnQuaThree = spawnThree.transform.rotation;
        spawnVecFour = spawnFour.transform.position;
        spawnQuaFour = spawnFour.transform.rotation;
        spawnVecFive = spawnFive.transform.position;
        spawnQuaFive = spawnFive.transform.rotation;
    }
}
