using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float timeUntilRespawn; // A halál és újraéledés közötti kis idő
    public PlayerController player;

    public GameObject AnimOnDeath;

    public int coinCount;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);

        Instantiate(AnimOnDeath, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(timeUntilRespawn);

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);


    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
    }

}
