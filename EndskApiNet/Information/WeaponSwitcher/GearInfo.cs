using Gear;
using Player;

namespace EndskApi.Information.WeaponSwitcher
{
    public class GearInfo
    {
        public GearInfo(GearIDRange gearId, int ammunitionInMagazine, InventorySlotAmmo inventorySlotAmmo)
        {
            GearId = gearId;
            AmmunitionInMagazine = ammunitionInMagazine;

            InventorySlotAmmo = inventorySlotAmmo;

            //This way, we don't interfere with the garbage collector.
            AmmoType = inventorySlotAmmo.AmmoType;
            Slot = inventorySlotAmmo.Slot;
        }

        public InventorySlotAmmo InventorySlotAmmo { get; set; }
        public InventorySlot Slot { get; set; }
        public AmmoType AmmoType { get; set; }
        public GearIDRange GearId { get; set; }
        public int AmmunitionInMagazine { get; set; }
    }
}
