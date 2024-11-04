using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Interactable
{

    bool HasInteracted { get; set; }

    public void Interact();
}
