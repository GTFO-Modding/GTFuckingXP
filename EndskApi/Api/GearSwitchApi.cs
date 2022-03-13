using EndskApi.Information.WeaponSwitcher;
using EndskApi.Manager;
using GameData;
using Gear;
using Player;
using System;
using System.Collections.Generic;
using static Player.PlayerBackpack;

namespace EndskApi.Api
{
    public static class GearSwitchApi
    {
        static GearSwitchApi()
        {
            EndLevelApi.AddEndLevelCallback(LevelEndedCallback);
            SetGearInfoCache(new Dictionary<IntPtr, GearInfo>());
        }

        /// <summary>
        /// Creates a new <see cref="GearInfo"/> based on <paramref name="gearId"/>.
        /// The default ammo Initial is used from the slot <paramref name="ammoType"/>.
        /// The magazine will get set to the clip size.
        /// </summary>
        public static GearInfo CreateNewWeaponInfo(InventorySlot slot, AmmoType ammoType, GearIDRange gearId)
        {
            var block = GameDataBlockBase<PlayerDataBlock>.GetBlock(1);

            var slotAmmo = new InventorySlotAmmo();
            slotAmmo.Slot = slot;

            slotAmmo.AmmoInPack = ammoType == AmmoType.Special ? block.AmmoSpecialInitial : block.AmmoStandardInitial;
            slotAmmo.AmmoMaxCap = ammoType == AmmoType.Special ? block.AmmoSpecialMaxCap : block.AmmoStandardMaxCap;

            var weaponInfo = new GearInfo(gearId, 0, slotAmmo);

            var gearCategoryBlock = GameDataBlockBase<GearCategoryDataBlock>.GetBlock(gearId.GetCompID(eGearComponent.Category));
            var archetypeId = GearBuilder.GetArchetypeID(gearCategoryBlock, (eWeaponFireMode)gearId.GetCompID(eGearComponent.FireMode));
            var archeTypeBlock = GameDataBlockBase<ArchetypeDataBlock>.GetBlock(archetypeId);
            weaponInfo.InventorySlotAmmo.BulletClipSize = archeTypeBlock.DefaultClipSize;
            weaponInfo.AmmunitionInMagazine = archeTypeBlock.DefaultClipSize;
            LogManager.Debug($"Putting {weaponInfo.AmmunitionInMagazine} into {gearCategoryBlock.PublicName}");
            return weaponInfo;
        }

        /// <summary>
        /// Equips the <paramref name="newGear"/> after syncing the old active <see cref="GearInfo"/>.
        /// The old <see cref="GearInfo"/> gets returned as <paramref name="oldGear"/> if it was initialized with this api.
        /// </summary>
        public static void EquipGear(GearInfo newGear, out GearInfo oldGear)
        {
            AddWeaponInfo(newGear);
            SyncAmmonitionWithRegisteredWeapon(newGear.Slot, out oldGear);
            EquipGear(newGear);
        }

        /// <summary>
        /// Syncs the <see cref="GearInfo.AmmunitionInMagazine"/> in slot <paramref name="slot"/> with the current active weapon in the playerbackpack.
        /// </summary>
        public static void SyncAmmonitionWithRegisteredWeapon(InventorySlot slot, out GearInfo changedWeapon)
        {
            //If there is no item, we don't need to update anything ...
            if (TryGetItemEquippableInSlot(slot, out var item) && item != null)
            {
                LogManager.Debug("SyncAmmunitionWithRegisteredWeapon actually found Weapon itemequippable");
                var slotAmmo = PlayerBackpackManager.LocalBackpack.AmmoStorage.GetInventorySlotAmmo(slot);
                if (GetGearInfo().TryGetValue(slotAmmo.Pointer, out changedWeapon))
                {
                    changedWeapon.AmmunitionInMagazine = item.GetCurrentClip();
                    LogManager.Debug($"Updated Ammo to {changedWeapon.AmmunitionInMagazine}, Max is {changedWeapon.InventorySlotAmmo.BulletClipSize}");
                }
            }

            changedWeapon = null;
        }

        /// <summary>
        /// Manually registers a <see cref="GearInfo"/> to the gearswitch api. <br/>
        /// You may never want to call this method manually, because <see cref="EquipGear(GearInfo, out GearInfo)"/> already handles this for you!
        /// </summary>
        public static void AddWeaponInfo(GearInfo info)
        {
            var cache = GetGearInfo();
            if (!cache.ContainsKey(info.InventorySlotAmmo.Pointer))
            {
                cache.Add(info.InventorySlotAmmo.Pointer, info);
            }
        }

        /// <summary>
        /// unregister a <see cref="GearInfo"/> from the gearswitch api. <br/>
        /// Use this when you know, you will never use the exact same gear.
        /// </summary>
        public static void UnregisterWeapon(GearInfo info)
        {
            GetGearInfo().Remove(info.InventorySlotAmmo.Pointer);
        }

        private static void EquipGear(GearInfo info)
        {
            var localBackPack = PlayerBackpackManager.LocalBackpack;
            localBackPack.SpawnAndEquipGearAsync(info.Slot, info.GearId, (delBackpackItemCallback)BackPackItemCreatedCallBack);
            SetAmmoStorage(info, localBackPack.AmmoStorage);

            void BackPackItemCreatedCallBack(BackpackItem backpackItem)
            {
                var item = backpackItem.Instance.TryCast<ItemEquippable>();
                if (item != null)
                {
                    item.SetCurrentClip(info.AmmunitionInMagazine);

                    var playerAgent = PlayerManager.GetLocalPlayerAgent();
                    playerAgent.Sync.WantsToWieldSlot(info.Slot);
                }
            }
        }

        private static bool TryGetItemEquippableInSlot(InventorySlot slot, out ItemEquippable item)
        {
            var localBackpack = PlayerBackpackManager.LocalBackpack;

            if (!localBackpack.TryGetBackpackItem(slot, out var backPackItem))
            {
                item = null;
                return false;
            }

            item = backPackItem.Instance.TryCast<ItemEquippable>();
            return item != null;
        }

        private static void SetAmmoStorage(GearInfo info, PlayerAmmoStorage storage)
        {
            storage.m_ammoStorage[(int)info.AmmoType] = info.InventorySlotAmmo;

            switch (info.AmmoType)
            {
                case AmmoType.Standard:
                    storage.StandardAmmo = info.InventorySlotAmmo;
                    break;
                case AmmoType.Special:
                    storage.SpecialAmmo = info.InventorySlotAmmo;
                    break;
            }
        }

        internal static void LevelEndedCallback()
        {
            SetGearInfoCache(new Dictionary<IntPtr, GearInfo>());
        }

        private static Dictionary<IntPtr, GearInfo> GetGearInfo()
        {
            return CacheApi.GetInstance<Dictionary<IntPtr, GearInfo>>(CacheApi.InternalCache);
        }

        private static void SetGearInfoCache(Dictionary<IntPtr, GearInfo> dic)
        {
            CacheApi.SaveInstance(dic, CacheApi.InternalCache);
        }
    }
}
