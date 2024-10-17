using FX_EffectSystem;
using Gear;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using Player;
using System.Collections.Generic;
using UnityEngine;

namespace GTFuckingXP.Managers
{
    public static class CustomScalingBuffManager
    {
        public static void ApplyCustomScalingEffects(PlayerAgent targetAgent, List<CustomScalingBuff> buffs)
        {
            if (buffs is null || buffs.Count == 0)
                return;

            foreach (Enums.CustomScaling customBuff in Enum.GetValues(typeof(Enums.CustomScaling)))
                if (CacheApiWrapper.HasDefaultCustomScaling(customBuff))
                    SetCustomBuff(customBuff, 1f, targetAgent);

            foreach(var buff in buffs)
                SetCustomBuff(buff, targetAgent);
        }

        private static void StartRepellerWithoutSound(FogRepeller_Sphere antiFog)
        {
            //antiFog.m_repellerEnabled = true;
            //if (!antiFog.m_hasLight && FX_Manager.TryAllocateFXLight(out var light, false))
            //{
            //    antiFog.m_light = light;
            //    antiFog.m_hasLight = true;
            //}
            //if (antiFog.m_hasLight)
            //{
            //    antiFog.m_light.SetColor(new Color(0f,0f,0f));
            //    antiFog.m_light.SetRange(0.5f);
            //    antiFog.m_light.m_intensity = 0.6f;
            //    antiFog.m_light.UpdateData();
            //    if (antiFog.m_lightColorRoutine != null)
            //        antiFog.StopCoroutine(antiFog.m_lightColorRoutine);
            //    antiFog.m_lightColorRoutine = antiFog.StartCoroutine(antiFog.LightColorUpdate());
            //}
            //if (antiFog.m_infectionShield == null)
            //{
            //    EV_Sphere evSphere = new EV_Sphere();
            //    evSphere.contents = eEffectVolumeContents.Infection;
            //    evSphere.modification = eEffectVolumeModification.Shield;
            //    evSphere.modificationScale = 1f;
            //    evSphere.position = antiFog.transform.position;
            //    evSphere.invert = true;
            //    evSphere.effectOrder = 1;
            //    antiFog.m_infectionShield = evSphere;
            //    EffectVolumeManager.RegisterVolume((EffectVolume)antiFog.m_infectionShield);
            //}

            //if (!antiFog.m_isInitialized)
            //    antiFog.ChangeState(eFogRepellerSphereState.Initialize, 3f);
            //else
            //    antiFog.ChangeState(eFogRepellerSphereState.Grow, antiFog.GrowDuration);
        }

        private static MeleeWeaponFirstPerson GetLocalMeleeWeapon()
        {
            foreach(var item in PlayerBackpackManager.LocalBackpack.BackpackItems)
            {
                if(item.Instance.pItemData.slot == InventorySlot.GearMelee)
                {
                    LogManager.Debug("Found Melee");
                    return item.Instance.Cast<MeleeWeaponFirstPerson>();
                }
            }

            LogManager.Warn("No melee weapon found o.O?");
            throw new System.Exception($"There is no {typeof(MeleeWeaponFirstPerson)} item in the local backpack!");
        }

        private static void SetCustomBuff(CustomScalingBuff customScalingBuff, PlayerAgent targetAgent) => SetCustomBuff(customScalingBuff.CustomBuff, customScalingBuff.Value, targetAgent);

        private static void SetCustomBuff(Enums.CustomScaling customBuff, float value, PlayerAgent targetAgent)
        {       
            switch (customBuff)
            {
                case Enums.CustomScaling.MeleeRangeMultiplier:
                    if (targetAgent.IsLocallyOwned)
                    {
                        var meleeData = GetLocalMeleeWeapon().MeleeArchetypeData;
                        if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float meleeRange))
                        {
                            meleeRange = meleeData.CameraDamageRayLength;
                            CacheApiWrapper.SetDefaultCustomScaling(customBuff, meleeRange);
                        }

                        meleeData.CameraDamageRayLength = meleeRange * value;
                    }
                    break;
                case Enums.CustomScaling.MeleeHitBoxSizeMultiplier:
                    if (targetAgent.IsLocallyOwned)
                    {
                        var meleeData = GetLocalMeleeWeapon().MeleeArchetypeData;
                        if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float meleeHitbox))
                        {
                            meleeHitbox = meleeData.AttackSphereRadius;
                            CacheApiWrapper.SetDefaultCustomScaling(customBuff, meleeHitbox);
                        }

                        meleeData.AttackSphereRadius = meleeHitbox * value;
                    }
                    break;
                case Enums.CustomScaling.MovementSpeedMultiplier:
                    if (targetAgent.IsLocallyOwned)
                    {
                        var playerData = targetAgent.PlayerData;
                        if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out (float walk, float run, float air, float crouch) movementInfo))
                        {
                            movementInfo.walk = playerData.walkMoveSpeed;
                            movementInfo.run = playerData.runMoveSpeed;
                            movementInfo.air = playerData.airMoveSpeed;
                            movementInfo.crouch = playerData.crouchMoveSpeed;
                            CacheApiWrapper.SetDefaultCustomScaling(customBuff, movementInfo);
                        }

                        playerData.walkMoveSpeed = movementInfo.walk * value;
                        playerData.runMoveSpeed = movementInfo.run * value;
                        playerData.airMoveSpeed = movementInfo.air * value;
                        playerData.crouchMoveSpeed = movementInfo.crouch * value;
                    }
                    break;
                case Enums.CustomScaling.AntiFogSphere:
                    break;
                case Enums.CustomScaling.JumpVelInitialPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpVelInitialDefault))
                    {
                        jumpVelInitialDefault = targetAgent.PlayerData.jumpVelInitial;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpVelInitialDefault);
                    }

                    targetAgent.PlayerData.jumpVelInitial = jumpVelInitialDefault + value;
                    break;
                case Enums.CustomScaling.JumpGravityMulDefaultPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpGravityMul))
                    {
                        jumpGravityMul = targetAgent.PlayerData.jumpGravityMulDefault;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpGravityMul);
                    }

                    targetAgent.PlayerData.jumpGravityMulDefault = jumpGravityMul + value;
                    break;
                case Enums.CustomScaling.JumpGravityMulButtonReleased:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpButton))
                    {
                        jumpButton = targetAgent.PlayerData.jumpGravityMulButtonReleased;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpButton);
                    }

                    targetAgent.PlayerData.jumpGravityMulButtonReleased = jumpButton + value;
                    break;
                case Enums.CustomScaling.JumpGravityMulAfterPeakPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpGravityMulAfterPeak))
                    {
                        jumpGravityMulAfterPeak = targetAgent.PlayerData.jumpGravityMulAfterPeak;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpGravityMulAfterPeak);
                    }

                    targetAgent.PlayerData.jumpGravityMulAfterPeak = jumpGravityMulAfterPeak + value;
                    break;
                case Enums.CustomScaling.JumpGravityMulFallingPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpGravityFalling))
                    {
                        jumpGravityFalling = targetAgent.PlayerData.jumpGravityMulFalling;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpGravityFalling);
                    }

                    targetAgent.PlayerData.jumpGravityMulFalling = jumpGravityFalling + value;
                    break;
                case Enums.CustomScaling.JumpVerticalVelocityMaxPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpVelocityMax))
                    {
                        jumpVelocityMax = targetAgent.PlayerData.jumpVerticalVelocityMax;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpVelocityMax);
                    }

                    targetAgent.PlayerData.jumpVerticalVelocityMax = jumpVelocityMax + value;
                    break;
            }
        }
    }
}
