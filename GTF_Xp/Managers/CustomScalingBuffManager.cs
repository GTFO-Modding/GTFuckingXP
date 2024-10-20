using Gear;
using GTFuckingXP.Enums;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using Player;

namespace GTFuckingXP.Managers
{
    public static class CustomScalingBuffManager
    {
        public static void ApplyCustomScalingEffects(PlayerAgent targetAgent, List<CustomScalingBuff> buffs)
        {
            if (buffs is null)
                return;

            ResetCustomBuffs(targetAgent);

            foreach (var buff in buffs)
                SetCustomBuff(buff, targetAgent);
        }

        private static MeleeWeaponFirstPerson GetLocalMeleeWeapon()
        {
            if (PlayerBackpackManager.LocalBackpack.TryGetBackpackItem(InventorySlot.GearMelee, out var bpItem))
            {
                LogManager.Debug("Found Melee");
                return bpItem.Instance.Cast<MeleeWeaponFirstPerson>();
            }

            LogManager.Warn("No melee weapon found o.O?");
            throw new System.Exception($"There is no {typeof(MeleeWeaponFirstPerson)} item in the local backpack!");
        }

        private static void SetCustomBuff(CustomScalingBuff customScalingBuff, PlayerAgent targetAgent) => SetCustomBuff(customScalingBuff.CustomBuff, customScalingBuff.Value, targetAgent);

        private static void SetCustomBuff(CustomScaling customBuff, float value, PlayerAgent targetAgent)
        {       
            switch (customBuff)
            {
                case CustomScaling.MeleeRangeMultiplier:
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
                case CustomScaling.MeleeHitBoxSizeMultiplier:
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
                case CustomScaling.MovementSpeedMultiplier:
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
                //case CustomScaling.AntiFogSphere:
                //    break;
                case CustomScaling.JumpVelInitialPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpVelInitialDefault))
                    {
                        jumpVelInitialDefault = targetAgent.PlayerData.jumpVelInitial;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpVelInitialDefault);
                    }

