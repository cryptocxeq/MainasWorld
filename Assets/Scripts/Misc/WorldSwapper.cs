using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum World
{
    Real, Imaginary
}

public class WorldSwapper : MonoBehaviour
{
    [SerializeField] private GameObject realMask = null;
    [SerializeField] private GameObject imaginaryMask = null;
    [SerializeField] private float transitionDuration = 1f;
    [SerializeField] private float minimumScale = 0.01f;
    [SerializeField] private float maximumScale = 20.0f;
    private Vector3 MinimumScaleVector => new Vector3(minimumScale, minimumScale, minimumScale);
    private Vector3 MaximumScaleVector => new Vector3(maximumScale, maximumScale, maximumScale);

    public World World { get; private set; }
    public string CantSwapReason { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        CantSwapReason = null;
        realMask.transform.localScale = MinimumScaleVector;
        imaginaryMask.transform.localScale = MinimumScaleVector;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeWorld();
        }
#endif
    }

    public void ChangeWorld()
    {
        if (CantSwapReason == null)
        {
            return;
        }

        var scaleVector = World == World.Imaginary ? MinimumScaleVector : MaximumScaleVector;
        LeanTween.scale(imaginaryMask, scaleVector, transitionDuration).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(realMask, scaleVector, transitionDuration).setEase(LeanTweenType.easeInCubic);
        World = World == World.Real ? World.Imaginary : World.Real;
        EventManager.Instance.ChangeWorld(World);
    }
}
