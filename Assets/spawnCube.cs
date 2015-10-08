using UnityEngine;
using System.Collections;

public class spawnCube : MonoBehaviour {
    public GameObject bronzeOre;
    public GameObject silverOre;
    public GameObject goldOre;
    public GameObject kryptoniteOre;
    float spawnFreq = 3f;
    // inital spawn should be almost immediate
    float timeToSpawn = 1f;
    //variables to keep track of how many of which ore are on screen
    bool spawnedOnce = false;
    //only spawn one variable per timeToSpawn
    public static int bronzeOnScreen = 0;
    public static int silverOnScreen = 0;
    public static int goldOnScreen = 0;
    public static int kryptoOnScreen = 0;
    //krypto counts as gold as wildcard
    public static int kryptoANDgoldOnScreen = 0;

    private bool recentGoldOre = false;
 

    public static int bronzePoints = 1;
    public static int silverPoints = 10;
    public static int goldPoints = 100;
    public static int kryptoPoints = 1000;

    public static int playerPoints = 0;

    // Use this for initialization
    void Start () {
	}

	//spawn bronze method
    void spawnBronze()
    {
        Vector3 cubePosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0.0f);
        Instantiate(bronzeOre, cubePosition, Quaternion.identity);
        bronzeOnScreen++;
        recentGoldOre = false;
        spawnedOnce = true;
    }

    //spawn silver method
    void spawnSilver()
    {
        Vector3 cubePosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0.0f);
        Instantiate(silverOre, cubePosition, Quaternion.identity);
        silverOnScreen++;
        recentGoldOre = false;
        spawnedOnce = true;
    }
    //spawn gold method
    void spawnGold()
    {
        Vector3 cubePosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0.0f);
        Instantiate(goldOre, cubePosition, Quaternion.identity);
        goldOnScreen++;
        kryptoANDgoldOnScreen = goldOnScreen + kryptoOnScreen;
        recentGoldOre = true;
        spawnedOnce = true;
    }
    //spawn kryptonite method
    void spawnKrypto()
    {
        Vector3 cubePosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0.0f);
        Instantiate(kryptoniteOre, cubePosition, Quaternion.identity);
        kryptoOnScreen++;
        kryptoANDgoldOnScreen = goldOnScreen + kryptoOnScreen;
        recentGoldOre = false;
        spawnedOnce = true;
    }
	
    // Update is called once per frame
	void Update ()
    {
        //actually spawn the ores
        if (spawnedOnce == false)
        {

            if (kryptoOnScreen < 2 && silverOnScreen >0 && goldOnScreen >0 && (silverOnScreen == goldOnScreen || silverOnScreen == kryptoANDgoldOnScreen))
                //silver&gold needs to be >= 1 because initial game has 0 of both
                //making krypto spawns with bronze, simaultaneously
                // silver == gold can be true and silver == gold&krytpo can be true but not both
            {
                spawnKrypto();
            }
            else if (bronzeOnScreen == 2 && silverOnScreen == 2 && recentGoldOre == false)
            {
                spawnGold();
            }
            else if (bronzeOnScreen < 4)
           {
                //bronze tends to spawn with krypto
                spawnBronze();
           }
           else if (bronzeOnScreen >= 4)
           {
                // make silver ores
                spawnSilver();
           }

           timeToSpawn += spawnFreq;
        }
        //determine when it's time to spawn an ore
        if (Time.time >= timeToSpawn)
        {
            spawnedOnce = false;
        }
    }
}