                    targetAgent.PlayerData.jumpVelInitial = jumpVelInitialDefault + value;
                    break;
                case CustomScaling.JumpGravityMulDefaultPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpGravityMul))
                    {
                        jumpGravityMul = targetAgent.PlayerData.jumpGravityMulDefault;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpGravityMul);
                    }

                    targetAgent.PlayerData.jumpGravityMulDefault = jumpGravityMul + value;
                    break;
                case CustomScaling.JumpGravityMulButtonReleased:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpButton))
                    {
                        jumpButton = targetAgent.PlayerData.jumpGravityMulButtonReleased;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpButton);
                    }

                    targetAgent.PlayerData.jumpGravityMulButtonReleased = jumpButton + value;
                    break;
                case CustomScaling.JumpGravityMulAfterPeakPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpGravityMulAfterPeak))
                    {
                        jumpGravityMulAfterPeak = targetAgent.PlayerData.jumpGravityMulAfterPeak;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpGravityMulAfterPeak);
                    }

                    targetAgent.PlayerData.jumpGravityMulAfterPeak = jumpGravityMulAfterPeak + value;
                    break;
                case CustomScaling.JumpGravityMulFallingPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpGravityFalling))
                    {
                        jumpGravityFalling = targetAgent.PlayerData.jumpGravityMulFalling;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpGravityFalling);
                    }

                    targetAgent.PlayerData.jumpGravityMulFalling = jumpGravityFalling + value;
                    break;
                case CustomScaling.JumpVerticalVelocityMaxPlus:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float jumpVelocityMax))
                    {
                        jumpVelocityMax = targetAgent.PlayerData.jumpVerticalVelocityMax;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, jumpVelocityMax);
                    }

                    targetAgent.PlayerData.jumpVerticalVelocityMax = jumpVelocityMax + value;
                    break;
                case CustomScaling.RegenStartDelayMultiplier:
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float regenDelay))
                    {
                        regenDelay = targetAgent.PlayerData.healthRegenStartDelayAfterDamage;
                        CacheApiWrapper.SetDefaultCustomScaling(customBuff, regenDelay);
                    }

                    targetAgent.PlayerData.healthRegenStartDelayAfterDamage = regenDelay * value;
                    targetAgent.Damage.m_nextRegen = Math.Min(targetAgent.Damage.m_nextRegen, Clock.Time + regenDelay * value);
                    break;
                case CustomScaling.AmmoEfficiency:
                    if (!targetAgent.IsLocallyOwned) break;

                    // Not how defaults are used elsewhere, but has better compatibility with EWC
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float lastAmmo))
                        lastAmmo = 1f;

                    PlayerAmmoStorage ammoStorage = PlayerBackpackManager.LocalBackpack.AmmoStorage;
                    ChangeAmmoEfficiency(InventorySlot.GearStandard, ammoStorage, lastAmmo, value);
                    ChangeAmmoEfficiency(InventorySlot.GearSpecial, ammoStorage, lastAmmo, value);
                    ammoStorage.NeedsSync = true;

                    CacheApiWrapper.SetDefaultCustomScaling(customBuff, value);
                    break;
                case CustomScaling.ToolEfficiency:
                    if (!targetAgent.IsLocallyOwned) break;

                    // Not how defaults are used elsewhere, but has better compatibility with EWC
                    if (!CacheApiWrapper.TryGetDefaultCustomScaling(customBuff, out float lastTool))
                        lastTool = 1f;

                    PlayerAmmoStorage toolStorage = PlayerBackpackManager.LocalBackpack.AmmoStorage;
                    ChangeAmmoEfficiency(InventorySlot.GearClass, toolStorage, lastTool, value);
                    toolStorage.NeedsSync = true;

                    CacheApiWrapper.SetDefaultCustomScaling(customBuff, value);
                    break;
            }
        }

        public static void ResetCustomBuffs(PlayerAgent targetAgent)
        {
            foreach (CustomScaling customBuff in Enum.GetValues(typeof(CustomScaling)))
                if (CacheApiWrapper.HasDefaultCustomScaling(customBuff))
                    SetCustomBuff(customBuff, GetResetModifier(customBuff), targetAgent);
        }

        public static void ClearDefaultCustomBuffs()
        {
            // Only care about the ones that will change
            CacheApiWrapper.RemoveDefaultCustomScaling(CustomScaling.MeleeRangeMultiplier);
            CacheApiWrapper.RemoveDefaultCustomScaling(CustomScaling.MeleeHitBoxSizeMultiplier);
            CacheApiWrapper.RemoveDefaultCustomScaling(CustomScaling.AmmoEfficiency);
        }

        private static float GetResetModifier(CustomScaling customBuff)
        {
            return customBuff switch
            {
                //CustomScaling.AntiFogSphere 
                CustomScaling.JumpVelInitialPlus 
                or CustomScaling.JumpGravityMulDefaultPlus 
                or CustomScaling.JumpGravityMulButtonReleased 
                or CustomScaling.JumpGravityMulAfterPeakPlus 
                or CustomScaling.JumpGravityMulFallingPlus 
                or CustomScaling.JumpVerticalVelocityMaxPlus => 0f,
                _ => 1f,
            };
        }

        private static void ChangeAmmoEfficiency(InventorySlot slot, PlayerAmmoStorage ammoStorage, float lastValue, float value)
        {
            if (!ammoStorage.m_playerBackpack.TryGetBackpackItem(slot, out var bpItem)) return;
            ItemEquippable item = bpItem.Instance.Cast<ItemEquippable>();
            InventorySlotAmmo slotAmmo = ammoStorage.GetInventorySlotAmmo(slot);

            int newClip = 0;
            if (slotAmmo.BulletClipSize > 0) // Tools don't have a clip
            {
                slotAmmo.AmmoInPack += item.GetCurrentClip() * slotAmmo.CostOfBullet;
                slotAmmo.Setup(slotAmmo.CostOfBullet *= lastValue / value, slotAmmo.BulletClipSize);
                newClip = Math.Min(slotAmmo.BulletsInPack, item.GetCurrentClip());
                item.SetCurrentClip(newClip);
                slotAmmo.AmmoInPack -= newClip * slotAmmo.CostOfBullet;
            }
            else
            {
                slotAmmo.Setup(slotAmmo.CostOfBullet *= lastValue / value, slotAmmo.BulletClipSize);
            }

            slotAmmo.OnBulletsUpdateCallback?.Invoke(slotAmmo.BulletsInPack);
            ammoStorage.UpdateSlotAmmoUI(slotAmmo, newClip);
        }

        /*private static void StartRepellerWithoutSound(FogRepeller_Sphere antiFog)
        {
            antiFog.m_repellerEnabled = true;
            if (!antiFog.m_hasLight && FX_Manager.TryAllocateFXLight(out var light, false))
            {
                antiFog.m_light = light;
                antiFog.m_hasLight = true;
            }
            if (antiFog.m_hasLight)
            {
                antiFog.m_light.SetColor(new Color(0f,0f,0f));
                antiFog.m_light.SetRange(0.5f);
                antiFog.m_light.m_intensity = 0.6f;
                antiFog.m_light.UpdateData();
                if (antiFog.m_lightColorRoutine != null)
                    antiFog.StopCoroutine(antiFog.m_lightColorRoutine);
                antiFog.m_lightColorRoutine = antiFog.StartCoroutine(antiFog.LightColorUpdate());
            }
            if (antiFog.m_infectionShield == null)
            {
                EV_Sphere evSphere = new EV_Sphere();
                evSphere.contents = eEffectVolumeContents.Infection;
                evSphere.modification = eEffectVolumeModification.Shield;
                evSphere.modificationScale = 1f;
                evSphere.position = antiFog.transform.position;
                evSphere.invert = true;
                evSphere.effectOrder = 1;
                antiFog.m_infectionShield = evSphere;
                EffectVolumeManager.RegisterVolume((EffectVolume)antiFog.m_infectionShield);
            }

            if (!antiFog.m_isInitialized)
                antiFog.ChangeState(eFogRepellerSphereState.Initialize, 3f);
            else
                antiFog.ChangeState(eFogRepellerSphereState.Grow, antiFog.GrowDuration);
        }*/
    }
}
