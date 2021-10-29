using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int level;
    public GameObject prefab;

    void Start() {
        int height = 1;
        for(int l = 1; l < level; l++) {
            switch(l % 2) {
                case 0: // even
                    for(int z = -1; z <= 1; z++)
                        Instantiate(prefab, new Vector3(0, height, z), Quaternion.Euler(0, 0, 0));
                    break;
                case 1: // odd
                    for (int x = -1; x <= 1; x++)
                        Instantiate(prefab, new Vector3(x, height, 0), Quaternion.Euler(0, 90, 0));
                    break;
            }
            height += 3;
        }
    }

    void Update() {

    }
}
