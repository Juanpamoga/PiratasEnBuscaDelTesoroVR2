using System;
using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.Controllables.AngularDriver;
using UnityEngine;
using UnityEngine.Events;

public class Statue : MonoBehaviour
{
    public int id;
    public Material OnPulled;
    private Action<int> OnPulledInt;
    public AngularDriveFacade facade;
    public MeshRenderer leverRenderer;
    private bool Pulled = false;

    public void SubscribeID(int ID, Action<int> callback)
    {
        Pulled = false;
        id = ID;
        OnPulledInt = callback;
    }
    
    public void Activate()
    {
        if (Pulled)
        {
            return;
        }
        SoundManager.Instance.PlaySound("Door");
        Pulled = true;
        leverRenderer.sharedMaterial = OnPulled;
        OnPulledInt?.Invoke(id);
    }


    public void Clean()
    {
        OnPulledInt = null;
    }

    public void AssignMaterial(Material material)
    {
        leverRenderer.sharedMaterial = material;
    }

    public void ResetLevers(Material material)
    {
        if (Pulled)
        {
            leverRenderer.sharedMaterial = material;
        }

        Pulled = false;
        facade.TargetValue = 1;
        facade.MoveToTargetValue = true;
    }
}
