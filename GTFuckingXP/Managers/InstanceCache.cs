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
        public Tscript DestroyOldCreateRegisterAndReturnComponent<Tscript>() where Tscript : Component
        {
            if(TryGetInstance<Tscript>(out var instance))
            {
                instance.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(instance);
                _typeInstances.Remove(typeof(Tscript));
            }
            
            var gameObject = new GameObject("GetTheFuckingXp_Endskill");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            instance = gameObject.AddComponent<Tscript>();

            SetInstance(instance);
            return instance;
        }

        /// <summary>
        /// Create a new component of type <typeparamref name="Tscript"/> and registers if it is not already registered.
        /// </summary>
        /// <typeparam name="Tscript">The component that should be created and registered if it does not exist yet.</typeparam>
        public Tscript CreateRegisterAndReturnComponent<Tscript>() where Tscript : Component
        {
            if(TryGetInstance<Tscript>(out var instance))
            {
                instance.gameObject.SetActive(true);
                return instance;
            }

            var gameObject = new GameObject("GetTheFuckingXp_Endskill");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            instance = gameObject.AddComponent<Tscript>();

            SetInstance(instance);
            return instance;
        }


        /// <summary>
        /// Kills the registered <typeparamref name="Tscript"/> component if it exists.
        /// </summary>
        public void KillScript<Tscript>() where Tscript : Component
        {
            if(TryGetInstance<Tscript>(out var script))
            {
                script.gameObject.SetActive(false);
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
        public bool TryGetInstance<Tinstance>(out Tinstance instance)
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
        public void SetInformation(object key, object info)
        {
            //This works! It creates a new entry with the key if it does not exist yet.
            _informationCache[key] = info;
        }

        /// <summary>
        /// Tries to get the information cached with the <paramref name="key"/> as Key.
        /// </summary>
        public Tinformation GetInformation<Tinformation>(object key)
        {
            if (_informationCache.TryGetValue(key, out var info))
            {
                return (Tinformation)info;
            }

            throw new KeyNotFoundException($"There was no information with the key {key}");
        }

        /// <summary>
        /// Tries to get the instance with the key <paramref name="key"/> and sets <paramref name="information"/> to the found information set with the key.
        /// </summary>
        /// <param name="key">The key to the information searched.</param>
        /// <param name="information">The found information in the information cache.</param>
        /// <returns>If an information with the key <paramref name="key"/> was found.</returns>
        public bool TryGetInformation<Tinformation>(object key, out Tinformation information)
        {
            if(_informationCache.TryGetValue(key, out var innerInformation))
            {
                information = (Tinformation)innerInformation;
                return true;
            }

            information = default;
            return false;
        }
    }
}
