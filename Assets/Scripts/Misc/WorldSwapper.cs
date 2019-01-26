﻿using System.Collections;
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
    private World world;
    private bool canSwap;

    public World World
    {
        get { return world; }
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
        if (!canSwap)
        {
            return;
        }

        var scaleVector = world == World.Imaginary ? MinimumScaleVector : MaximumScaleVector;
        LeanTween.scale(imaginaryMask, scaleVector, transitionDuration).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(realMask, scaleVector, transitionDuration).setEase(LeanTweenType.easeInCubic);
        world = world == World.Real ? World.Imaginary : World.Real;
        EventManager.Instance.ChangeWorld(world);
    }
}
