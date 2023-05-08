using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExtensionMethods 
{
  
    /// <summary>
    /// Get interactable object in scene by passing an ID.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static IInteractableObject GetInteractableObject(this MonoBehaviour[] data, int id)
    {
       return  data.OfType<IInteractableObject>().Where(x => x.Id == id)
                                                 .FirstOrDefault();  
    }
}
