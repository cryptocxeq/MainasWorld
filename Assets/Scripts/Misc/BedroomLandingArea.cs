public class BedroomLandingArea : LandingArea
{
    protected override bool PerformAction()
    {
        if (GameManager.Instance.inventory.InventoryObjectOwned(InventoryManager.BOX_SHIP_GO_NAME))
        {
            return base.PerformAction();
        }
        else
        {
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, 
                "I can't go further, I can't swim in the river!");
            return false;
        }
    }
    
    protected override bool CanInteract()
    {
        return true;
    }
}
