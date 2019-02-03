using Lean.Localization;

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
            string text = "I can't go further, I can't swim in the river!";
            text = LeanLocalization.GetTranslationText("bedroomLandingAreaText");
            GameManager.Instance.ui.UpdateDialog(UIManager.DialogSpeaker.MAINA, text);
            return false;
        }
    }
    
    protected override bool CanInteract()
    {
        return true;
    }
}
