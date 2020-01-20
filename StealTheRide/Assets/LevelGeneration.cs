using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> levelsToChoose;
    public GameObject connector;
    public GameObject baseLevel;
    public float levelsCount = 3;

    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        Vector3 firstPosition = new Vector3(0, 0, 0);
        Vector3 newPosition = new Vector3(11, 0, 0);
        Vector3 firstPositionConnector = new Vector3(8.341f, -0.347f, 0);
        Vector3 newPositionConnector = new Vector3(19.341f, -0.347f, 0);
        Quaternion rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        Instantiate(baseLevel, firstPosition, rotation);
        Instantiate(connector, firstPositionConnector, rotation);
        for (int i = 1; i < levelsCount; i++)
        {
            Debug.Log("wykonuję się");
            Instantiate(connector, newPositionConnector, rotation);
            newPositionConnector += new Vector3(11, 0, 0);
            Instantiate(levelsToChoose[Random.Range(0, levelsToChoose.Count)], newPosition, rotation);
            newPosition += new Vector3(11, 0, 0);
            
        }
    }
}
