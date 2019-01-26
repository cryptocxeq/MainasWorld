using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHandler
{
    public static GameObject MouseOnUI()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = Input.mousePosition;
        List<RaycastResult> hitsUI = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, hitsUI);
        foreach (RaycastResult r in hitsUI)
        {
            if (r.gameObject.layer == 5)
                return r.gameObject;
        }
        return null;
    }
}
