using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwaper : MonoBehaviour
{
    [SerializeField] private GameObject imaginaryMask;
    [SerializeField] private float transitionDuration = 1f;
    [SerializeField] private float minimumScale = 0.01f;
    [SerializeField] private float maximumScale = 20.0f;
    private bool isImaginaryWorld;
    private bool canSwap;

    public bool IsImaginaryWorld
    {
        get { return isImaginaryWorld; }
    }

    private Vector3 MinimumScaleVector
    {
        get { return new Vector3(minimumScale, minimumScale, minimumScale); }
    }

    private Vector3 MaximumScaleVector
    {
        get { return new Vector3(maximumScale, maximumScale, maximumScale); }
    }

    public bool CanSwap
    {
        get { return canSwap; }
        set { canSwap = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        canSwap = true;
        imaginaryMask.transform.localScale = MinimumScaleVector;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeWorld();
        }
    }

    public void ChangeWorld()
    {
        if (!canSwap)
            return;

        var scaleVector = isImaginaryWorld ? MinimumScaleVector : MaximumScaleVector;
        LeanTween.scale(imaginaryMask, scaleVector, transitionDuration).setEase(LeanTweenType.easeInBack);
        isImaginaryWorld = !isImaginaryWorld;
    }
}
