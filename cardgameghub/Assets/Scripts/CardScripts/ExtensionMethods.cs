using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace RichardQ{
    // extension methods
    public static class ExtensionMethods 
    {
        // return a float changed slightly
        public static float jiggle(this float x)
        {
            return x * UnityEngine.Random.Range(0.9f, 1.1f);
        }
       
    }
}


