using UnityEngine;

public class LandingArea : Interaction
{
    [SerializeField] private string roomName = null;
    [SerializeField] private Transform groundTarget = null;
    [SerializeField] private Transform riverTarget = null;

    protected override bool PerformAction()
    {
        var player = GameManager.Instance.player;

        if (player.IsInBoat)
        {
            player.transform.position = groundTarget.position;
            player.SetBoat(false);
            EventManager.Instance.RevealRoom(roomName);
        }
        else
        {
            player.transform.position = riverTarget.position;
            player.SetBoat(true);
        }

        return true;
    }
    
    protected override bool CanInteract()
    {
        return GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.BOX_SHIP_GO_NAME);
    }
}
