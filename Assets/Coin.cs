using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int coinPickupPoint = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(coinPickupPoint);
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
