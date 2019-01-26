using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D realTexture;
    [SerializeField] private Texture2D imaginaryTexture;

    void Start()
    {
        this.UpdateCursor(GameManager.Instance.swaper.World);
        EventManager.Instance.OnWorldChange += (World world) => {
            this.UpdateCursor(world);
        };
    }

    private void UpdateCursor(World world)
    {
        var texture = GameManager.Instance.swaper.World == World.Real ? realTexture : imaginaryTexture;
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
}
