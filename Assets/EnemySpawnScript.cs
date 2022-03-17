using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
	public GameObject enemy;
	public float ENEMY_SPEED = 20f;

    	void Start() {
		StartCoroutine(EnemySpawner());
	}

	IEnumerator EnemySpawner() {
		while(true) {
			GameObject enemyInstance = Instantiate(enemy, transform.position, Quaternion.identity);
			Rigidbody2D enemyRb = enemyInstance.GetComponent<Rigidbody2D>();
			enemyRb.AddForce(Vector3.left * ENEMY_SPEED);
			float spawnTime = Random.Range(1.2f, 3f);
			Debug.Log(spawnTime);
			yield return new WaitForSeconds(1.2f);
		}
	}
}
