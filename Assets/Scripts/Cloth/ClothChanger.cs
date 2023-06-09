using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMesh;

        public Texture2D texture;
        public string shaderIDName = "_EmissionMap";

        private Texture2D _defaultTexture;

        private void Awake()
        {
            _defaultTexture = (Texture2D) skinnedMesh.materials[0].GetTexture(shaderIDName);
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            skinnedMesh.materials[0].SetTexture(shaderIDName, texture);
        }

        public void ChangeTexture(ClothSetup setup)
        {
            skinnedMesh.materials[0].SetTexture(shaderIDName, setup.texture);
        }

        public void ResetTexture()
        {
            skinnedMesh.materials[0].SetTexture(shaderIDName, _defaultTexture);
        }
    }
}