using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Cloth
{
    public enum ClothType
    {
        SPEED,
        STRONG,
        HEALTH,
        NONE
    }

    public class ClothManager : Singleton<ClothManager>
    {
        public List<ClothSetup> clothSetups;

        public ClothSetup GetSetupByType(ClothType clothType)
        {
            if (clothType != ClothType.NONE)
            {
                return clothSetups.Find(i => i.clothType == clothType);
            }
            else
            {
                return null;
            }
        }
    }

    [System.Serializable]
    public class ClothSetup
    {
        public ClothType clothType;
        public Texture2D texture;
    }
}