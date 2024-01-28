using System;
using UnityEngine;

namespace Audio
{
    [Serializable]
    public class Track
    {
        public AudioClip clip;
        public int weight = 1;
    }
}
