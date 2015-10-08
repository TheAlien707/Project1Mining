using UnityEngine;
using System.Collections;

public class cubebehavior : MonoBehaviour {

    public OreType myType;

	// Use this for initialization
	void Start () {
	
	}
	
    void OnMouseDown()
    {
        Destroy(gameObject);
        if (myType == OreType.Bronze)
        {
            spawnCube.bronzeOnScreen--;
            spawnCube.playerPoints += spawnCube.bronzePoints;
            print(spawnCube.playerPoints);
        }
        else if (myType == OreType.Silver)
        {
            spawnCube.silverOnScreen--;
            spawnCube.playerPoints += spawnCube.silverPoints;
            print(spawnCube.playerPoints);
        }
        else if (myType == OreType.Gold)
        {
            spawnCube.goldOnScreen--;
            spawnCube.playerPoints += spawnCube.goldPoints;
            print(spawnCube.playerPoints);
        }
        else if (myType == OreType.Kryptonite)
        {
            spawnCube.kryptoOnScreen--;
            spawnCube.playerPoints += spawnCube.kryptoPoints;
            print (spawnCube.playerPoints);
        }

    }
    // Update is called once per frame
    void Update () {
	
	}
}
