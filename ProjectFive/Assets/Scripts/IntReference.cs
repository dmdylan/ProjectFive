using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class IntReference
{
    public bool useConstant = true;
    public int constantValue;
    public IntVariable intVariable;

    public int Value
    {
        get { return useConstant ? constantValue : intVariable.value; }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                intVariable.value = value;
            }
        }
    }
}
