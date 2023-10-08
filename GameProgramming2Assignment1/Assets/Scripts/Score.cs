using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject particleSystemPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            GameManager.Instance.IncrementScore();
            gameObject.SetActive(false);

            if (particleSystemPrefab != null)
            {
                GameObject particleSystemBurst = Instantiate(particleSystemPrefab, transform.position, transform.rotation);
                Destroy(particleSystemBurst, 5);
            }
        }
    }
}
