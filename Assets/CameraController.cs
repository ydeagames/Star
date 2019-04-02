﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public StarController target;
    public float speedRatio = 0.1f;
    public float range = 1f;

    // Start is called before the first frame update
    private void Start()
    {

    }

    public void SetTarget(GameObject obj)
    {
        target = obj.GetComponent<StarController>();
    }

    public void SetTargetImmediately(GameObject obj)
    {
        SetTarget(obj);
        Vector2 pos;
        if (target != null && target.currentJoint != null)
        {
            pos = target.currentJoint.transform.position;
        }
        else
        {
            pos = obj.transform.position;
        }

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null && target.currentJoint != null)
        {
            if (Vector2.Distance(transform.position, target.currentJoint.transform.position) > range)
            {
                Vector2 pos = Vector2.Lerp(transform.position, target.currentJoint.transform.position, speedRatio);
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            }
            else
            {
                GameObject letter = GameObject.Find("LetterBox");
                if (letter != null)
                {
                    letter.GetComponent<Animator>().SetBool("Enabled", false);
                }

                GameObject title = GameObject.Find("StageTitle");
                if (title != null)
                {
                    title.GetComponent<Animator>().SetBool("Enabled", false);
                }
            }
        }
    }
}
