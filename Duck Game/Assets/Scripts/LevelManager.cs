using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float timeUntilRespawn; // A halál és újraéledés közötti kis idő
    public PlayerController player;

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

        yield return new WaitForSeconds(timeUntilRespawn);

        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);


    }

}
