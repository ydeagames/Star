﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointModelController : MonoBehaviour
{
    public Material normalMaterial;
    public Material vibrantMaterial;

    public PointColor colorPalette;

    PointController point;

    bool _lightenabled;
    int _colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        point = GetComponentInParent<PointController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (point.touched != _lightenabled || point.colorIndex != _colorIndex)
        {
            var render = GetComponentInChildren<Renderer>();

            render.material = point.touched ? vibrantMaterial : normalMaterial;

            if (point.colorIndex < colorPalette.colors.Count && colorPalette.colors[point.colorIndex] != null)
            {
                render.material.color = colorPalette.colors[point.colorIndex];
            }

            render.UpdateGIMaterials();
            //DynamicGI.SetEmissive(render, (value ? vibrantMaterial : normalMaterial).GetColor("_EmissionColor"));

            _lightenabled = point.touched;
            _colorIndex = point.colorIndex;
        }
    }
}
