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

            foreach(var buff in buffs)
            {
                switch(buff.CustomBuff)
                {
                    case Enums.CustomScaling.MeleeRangeMultiplier:
                        if(targetAgent.IsLocallyOwned)
                        {
                            var meleeData = GetLocalMeleeWeapon().MeleeArchetypeData;
                            if(!CacheApiWrapper.TryGetDefaultMeleeRange(out var meleeRange))
                            {
                                meleeRange = meleeData.CameraDamageRayLength;
                                CacheApiWrapper.SetDefaultMeleeRange(meleeRange);
                            }

                            meleeData.CameraDamageRayLength = meleeRange * buff.Value;
                        }
                        break;
                    case Enums.CustomScaling.MeleeHitBoxSizeMultiplier:
                        if (targetAgent.IsLocallyOwned)
                        {
                            var meleeData = GetLocalMeleeWeapon().MeleeArchetypeData;
                            if (!CacheApiWrapper.TryGetDefaultMeleeHitBox(out var meleeHitbox))
                            {
                                meleeHitbox = meleeData.AttackSphereRadius;
                                CacheApiWrapper.SetDefaultMeleeHitBox(meleeHitbox);
                            }

                            meleeData.AttackSphereRadius = meleeHitbox * buff.Value;
                        }
                        break;
                    case Enums.CustomScaling.MovementSpeedMultiplier:
                        if (targetAgent.IsLocallyOwned)
                        {
                            LogManager.Debug("Pre movment speed");
                            var playerData = targetAgent.PlayerData;
                            if (!CacheApiWrapper.TryGetDefaultMovment(out var movmentInfo))
                            {
                                movmentInfo.walk = playerData.walkMoveSpeed;
                                movmentInfo.run = playerData.runMoveSpeed;
                                movmentInfo.air = playerData.airMoveSpeed;
                                movmentInfo.crouch = playerData.crouchMoveSpeed;
                                CacheApiWrapper.SetDefaultMovment(movmentInfo.walk, movmentInfo.run, movmentInfo.air, movmentInfo.crouch);
                            }

                            playerData.walkMoveSpeed = movmentInfo.walk * buff.Value;
                            playerData.runMoveSpeed = movmentInfo.run * buff.Value;
                            playerData.airMoveSpeed = movmentInfo.air * buff.Value;
                            playerData.crouchMoveSpeed = movmentInfo.crouch * buff.Value;
                            LogManager.Debug("Post movment speed");
                        }
                        break;
                    case Enums.CustomScaling.AntiFogSphere:
                        //if (!targetAgent.IsLocallyOwned)
                        //    break;

                        //var fogSphere = targetAgent.gameObject.GetComponent<FogRepeller_Sphere>();
                        //if (buff.Value > 0.1f)
                        //{
                        //    if (fogSphere is null)
                        //    {
                        //        fogSphere = targetAgent.gameObject.AddComponent<FogRepeller_Sphere>();
                        //    }
                        //    fogSphere.LifeDuration = 36000f;
                        //    fogSphere.GrowDuration = 5f;
                        //    fogSphere.Range = buff.Value;

                        //    fogSphere.StartRepelling();
                        //}
                        //else
                        //{
                        //    if(fogSphere != null)
                        //    {
                        //        fogSphere.StopRepelling();
                        //    }
                        //}
                        break;
                    case Enums.CustomScaling.JumpVelInitialPlus:
                        if (!CacheApiWrapper.TryGetDefaultJumpVelInitial(out var jumpVelInitialDefault))
                        {
                            jumpVelInitialDefault = targetAgent.PlayerData.jumpVelInitial;
                            CacheApiWrapper.SetDefaultJumpVelInitial(jumpVelInitialDefault);
                        }

                        targetAgent.PlayerData.jumpVelInitial = jumpVelInitialDefault + buff.Value;
                        break;
                    case Enums.CustomScaling.JumpGravityMulDefaultPlus:
                        if (!CacheApiWrapper.TryGetDefaultJumpGravityMulDefault(out var jumpGravityMul))
                        {
                            jumpGravityMul = targetAgent.PlayerData.jumpGravityMulDefault;
                            CacheApiWrapper.SetDefaultJumpGravityMulDefault(jumpGravityMul);
                        }

                        targetAgent.PlayerData.jumpGravityMulDefault = jumpGravityMul + buff.Value;
                        break;
                    case Enums.CustomScaling.JumpGravityMulButtonReleased:
                        if (!CacheApiWrapper.TryGetDefaultJumpGravityMulButtonReleased(out var jumpButton))
                        {
                            jumpButton = targetAgent.PlayerData.jumpGravityMulButtonReleased;
                            CacheApiWrapper.SetDefaultJumpGravityMulButtonReleased(jumpButton);
                        }

                        targetAgent.PlayerData.jumpGravityMulButtonReleased = jumpButton + buff.Value;
                        break;
                    case Enums.CustomScaling.JumpGravityMulAfterPeakPlus:
                        if (!CacheApiWrapper.TryGetDefaultJumpGravityMulAfterPeak(out var jumpGravityMulAfterPeak))
                        {
                            jumpGravityMulAfterPeak = targetAgent.PlayerData.jumpGravityMulAfterPeak;
                            CacheApiWrapper.SetDefaultJumpGravityMulAfterPeak(jumpGravityMulAfterPeak);
                        }

                        targetAgent.PlayerData.jumpGravityMulAfterPeak= jumpGravityMulAfterPeak + buff.Value;
                        break;
                    case Enums.CustomScaling.JumpGravityMulFallingPlus:
                        if (!CacheApiWrapper.TryGetDefaultJumpGravityMulFalling(out var jumpGravityFalling))
                        {
                            jumpGravityFalling = targetAgent.PlayerData.jumpGravityMulFalling;
                            CacheApiWrapper.SetDefaultJumpGravityMulFalling(jumpGravityFalling);
                        }

                        targetAgent.PlayerData.jumpGravityMulFalling = jumpGravityFalling + buff.Value;
                        break;
                    case Enums.CustomScaling.JumpVerticalVelocityMaxPlus:
                        if (!CacheApiWrapper.TryGetDefaultJumpVelocityMax(out var jumpVelocityMax))
                        {
                            jumpVelocityMax = targetAgent.PlayerData.jumpVerticalVelocityMax;
                            CacheApiWrapper.SetDefaultJumpVelocityMax(jumpVelocityMax);
                        }

                        targetAgent.PlayerData.jumpVerticalVelocityMax = jumpVelocityMax + buff.Value;
                        break;
                }
            }
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
    }
}
