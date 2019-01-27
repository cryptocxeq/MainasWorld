using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSwapArea : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.swapper.CantSwapReason == null)
        {
            GameManager.Instance.swapper.CantSwapReason = "We can't leave now, we're in the middle of the river!";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.swapper.CantSwapReason != null)
        {
            GameManager.Instance.swapper.CantSwapReason = null;   
        }
    }
}
