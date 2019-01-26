using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSwapArea : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            GameManager.Instance.swaper.CanSwap = GameManager.Instance.player.IsInBoat();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            GameManager.Instance.swaper.CanSwap = true;
    }
}
