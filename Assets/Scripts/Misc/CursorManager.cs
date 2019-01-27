using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D realTexture = null;
    [SerializeField] private Texture2D realTextureOver = null;
    [SerializeField] private Texture2D imaginaryTexture = null;
    [SerializeField] private Texture2D imaginaryTextureOver = null;

    World currentWorld;
    bool currentOver;

    void Start()
    {
        this.UpdateCursor(GameManager.Instance.swapper.World);
        EventManager.Instance.OnWorldChange += (World world) => {
            this.UpdateCursor(world);
        };

        EventManager.Instance.OnHighlightChange += (bool value) => {
            this.UpdateCursor(value);
        };
    }

    private void UpdateCursor(World world)
    {
        currentWorld = world;
        UpdateCursor(currentWorld, currentOver);
    }

    private void UpdateCursor(bool over)
    {
        currentOver = over;
        UpdateCursor(currentWorld, currentOver);
    }

    private void UpdateCursor(World world, bool over)
    {

        var texture = GameManager.Instance.swapper.World == World.Real ? (over ? realTextureOver : realTexture) : (over ? imaginaryTextureOver : imaginaryTexture);
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }

}
