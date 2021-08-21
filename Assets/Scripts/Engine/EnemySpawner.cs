using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public Button button;


    private void Update()
    {
        //button.onClick.AddListener(SpawnEnemy);
    }


    public void SpawnEnemy()
    {
        Debug.Log("Spawned Enemy");
    }
}