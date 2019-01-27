using UnityEngine;

public class NoSwapArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.swapper.CantSwapReason == null)
        {
            GameManager.Instance.swapper.CantSwapReason = "We can't leave now, we're in the middle of the river!";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.swapper.CantSwapReason != null)
        {
            GameManager.Instance.swapper.CantSwapReason = null;   
        }
    }
}
