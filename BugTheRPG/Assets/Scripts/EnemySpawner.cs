using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab, enemyTypeOne, enemyTypeTwo, enemyTypeThree, enemyTypeFour, enemyTypeFive;
    Vector3 spawnVecOne, spawnVecTwo, spawnVecThree, spawnVecFour, spawnVecFive;
    Quaternion spawnQuaOne;

    public float spawn;

    // Start is called before the first frame update
    void Start()
    {

        spawnVecOne = new Vector3(Random.Range(72, 675), 100, Random.Range(300, 785));
        spawnVecTwo = new Vector3(Random.Range(72, 675), 100, Random.Range(300, 785));
        spawnVecThree = new Vector3(Random.Range(72, 675), 100, Random.Range(300, 785));
        spawnVecFour = new Vector3(Random.Range(72, 675), 100, Random.Range(300, 785));
        spawnVecFive = new Vector3(Random.Range(72, 675), 100, Random.Range(300, 785));

        spawnQuaOne = new Quaternion(0,0,0,0);

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
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Debug.Log("One Spawn");
        }
        else if (spawn == 2f)
        {
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Debug.Log("Two Spawn");
        }
        else if (spawn == 3f)
        {
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Debug.Log("Three Spawn");
        }
        else if (spawn == 4f)
        {
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Debug.Log("Four Spawn");
        }
        else if (spawn == 5f)
        {
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);

            spawnVecOne = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecTwo = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecThree = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFour = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));
            spawnVecFive = new Vector3(Random.Range(206, 622), 101, Random.Range(206, 1027));

            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecOne, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecTwo, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecThree, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFour, spawnQuaOne);
            PrefabRandomiser();
            Instantiate(enemyPrefab, spawnVecFive, spawnQuaOne);
            Debug.Log("Five Spawn");
        }
    }

    void PrefabRandomiser()
    {
        int randy = Mathf.RoundToInt(Random.Range(1f, 5f));
        if(randy == 1f)
        {
            enemyPrefab = enemyTypeOne;
        }
        if (randy == 1f)
        {
            enemyPrefab = enemyTypeTwo;
        }
        if (randy == 1f)
        {
            enemyPrefab = enemyTypeThree;
        }
        if (randy == 1f)
        {
            enemyPrefab = enemyTypeFour;
        }
        if (randy == 1f)
        {
            enemyPrefab = enemyTypeFive;
        }
    }
}
