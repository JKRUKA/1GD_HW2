using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collected the Coin!");

            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.StopTimer();
            }

            Destroy(gameObject);
        }
    }
}
