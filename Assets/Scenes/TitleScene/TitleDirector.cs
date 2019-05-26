﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDirector : MonoBehaviour
{
    public Stage firstStage;
    public Stage selectScene;

    // Start is called before the first frame update
    void Start()
    {
        TitleEffect(true);

        CameraController.Get().Targetter.SetTarget(StarController.latestStar);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        StageSelector.Get().LoadStage(firstStage);
        TitleEffect(false);
    }

    public void SelectStage()
    {
        SceneSelector.Get().LoadScene(selectScene);
        TitleEffect(false);
    }

    public void TitleEffect(bool starting)
    {
        GetComponentInChildren<ButtonManager>().SetVisible(starting);
    }

    public static TitleDirector Get()
    {
        return GameObject.Find("GameTitle")?.GetComponent<TitleDirector>();
    }
}
