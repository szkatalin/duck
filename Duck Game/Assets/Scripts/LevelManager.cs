using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float timeUntilRespawn; // A halál és újraéledés közötti kis idő
    public PlayerController player;

    public GameObject AnimOnDeath;

    public int coinCount;

    public Text coinsText;

    public int actualHealth;
    public int maxHealth;


    private bool respawning;

    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        coinsText.text = "Coins: " + coinCount;

        actualHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actualHealth <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
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

        actualHealth = maxHealth;
        respawning = false;
        UpdateHealthMeter();
        player.transform.position = player.respawnPosition;
        player.gameObject.SetActive(true);


    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinsText.text = "Coins: " + coinCount;
    }

    public void HurtPlayer(int dmg)
    {
        actualHealth -= dmg;
        UpdateHealthMeter();
    }

    public void UpdateHealthMeter()
    {
        switch (actualHealth)
        {
            case 5:
                return;
            case 4:
                return;
            case 3:
                return;
            case 2:
                return;
            case 1:
                return;
            case 0:
                return;
            default:
                return;
        }
    }
}
