using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    Vector3 spawnVecOne, spawnVecTwo, spawnVecThree, spawnVecFour, spawnVecFive;
    Quaternion spawnQuaOne, spawnQuaTwo, spawnQuaThree, spawnQuaFour, spawnQuaFive;

    public float spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnVecOne = new Vector3 (-100, 3, 0);
        spawnVecTwo = new Vector3(-100, 3.5f, -8);
        spawnVecThree = new Vector3(-90.5f, 2, 0);
        spawnVecFour = new Vector3(-100, 2, 13);
        spawnVecFive = new Vector3(-115, 1.5f, 0);

        spawnQuaOne = new Quaternion(0,0,0,0);
        spawnQuaTwo = new Quaternion(0, 0, 0, 0);
        spawnQuaThree = new Quaternion(0, 0, 0, 0);
        spawnQuaFour = new Quaternion(0, 0, 0, 0);
        spawnQuaFive = new Quaternion(0, 0, 0, 0);

        Spawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawning()
    {
        spawn = Mathf.RoundToInt(Random.Range(1f, 5f));

        if (spawn == 1f)
        {
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            Debug.Log("One Spawn");
        }
        else if (spawn == 2f)
        {
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            Debug.Log("Two Spawn");
        }
        else if (spawn == 3f)
        {
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaThree);
            Debug.Log("Three Spawn");
        }
        else if (spawn == 4f)
        {
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaThree);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaFour);
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Debug.Log("Four Spawn");
        }
        else if (spawn == 5f)
        {
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaFive);
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaTwo);
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaThree);
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaFour);
            Debug.Log("Five Spawn");
        }
    }

    
}
