// Unity3D C# script that defined MyButton class
// inherited from Button class
// Author: Juha Liias

// Known issues:
// This is not yet perfect solution for checking
// the state of UI buttons continuously:
// Current implementation is not able to correctly detect 
// situations where player drags finger from one button to
// another -> need to be corrected ASAP

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyButton : Button
{
    public void Update()
    {
        // If button is kept pressed in this frame
        if (IsPressed())
        {
            onClick.Invoke();
        }
    }

}