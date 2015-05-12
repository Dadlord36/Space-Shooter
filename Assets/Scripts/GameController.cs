using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    
    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazerdCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    


    //public GUIText scoreText;
    //private int score;

    void Start()
    {
       StartCoroutine (SpawnWaves());
    }

     
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazerdCount ; i++   )
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
   }

    //public void AddScore (int newScoreValue)
    //{
    //    score += newScoreValue;
    //    UpdateScore();
    //}
    //void UpdateScore()
    //{
    //    scoreText.text  = "Score: " + score;
    //}
}
