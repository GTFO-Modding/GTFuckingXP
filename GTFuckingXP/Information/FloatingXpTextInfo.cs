using DamageNumbers.API;
using TMPro;
using UnityEngine;

namespace GTFuckingXP.Information
{
    public class FloatingXpTextInfo : IFloatingTextInfo
    {
        public FloatingXpTextInfo(Vector3 position, string text)
        {
            Velocity = new Vector3(0f, 0.1f, 0f);
            SpawnPosition = position;
            Text = text;
        }

        public Vector3 Velocity { get; }

        public Vector3 SpawnPosition { get; }

        public float Gravity => 0f;

        public float LifeTime => 2f;

        public string Text { get; }

        public void OnUpdate(TextMeshPro tmp, FloatingTextBase textBase)
        {
        }

        public void UpdateTextMesh(TextMeshPro tmp)
        {
        }
    }
}
