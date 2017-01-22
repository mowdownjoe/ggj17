using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject[] hazardTypes;
    public Vector3 spawnOffset;
    public int hazardCount;
    public float maxHeight = 4.0f;
    public float spawnWait, startWait, waveWait;
    public float minWaveWait = 1f;
    public int scoreScale = 5;
    private int score;
    public Text ScoreText;
    
    // Use this for initialization
	void Start ()
	{
	    StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
	    if (!player.activeSelf)
	    {
            //Debug.Log("Test");
            if (Input.GetKeyDown(KeyCode.R))
	        {
	            SceneManager.LoadScene(1);
	        }
	        else if (Input.GetKeyDown(KeyCode.Q))
	        {
	            Application.Quit();
	        }
	    }
	    else
	    {
	        score += scoreScale;
	        ScoreText.text = "Score:\n" + score;
	    }
	}

    IEnumerator SpawnWaves()
    {
        Camera mainCamera = Camera.main;
        Vector3 spawnPos;
        int randomInt;
        yield return new WaitForSeconds(startWait);
        while (player.activeSelf)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                randomInt = Random.Range(0, hazardTypes.Length);
                spawnPos = new Vector3(mainCamera.transform.position.x + spawnOffset.x, Random.Range(-maxHeight, maxHeight), spawnOffset.z);
                Instantiate(hazardTypes[randomInt], spawnPos, hazardTypes[randomInt].transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            ++hazardCount;
            if (hazardCount > 15)
            {
                waveWait = Mathf.Clamp(waveWait - .1f, minWaveWait, 2f);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
