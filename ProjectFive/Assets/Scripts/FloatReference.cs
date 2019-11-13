using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float constantValue;
    public FloatVariable floatVariable;

    public float Value
    {
        get { return useConstant ? constantValue : floatVariable.value; }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                floatVariable.value = value;
            }
        }
    } 
}
