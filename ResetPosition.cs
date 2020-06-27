﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    RectTransform[] oldChildrenPauseMenuPos, newChildrenPauseMenuPos;
    Vector3[] oldPauseMenuPos, oldPauseMenuScale;

    private void OnEnable()
    {
        oldChildrenPauseMenuPos = GetComponentsInChildren<RectTransform>();
        newChildrenPauseMenuPos = GetComponentsInChildren<RectTransform>();
        oldPos();
    }

    private void OnDisable()
    {
        newPos();
    }

    private void oldPos()
    {
        for (int a = 0; a <= oldChildrenPauseMenuPos.Length; a++)
        {
            oldPauseMenuPos = new Vector3[a];
            oldPauseMenuScale = new Vector3[a];
        }
        for (int a = 0; a < oldChildrenPauseMenuPos.Length; a++)
        {
            oldPauseMenuPos[a] = new Vector3(oldChildrenPauseMenuPos[a].localPosition.x, oldChildrenPauseMenuPos[a].localPosition.y, oldChildrenPauseMenuPos[a].localPosition.z);
            oldPauseMenuScale[a] = new Vector3(oldChildrenPauseMenuPos[a].localScale.x, oldChildrenPauseMenuPos[a].localScale.y, oldChildrenPauseMenuPos[a].localScale.z);
        }
    }

    private void newPos()
    {
        for (int a = 0; a < newChildrenPauseMenuPos.Length; a++)
        {
            newChildrenPauseMenuPos[a].localPosition = new Vector3(oldPauseMenuPos[a].x, oldPauseMenuPos[a].y, oldPauseMenuPos[a].z);
            newChildrenPauseMenuPos[a].localScale = new Vector3(oldPauseMenuScale[a].x, oldPauseMenuScale[a].y, oldPauseMenuScale[a].z);
        }
    }
}
