﻿using System;

namespace Syrinj.Attributes
{
    public class GetComponentAttribute : UnityInjectorAttribute
    {
        public Type ComponentType { get; private set; }

        public GetComponentAttribute()
        {
        
        }

        public GetComponentAttribute(Type componentType)
        {
            ComponentType = componentType;
        }
    }
}