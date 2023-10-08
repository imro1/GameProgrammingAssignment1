using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject particleSystem;
    public float respawnTime = 30f; 
    private bool isRespawning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isRespawning && other != null)
        { 
            CollectPowerUp();
        }
    }

    private void CollectPowerUp()
    {
        gameObject.SetActive(false);
        GameManager.Instance.PowerUpOn();
        GameManager.Instance.IncrementNbOfPu();
        GameObject particleSystemBurst = Instantiate(particleSystem, transform.position, transform.rotation);
        Destroy(particleSystemBurst, 5);

        
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);

        gameObject.SetActive(true);
    }
}
