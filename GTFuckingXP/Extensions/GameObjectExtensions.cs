using UnityEngine;

namespace GTFuckingXP.Extensions
{
    /// <summary>
    /// Contains some useful extension methods to have an easier workflow with <see cref="GameObject"/>.
    /// </summary>
    internal static class GameObjectExtensions
    {
        public static T Instantiate<T>(this GameObject gameObject, string name) where T : Component
        {
            var newGameObject = GameObject.Instantiate(gameObject, gameObject.transform.parent, false);
            newGameObject.name = name;
            T component = newGameObject.GetComponent<T>();
            return component;
        }
    }
}
