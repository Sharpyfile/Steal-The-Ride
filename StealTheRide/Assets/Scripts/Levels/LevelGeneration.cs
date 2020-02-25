using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> levelsToChoose;
    public GameObject baseLevel;
    public GameObject BossLevelPartOne;
    public GameObject BossLevelPartTwo;
    public float levelsCount = 3;
    private bool levelHasEnded = false;
    private float timeDelay;
    public float endLevelTime = 3.0f;

    void Start()
    {
        GenerateLevel();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1 && !levelHasEnded)
        {
            Debug.Log("Level has ended");
            levelHasEnded = true;
            timeDelay = Time.time + endLevelTime;
            Debug.Log(timeDelay);
            
        }
        if (levelHasEnded)
            Debug.Log(Time.deltaTime);
        if (levelHasEnded && Time.time >= timeDelay)
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }

    private void GenerateLevel()
    {
        Vector3 firstPosition = new Vector3(0, 0, 0);
        Vector3 newPosition = new Vector3(8, 0, 0);
        Quaternion rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        Instantiate(baseLevel, firstPosition, rotation);
        for (int i = 1; i < levelsCount; i++)
        {
            Instantiate(levelsToChoose[Random.Range(0, levelsToChoose.Count)], newPosition, rotation);
            newPosition += new Vector3(8, 0, 0);            
        }
        Instantiate(BossLevelPartOne, newPosition, rotation);
        newPosition += new Vector3(8, 0, 0);
        Instantiate(BossLevelPartTwo, newPosition, rotation);
        newPosition += new Vector3(8, 0, 0);
    }


}
