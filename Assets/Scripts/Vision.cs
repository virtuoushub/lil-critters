﻿using UnityEngine;

public class Vision : MonoBehaviour 
{
    private CritterBrain brain;
    private bool seesSomething;

    private void Start()
    {
        brain = transform.parent.GetComponent<CritterBrain>();
        seesSomething = false;
    }

    private void Update()
    {
        if(seesSomething)
        {
            return;
        }

        Debug.Log("No sensory stimulous coming from vision."); // Temporary
        brain.ViewedNothing();
    }

    private void OnTriggerEnter()
    {
        seesSomething = true;
    }

    private void OnTriggerStay(Collider other) 
    {
        LogTrigger(other);
        brain.ViewedColor();
    }

    private void OnTriggerExit()
    {
        // BUG: This isn't called when the trigger is Destroyed. Need workaround.
        seesSomething = false;
    }

    private void LogTrigger(Collider other)
    {
        OrganismColors otherColor = other.GetComponent<OrganismColor>().color;
        Debug.Log("Triggered by something that is the color " + otherColor.ToString()); // Temporary
    }
}
