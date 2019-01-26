using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D realTexture = null;
    [SerializeField] private Texture2D imaginaryTexture = null;

    void Start()
    {
        this.UpdateCursor(GameManager.Instance.swapper.World);
        EventManager.Instance.OnWorldChange += (World world) => {
            this.UpdateCursor(world);
        };
    }

    private void UpdateCursor(World world)
    {
        var texture = GameManager.Instance.swapper.World == World.Real ? realTexture : imaginaryTexture;
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
}
