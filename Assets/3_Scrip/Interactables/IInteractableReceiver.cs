using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableReceiver
{
    public int Id { get; }
    public void DoAction();

    public void FindInteractableSender();
}
