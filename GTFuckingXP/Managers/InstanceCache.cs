using System;
using System.Collections.Generic;
using UnityEngine;

namespace GTFuckingXP.Managers
{
    public class InstanceCache
    {
        private Dictionary<Type, object> _typeInstances;
        private Dictionary<object, object> _informationCache;

        public InstanceCache()
        {
            _typeInstances = new Dictionary<Type, object>();
            _informationCache = new Dictionary<object, object>();
        }

        /// <summary>
        /// Gets the single instance of <see cref="InstanceCache"/>.
        /// </summary>
        public static InstanceCache Instance { get; set; }

        /// <summary>
        /// Creates a new component of type <typeparamref name="Tscript"/> and registers it.
        /// Returns the newly created <typeparamref name="Tscript"/> after this.
        /// </summary>
        /// <typeparam name="Tscript">The component that should be created and registered</typeparam>
        public Tscript CreateRegisterAndReturnComponent<Tscript>() where Tscript : Component
        {
            if(TryGetInstance<Tscript>(out var instance))
            {
                instance.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(instance);
            }
            
            var gameObject = new GameObject("GetTheFuckingXp_Endskill");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            instance = gameObject.AddComponent<Tscript>();

            SetInstance(instance);
            return instance;
        }

        /// <summary>
        /// Kills the <typeparamref name="Tscript"/> component
        /// </summary>
        /// <typeparam name="Tscript"></typeparam>
        public void KillScript<Tscript>() where Tscript : Component
        {
            if(TryGetInstance<Tscript>(out var script))
            {
                UnityEngine.Object.Destroy(script);
                _typeInstances.Remove(typeof(Tscript));
            }
        }

        /// <summary>
        /// Adds a component of type <typeparamref name="Tscript"/> to <paramref name="parentGameobject"/> if the gameobject does not contain it yet.
        /// Returns the newly generated or already existing component of <typeparamref name="Tscript"/> in <paramref name="parentGameobject"/>.
        /// </summary>
        public Tscript AddSingleComponentToGameObjectAndRegister<Tscript>(GameObject parentGameobject) where Tscript : Component
        {
            var tscriptComponent = parentGameobject.AddComponent<Tscript>();

            SetInstance(tscriptComponent);
            return tscriptComponent;
        }

        ///// <summary>
        ///// Registers the <paramref name="instance"/> as a new instance.
        ///// </summary>
        ///// <param name="instance">The instance you want to register.</param>
        ///// <returns>If the instance was succesfully registered.</returns>
        //public bool RegisterInstance<Tinstance>(Tinstance instance, Type instanceType = null)
        //{
        //    if (instanceType is null)
        //    {
        //        instanceType = typeof(Tinstance);
        //    }

        //    if (!_typeInstances.ContainsKey(instanceType))
        //    {
        //        _typeInstances.Add(instanceType, instance);
        //        return true;
        //    }

        //    return false;
        //    //throw new Exception($"Can not add a instance of Type {instanceType} to the cache, because there is already a instance registered of this Type!");
        //}

        /// <summary>
        /// Sets <paramref name="instance"/> directly into the cache.
        /// </summary>
        public void SetInstance<Tinstance>(Tinstance instance)
        {
            _typeInstances[typeof(Tinstance)] = instance;
        }

        /// <summary>
        /// Tries to get the instance of type <typeparamref name="Tinstance"/>.
        /// Throws an Exception if the requested instance is not in the cache.
        /// </summary>
        public Tinstance GetInstance<Tinstance>()
        {
            if (_typeInstances.TryGetValue(typeof(Tinstance), out var instance))
            {
                return (Tinstance)instance;
            }

            LogManager.Error($"There was no instance with ${typeof(Tinstance)} as the Type!");
            throw new KeyNotFoundException($"There was no instance with {typeof(Tinstance)} as the Type!");
        }

        /// <summary>
        /// Tries to get the instance of type <typeparamref name="Tinstance"/> and sets <paramref name="instance"/> to the found instance if found.
        /// </summary>
        /// <param name="instance">The found instance.</param>
        /// <returns>if a instance of type <typeparamref name="Tinstance"/> exists.</returns>
        public  bool TryGetInstance<Tinstance>(out Tinstance instance)
        {
            if (_typeInstances.TryGetValue(typeof(Tinstance), out var value))
            {
                instance = (Tinstance)value;
                return true;
            }

            instance = default;
            return false;
        }

        /// <summary>
        /// Sets the Value of the entry with <paramref name="key"/> to <paramref name="info"/>.
        /// </summary>
        public  void SetInformation(object key, object info)
        {
            //This works! It creates a new entry with the key if it does not exist yet.
            _informationCache[key] = info;
        }

        /// <summary>
        /// Tries to get the information cached with the <paramref name="key"/> as Key.
        /// </summary>
        public  Tinformation GetInformation<Tinformation>(object key)
        {
            if (_informationCache.TryGetValue(key, out var info))
            {
                return (Tinformation)info;
            }

            throw new KeyNotFoundException($"There was no information with the key {key}");
        }
    }
}
