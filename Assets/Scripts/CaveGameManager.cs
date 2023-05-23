using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CaveGameManager : MonoBehaviour
{
    public List<Statue> Statues;
    public List<int> puzzle;
    private List<int> pressedLevers;

    public bool levelComplete = false;
    private int currentlevers;
    public int maxLever;

    public GameObject portal;
    public Material leverRight, leverWrong;
    void Start()
    {
        pressedLevers = new List<int>();
        for (int i = 0; i < Statues.Count; i++)
        {
            Statues[i].SubscribeID(i, LeverPulled);
        }

        levelComplete = false;
    }
    
    public void LeverPulled(int value)
    {
        if (levelComplete)
        {
            return;
        }
        pressedLevers.Add(value);
        currentlevers++;
        
        if (currentlevers >= maxLever)
        {
            bool valid = true;

            foreach (int i in pressedLevers)
            {
                if (!puzzle.Contains(i))
                {
                    valid = false;
                }
            }

            if (valid)
            {
                foreach (Statue statue in Statues)
                {
                    statue.AssignMaterial(leverRight);
                }
                portal.SetActive(true);
                levelComplete = true;
            }
            else
            {
                foreach (Statue statue in Statues)
                {
                    statue.ResetLevers(leverWrong);
                }
                pressedLevers.Clear();
                currentlevers = 0;
            }
        }
    }

    
    private void OnDestroy()
    {
        foreach (Statue statue in Statues)
        {
            statue.Clean();
        }
    }
}