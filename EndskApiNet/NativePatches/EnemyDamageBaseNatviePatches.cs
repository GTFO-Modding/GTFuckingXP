using Agents;
using BepInEx.IL2CPP.Hook;
using EndskApi.Api;
using EndskApi.Manager;
using GTFO.API;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace EndskApi.NativePatches
{
    internal class EnemyDamageBaseNatviePatches
    {
        private readonly ReceiveMeleeDamage _originalReceiveMeleeDamage;
        private readonly ReceiveBulletDamage _originalReceiveBulletDamage;
        private readonly ReceiveExplosionDamage _originalReceiveExplosionDamage;
        private readonly ProcessReceivedDamage _originalProcessReceivedDamage;
        private readonly List<INativeDetour> _detours;

        unsafe public EnemyDamageBaseNatviePatches()
        {
            _detours = new List<INativeDetour>()
            {
                INativeDetour.CreateAndApply((nint)Il2CppAPI.GetIl2CppMethod<Dam_EnemyDamageBase>(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage), "System.Void", false, nameof(pFullDamageData)),
                ReceiveMeleeDamagePatch, out _originalReceiveMeleeDamage),
                INativeDetour.CreateAndApply((nint)Il2CppAPI.GetIl2CppMethod<Dam_EnemyDamageBase>(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage), "System.Void", false, nameof(pBulletDamageData)),
                ReceiveBulletDamagePatch, out _originalReceiveBulletDamage),
                INativeDetour.CreateAndApply((nint)Il2CppAPI.GetIl2CppMethod<Dam_EnemyDamageBase>(nameof(Dam_EnemyDamageBase.ReceiveExplosionDamage), "System.Void", false, nameof(pExplosionDamageData)),
                ReceiveExplosionDamagePatch, out _originalReceiveExplosionDamage),
                INativeDetour.CreateAndApply((nint)Il2CppAPI.GetIl2CppMethod<Dam_EnemyDamageBase>(nameof(Dam_EnemyDamageBase.ProcessReceivedDamage), "System.Void", false,
                nameof(Single), nameof(Agent), nameof(Vector3), nameof(Vector3), nameof(ES_HitreactType), nameof(Boolean), nameof(Int32), nameof(Single), nameof(DamageNoiseLevel)),
                ProcessReceivedDamagePatch, out _originalProcessReceivedDamage)
            };
        }

        //public unsafe delegate void MeleeDamage(IntPtr _this, float* dam, IntPtr _sourceAgent, Vector3* position, Vector3* direction, int* limbID, float* staggerMulti, float* precisionMulti, float* backstabberMulti, float* sleeperMulti, bool* skipLimbDestruction, DamageNoiseLevel* damageNoiseLevel);
        //public unsafe delegate void BulletDamage(IntPtr _this, float* dam, IntPtr _sourceAgent, Vector3* position, Vector3* direction, Vector3* normal, bool* allowDirectionalBonus, int* limbID, float* staggerMulti, float* precisionMulti);
        //public unsafe delegate void ExplosionDamage(IntPtr _this, float* dam, Vector3* sourcePos, Vector3* force, int* limbID);
        public unsafe delegate void ReceiveMeleeDamage(IntPtr _this, pFullDamageData* data, Il2CppMethodInfo* methodInfo);
        public unsafe delegate void ReceiveBulletDamage(IntPtr _this, pBulletDamageData* data, Il2CppMethodInfo* methodInfo);
        public unsafe delegate void ReceiveExplosionDamage(IntPtr _this, pExplosionDamageData* data, Il2CppMethodInfo* methodInfo);
        public unsafe delegate void ProcessReceivedDamage(IntPtr _this, float* damage, IntPtr _damageSource, Vector3* position, Vector3* direction, ES_HitreactType* hitreact, bool* tryForceHitreact, int* limbID, float* staggerDamageMulti, DamageNoiseLevel* damageNoiseLevel, Il2CppMethodInfo* methodInfo);

        public unsafe void ReceiveMeleeDamagePatch(IntPtr _this, pFullDamageData* data, Il2CppMethodInfo* methodInfo)
        {
            try
            {
                var owner = new Dam_EnemyDamageBase(_this);
                EnemyDamageBasePatchApi.InvokeReceiveMeleePrefix(owner, ref *data);
                _originalReceiveMeleeDamage(_this, data, methodInfo);
                EnemyDamageBasePatchApi.InvokeReceiveMeleePostfix(owner, ref *data);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex);
                LogManager.Error(ex.StackTrace);
            }
        }

        public unsafe void ReceiveBulletDamagePatch(IntPtr _this, pBulletDamageData* data, Il2CppMethodInfo* methodInfo)
        {
            try
            {
                var owner = new Dam_EnemyDamageBase(_this);
                EnemyDamageBasePatchApi.InvokeReceiveBulletPrefix(owner, ref *data);
                _originalReceiveBulletDamage(_this, data, methodInfo);
                EnemyDamageBasePatchApi.InvokeReceiveBulletPostfix(owner, ref *data);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex);
                LogManager.Error(ex.StackTrace);
            }
        }

        public unsafe void ReceiveExplosionDamagePatch(IntPtr _this, pExplosionDamageData* data, Il2CppMethodInfo* methodInfo)
        {
            try
            {
                var owner = new Dam_EnemyDamageBase(_this);
                EnemyDamageBasePatchApi.InvokeReceiveExplosionPrefix(owner, ref *data);
                _originalReceiveExplosionDamage(_this, data, methodInfo);
                EnemyDamageBasePatchApi.InvokeReceiveExplosionPostfix(owner, ref *data);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex);
                LogManager.Error(ex.StackTrace);
            }

        }

        public unsafe void ProcessReceivedDamagePatch(IntPtr _this, float* damage, IntPtr _damageSource, Vector3* position, Vector3* direction, ES_HitreactType* hitreact, bool* tryForceHitreact, int* limbID, float* staggerDamageMulti, DamageNoiseLevel* damageNoiseLevel, Il2CppMethodInfo* methodInfo)
        {
            try
            {
                var owner = new Dam_EnemyDamageBase(_this);
                var agent = new Agent(_damageSource);
                EnemyDamageBasePatchApi.InvokeProcessReceivedDamagePrefix(owner, ref *damage, agent, ref *position, ref *direction, ref *hitreact, ref *tryForceHitreact, ref *limbID, ref *staggerDamageMulti, ref *damageNoiseLevel);
                _originalProcessReceivedDamage(_this, damage, _damageSource, position, direction, hitreact, tryForceHitreact, limbID, staggerDamageMulti, damageNoiseLevel, methodInfo);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex);
                LogManager.Error(ex.StackTrace);
            }
        }
    }
}
