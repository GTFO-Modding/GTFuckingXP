using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTFuckingXp.Information
{
    public class DefaultConstants
    {
        public const string DoubleJumpExpansion = @"[
  {
    ""LevelLayoutPersistentId"": 13,
    ""UnlockAtLevel"": 10
  },
  {
    ""LevelLayoutPersistentId"": 14,
    ""UnlockAtLevel"": 6
  },
  {
    ""LevelLayoutPersistentId"": 7,
    ""UnlockAtLevel"": 5
  },
  {
    ""LevelLayoutPersistentId"": 8,
    ""UnlockAtLevel"": 5
  },
  {
    ""LevelLayoutPersistentId"": 15,
    ""UnlockAtLevel"": 5
  }
]";

        public const string ExpansionsActive = @"
{
    ""ExplosionAbility"": false,
    ""DoubleJumpAbility"": true
}
";

        public const string BoosterEffects = @"
[
  {
    ""ClassLayoutPersistentId"": 2,
    ""ActiveLevels"": [
      10
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 1.35
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.03,
      ""ProjectileResistance"": 1.03,
      ""InfectionResistance"": 1.03
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.06,
      ""ProjectileResistance"": 1.06,
      ""InfectionResistance"": 1.06
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.09,
      ""ProjectileResistance"": 1.09,
      ""InfectionResistance"": 1.09
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.12,
      ""ProjectileResistance"": 1.12,
      ""InfectionResistance"": 1.12
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.15,
      ""ProjectileResistance"": 1.15,
      ""InfectionResistance"": 1.15
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      6
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.18,
      ""ProjectileResistance"": 1.18,
      ""InfectionResistance"": 1.18
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      7
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.21,
      ""ProjectileResistance"": 1.21,
      ""InfectionResistance"": 1.21
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      8
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.24,
      ""ProjectileResistance"": 1.24,
      ""InfectionResistance"": 1.24
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      9
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.27,
      ""ProjectileResistance"": 1.27,
      ""InfectionResistance"": 1.27
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      10
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.3,
      ""ProjectileResistance"": 1.3,
      ""InfectionResistance"": 1.3
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      11
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.33,
      ""ProjectileResistance"": 1.33,
      ""InfectionResistance"": 1.33
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      12
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.36,
      ""ProjectileResistance"": 1.36,
      ""InfectionResistance"": 1.36
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      13
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.39,
      ""ProjectileResistance"": 1.39,
      ""InfectionResistance"": 1.39
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      14
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.42,
      ""ProjectileResistance"": 1.42,
      ""InfectionResistance"": 1.42
    }
  },
  {
    ""ClassLayoutPersistentId"": 3,
    ""ActiveLevels"": [
      15
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.45,
      ""ProjectileResistance"": 1.45,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 4,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 1.35,
      ""ReviveSpeedSupport"": 1.25
    }
  },
  {
    ""ClassLayoutPersistentId"": 4,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 1.7,
      ""ReviveSpeedSupport"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 4,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.05,
      ""ReviveSpeedSupport"": 1.75
    }
  },
  {
    ""ClassLayoutPersistentId"": 4,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.40,
      ""ReviveSpeedSupport"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 4,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.75,
      ""ReviveSpeedSupport"": 2.25,
      ""MeleeResistance"": 1.15,
      ""ProjectileResistance"": 1.15
    }
  },
  {
    ""ClassLayoutPersistentId"": 15,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 12,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 1.35,
      ""ReviveSpeedSupport"": 1.1,
      ""MeleeResistance"": 1.04,
      ""ProjectileResistance"": 1.04,
      ""InfectionResistance"": 1.05
    }
  },
  {
    ""ClassLayoutPersistentId"": 12,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 1.7,
      ""ReviveSpeedSupport"": 1.2,
      ""MeleeResistance"": 1.08,
      ""ProjectileResistance"": 1.08,
      ""InfectionResistance"": 1.1
    }
  },
  {
    ""ClassLayoutPersistentId"": 12,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.05,
      ""ReviveSpeedSupport"": 1.3,
      ""MeleeResistance"": 1.12,
      ""ProjectileResistance"": 1.12,
      ""InfectionResistance"": 1.15
    }
  },
  {
    ""ClassLayoutPersistentId"": 12,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.40,
      ""ReviveSpeedSupport"": 1.4,
      ""MeleeResistance"": 1.16,
      ""ProjectileResistance"": 1.16,
      ""InfectionResistance"": 1.2
    }
  },
  {
    ""ClassLayoutPersistentId"": 12,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.75,
      ""ReviveSpeedSupport"": 1.5,
      ""MeleeResistance"": 1.2,
      ""ProjectileResistance"": 1.2,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 5,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.55,
      ""ScannerRechargeSpeed"": 1.15,
      ""SentryGunDamage"": 1.15,
      ""GlueEfficiency"": 1.15,
      ""TripMineDamage"": 1.15,
      ""ComputerProcessingSpeed"": 1.2,
      ""FogRepellerEffect"": 1.2
    }
  },
  {
    ""ClassLayoutPersistentId"": 5,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 2.1,
      ""ScannerRechargeSpeed"": 1.3,
      ""SentryGunDamage"": 1.3,
      ""GlueEfficiency"": 1.3,
      ""TripMineDamage"": 1.3,
      ""ComputerProcessingSpeed"": 1.4,
      ""FogRepellerEffect"": 1.4
    }
  },
  {
    ""ClassLayoutPersistentId"": 5,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 2.65,
      ""ScannerRechargeSpeed"": 1.45,
      ""SentryGunDamage"": 1.45,
      ""GlueEfficiency"": 1.45,
      ""TripMineDamage"": 1.45,
      ""ComputerProcessingSpeed"": 1.6,
      ""FogRepellerEffect"": 1.6
    }
  },
  {
    ""ClassLayoutPersistentId"": 5,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 3.2,
      ""ScannerRechargeSpeed"": 1.6,
      ""SentryGunDamage"": 1.6,
      ""GlueEfficiency"": 1.6,
      ""TripMineDamage"": 1.6,
      ""ComputerProcessingSpeed"": 1.8,
      ""FogRepellerEffect"": 1.8
    }
  },
  {
    ""ClassLayoutPersistentId"": 5,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.8,
      ""SentryGunDamage"": 1.75,
      ""GlueEfficiency"": 1.75,
      ""TripMineDamage"": 1.75,
      ""ComputerProcessingSpeed"": 999.0,
      ""FogRepellerEffect"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 6,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.5,
      ""ProjectileResistance"": 0.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 6,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 1.5,
      ""MeleeResistance"": 0.46,
      ""ProjectileResistance"": 0.46
    }
  },
  {
    ""ClassLayoutPersistentId"": 6,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.0,
      ""MeleeResistance"": 0.42,
      ""ProjectileResistance"": 0.42
    }
  },
  {
    ""ClassLayoutPersistentId"": 6,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 2.5,
      ""MeleeResistance"": 0.38,
      ""ProjectileResistance"": 0.38
    }
  },
  {
    ""ClassLayoutPersistentId"": 6,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 3.0,
      ""MeleeResistance"": 0.34,
      ""ProjectileResistance"": 0.34
    }
  },
  {
    ""ClassLayoutPersistentId"": 6,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""RegenerationSpeed"": 3.5,
      ""MeleeResistance"": 0.3,
      ""ProjectileResistance"": 0.3
    }
  },
  {
    ""ClassLayoutPersistentId"": 7,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.04,
      ""ProjectileResistance"": 1.04
    }
  },
  {
    ""ClassLayoutPersistentId"": 7,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.08,
      ""ProjectileResistance"": 1.08
    }
  },
  {
    ""ClassLayoutPersistentId"": 7,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.12,
      ""ProjectileResistance"": 1.12
    }
  },
  {
    ""ClassLayoutPersistentId"": 7,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.16,
      ""ProjectileResistance"": 1.16
    }
  },
  {
    ""ClassLayoutPersistentId"": 7,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.2,
      ""ProjectileResistance"": 1.2
    }
  },
  {
    ""ClassLayoutPersistentId"": 8,
    ""ActiveLevels"": [
      0
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.55,
      ""ProjectileResistance"": 0.55
    }
  },
  {
    ""ClassLayoutPersistentId"": 8,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.6,
      ""ProjectileResistance"": 0.6
    }
  },
  {
    ""ClassLayoutPersistentId"": 8,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.65,
      ""ProjectileResistance"": 0.65
    }
  },
  {
    ""ClassLayoutPersistentId"": 8,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.7,
      ""ProjectileResistance"": 0.7
    }
  },
  {
    ""ClassLayoutPersistentId"": 8,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.75,
      ""ProjectileResistance"": 0.75
    }
  },
  {
    ""ClassLayoutPersistentId"": 8,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.8,
      ""ProjectileResistance"": 0.8
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      0
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.6,
      ""ProjectileResistance"": 0.6
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.63,
      ""ProjectileResistance"": 0.63
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.66,
      ""ProjectileResistance"": 0.66
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.69,
      ""ProjectileResistance"": 0.69
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.72,
      ""ProjectileResistance"": 0.72
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.75,
      ""ProjectileResistance"": 0.75
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      6
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.78,
      ""ProjectileResistance"": 0.78
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      7
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.81,
      ""ProjectileResistance"": 0.81
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      8
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.84,
      ""ProjectileResistance"": 0.84
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      9
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.87,
      ""ProjectileResistance"": 0.87
    }
  },
  {
    ""ClassLayoutPersistentId"": 9,
    ""ActiveLevels"": [
      10
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 0.9,
      ""ProjectileResistance"": 0.9
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.02,
      ""ProjectileResistance"": 1.05,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.04,
      ""ProjectileResistance"": 1.1,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.06,
      ""ProjectileResistance"": 1.15,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.08,
      ""ProjectileResistance"": 1.2,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.10,
      ""ProjectileResistance"": 1.25,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      6
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.12,
      ""ProjectileResistance"": 1.3,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      7
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.14,
      ""ProjectileResistance"": 1.35,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      8
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.16,
      ""ProjectileResistance"": 1.4,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      9
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.18,
      ""ProjectileResistance"": 1.45,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      10
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.2,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      11
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.22,
      ""ProjectileResistance"": 1.55,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      12
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.24,
      ""ProjectileResistance"": 1.6,
      ""InfectionResistance"": 2
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      13
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.26,
      ""ProjectileResistance"": 1.65,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      14
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.28,
      ""ProjectileResistance"": 1.7,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 11,
    ""ActiveLevels"": [
      15
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.3,
      ""ProjectileResistance"": 1.75,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 16,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""ScannerRechargeSpeed"": 1.15,
      ""SentryGunDamage"": 1.15,
      ""GlueEfficiency"": 1.15,
      ""TripMineDamage"": 1.15,
      ""FogRepellerEffect"": 1.6,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 16,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""ScannerRechargeSpeed"": 1.3,
      ""SentryGunDamage"": 1.3,
      ""GlueEfficiency"": 1.3,
      ""TripMineDamage"": 1.3,
      ""FogRepellerEffect"": 2.2,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 16,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""ScannerRechargeSpeed"": 1.45,
      ""SentryGunDamage"": 1.45,
      ""GlueEfficiency"": 1.45,
      ""TripMineDamage"": 1.45,
      ""FogRepellerEffect"": 2.8,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 16,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""ScannerRechargeSpeed"": 1.6,
      ""SentryGunDamage"": 1.6,
      ""GlueEfficiency"": 1.6,
      ""TripMineDamage"": 1.6,
      ""FogRepellerEffect"": 3.4,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 16,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""ScannerRechargeSpeed"": 1.15,
      ""SentryGunDamage"": 1.75,
      ""GlueEfficiency"": 1.75,
      ""TripMineDamage"": 1.75,
      ""FogRepellerEffect"": 15.0,
      ""InfectionResistance"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      1
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.1,
      ""ScannerRechargeSpeed"": 1.05,
      ""SentryGunDamage"": 1.05,
      ""GlueEfficiency"": 1.05,
      ""TripMineDamage"": 1.05,
      ""ComputerProcessingSpeed"": 1.05,
      ""FogRepellerEffect"": 1.05,
      ""MeleeResistance"": 1.02,
      ""ProjectileResistance"": 1.02,
      ""InfectionResistance"": 1.02
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      2
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.2,
      ""ScannerRechargeSpeed"": 1.1,
      ""SentryGunDamage"": 1.1,
      ""GlueEfficiency"": 1.1,
      ""TripMineDamage"": 1.1,
      ""ComputerProcessingSpeed"": 1.1,
      ""FogRepellerEffect"": 1.1,
      ""MeleeResistance"": 1.04,
      ""ProjectileResistance"": 1.04,
      ""InfectionResistance"": 1.04
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.3,
      ""ScannerRechargeSpeed"": 1.15,
      ""SentryGunDamage"": 1.15,
      ""GlueEfficiency"": 1.15,
      ""TripMineDamage"": 1.15,
      ""ComputerProcessingSpeed"": 1.15,
      ""FogRepellerEffect"": 1.15,
      ""MeleeResistance"": 1.06,
      ""ProjectileResistance"": 1.06,
      ""InfectionResistance"": 1.06
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.4,
      ""ScannerRechargeSpeed"": 1.2,
      ""SentryGunDamage"": 1.2,
      ""GlueEfficiency"": 1.2,
      ""TripMineDamage"": 1.2,
      ""ComputerProcessingSpeed"": 1.2,
      ""FogRepellerEffect"": 1.2,
      ""MeleeResistance"": 1.08,
      ""ProjectileResistance"": 1.08,
      ""InfectionResistance"": 1.08
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.5,
      ""ScannerRechargeSpeed"": 1.25,
      ""SentryGunDamage"": 1.25,
      ""GlueEfficiency"": 1.25,
      ""TripMineDamage"": 1.25,
      ""ComputerProcessingSpeed"": 1.25,
      ""FogRepellerEffect"": 1.25,
      ""MeleeResistance"": 1.1,
      ""ProjectileResistance"": 1.1,
      ""InfectionResistance"": 1.1
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      6
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.6,
      ""ScannerRechargeSpeed"": 1.3,
      ""SentryGunDamage"": 1.3,
      ""GlueEfficiency"": 1.3,
      ""TripMineDamage"": 1.3,
      ""ComputerProcessingSpeed"": 1.3,
      ""FogRepellerEffect"": 1.3,
      ""MeleeResistance"": 1.12,
      ""ProjectileResistance"": 1.12,
      ""InfectionResistance"": 1.12
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      7
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.7,
      ""ScannerRechargeSpeed"": 1.35,
      ""SentryGunDamage"": 1.35,
      ""GlueEfficiency"": 1.35,
      ""TripMineDamage"": 1.35,
      ""ComputerProcessingSpeed"": 1.35,
      ""FogRepellerEffect"": 1.35,
      ""MeleeResistance"": 1.14,
      ""ProjectileResistance"": 1.14,
      ""InfectionResistance"": 1.14
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      8
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.8,
      ""ScannerRechargeSpeed"": 1.4,
      ""SentryGunDamage"": 1.4,
      ""GlueEfficiency"": 1.4,
      ""TripMineDamage"": 1.4,
      ""ComputerProcessingSpeed"": 1.4,
      ""FogRepellerEffect"": 1.4,
      ""MeleeResistance"": 1.16,
      ""ProjectileResistance"": 1.16,
      ""InfectionResistance"": 1.16
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      9
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 1.9,
      ""ScannerRechargeSpeed"": 1.45,
      ""SentryGunDamage"": 1.45,
      ""GlueEfficiency"": 1.45,
      ""TripMineDamage"": 1.45,
      ""ComputerProcessingSpeed"": 1.45,
      ""FogRepellerEffect"": 1.45,
      ""MeleeResistance"": 1.18,
      ""ProjectileResistance"": 1.18,
      ""InfectionResistance"": 1.18
    }
  },
  {
    ""ClassLayoutPersistentId"": 13,
    ""ActiveLevels"": [
      10
    ],
    ""ValueToBoosterEffects"": {
      ""HackingProficiency"": 2.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5,
      ""ComputerProcessingSpeed"": 1.5,
      ""FogRepellerEffect"": 1.5,
      ""MeleeResistance"": 1.2,
      ""ProjectileResistance"": 1.2,
      ""InfectionResistance"": 1.2
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      3
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      4
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 1.5,
      ""RegenerationSpeed"": 2.0,
      ""RegenerationCap"": 2.0
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      5
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 1.5,
      ""RegenerationSpeed"": 2.0,
      ""RegenerationCap"": 2.0,
      ""ComputerProcessingSpeed"": 999,
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      6
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 1.5,
      ""RegenerationSpeed"": 2.0,
      ""RegenerationCap"": 2.0,
      ""ComputerProcessingSpeed"": 999,
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      7
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 1.5,
      ""RegenerationSpeed"": 2.0,
      ""RegenerationCap"": 2.0,
      ""ComputerProcessingSpeed"": 999,
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5,
      ""BioscanSpeed"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      8
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 1.5,
      ""RegenerationSpeed"": 2.0,
      ""RegenerationCap"": 2.0,
      ""ComputerProcessingSpeed"": 999,
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5,
      ""BioscanSpeed"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      9
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 2.0,
      ""RegenerationSpeed"": 2.0,
      ""RegenerationCap"": 2.0,
      ""ComputerProcessingSpeed"": 999,
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5,
      ""BioscanSpeed"": 1.5
    }
  },
  {
    ""ClassLayoutPersistentId"": 14,
    ""ActiveLevels"": [
      10
    ],
    ""ValueToBoosterEffects"": {
      ""MeleeResistance"": 1.5,
      ""ProjectileResistance"": 1.5,
      ""InfectionResistance"": 2.0,
      ""RegenerationSpeed"": 3.5,
      ""RegenerationCap"": 2.0,
      ""ComputerProcessingSpeed"": 999,
      ""HackingProficiency"": 999.0,
      ""ScannerRechargeSpeed"": 1.5,
      ""SentryGunDamage"": 1.5,
      ""GlueEfficiency"": 1.5,
      ""TripMineDamage"": 1.5,
      ""BioscanSpeed"": 1.5
    }
  }
]
";

        public const string Groups = @"
[
  {
    ""PersistentId"": 0,
    ""VisibleForPlayerCount"": [
      1,
      2,
      3,
      4
    ],
    ""Name"": ""Combat""
  },
  {
    ""PersistentId"": 1,
    ""VisibleForPlayerCount"": [
      1,
      2,
      3,
      4
    ],
    ""Name"": ""Survival""
  },
  {
    ""PersistentId"": 2,
    ""VisibleForPlayerCount"": [
      1,
      2,
      3,
      4
    ],
    ""Name"": ""Utility""
  },
  {
    ""PersistentId"": 3,
    ""VisibleForPlayerCount"": [
      1
    ],
    ""Name"": ""Solo""
  }
]
";

        public const string ClassLayouts = @"
[
  {
    ""Header"": ""Generalist"",
    ""GroupPersistentId"": 2,
    ""PersistentId"": 13,
    ""InfoText"": ""Good at everything, best at nothing.\nMax LV 10 Bonus: Double Jump\n\nBonuses Each LV up:\n+2% Damage\n+2% Armor\n+2% Infection Resist\n+10% Hack Skill\n-5% Terminal Delay\n+5% Tool Power\n+5% Repeller Power\n2% Ammo Refill\n2% Tool Refill\n4% Heal\n1% Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 100% -> 102%\nArmor 100% -> 102%\nInfect Res. 0% -> 2%\nHacking 100% - > 110%\nTerminal Delay 100% -> 95%\nTool Power 100% -> 105%\nRepeller 100% -> 105%\nSpeed 100% -> 101%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.0,
        ""WeaponDamageMultiplier"": 1.0,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 300,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 102% -> 104%\nArmor 102% -> 104%\nInfect Res. 2% -> 4%\nHacking 110% - > 120%\nTerminal Delay 95% -> 90%\nTool Power 105% -> 110%\nRepeller 105% -> 110%\nSpeed 101% -> 102%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.02,
        ""WeaponDamageMultiplier"": 1.02,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.01
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 800,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 104% -> 106%\nArmor 104% -> 106%\nInfect Res. 4% -> 6%\nHacking 120% - > 130%\nTerminal Delay 90% -> 85%\nTool Power 110% -> 115%\nRepeller 110% -> 115%\nSpeed 102% -> 103%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.04,
        ""WeaponDamageMultiplier"": 1.04,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.02
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1450,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 106% -> 108%\nArmor 106% -> 108%\nInfect Res. 6% -> 8%\nHacking 130% - > 140%\nTerminal Delay 85% -> 80%\nTool Power 115% -> 120%\nRepeller 115% -> 120%\nSpeed 103% -> 104%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.06,
        ""WeaponDamageMultiplier"": 1.06,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.03
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 108% -> 110%\nArmor 108% -> 110%\nInfect Res. 8% -> 10%\nHacking 140% - > 150%\nTerminal Delay 80% -> 75%\nTool Power 120% > 125%\nRepeller 120% -> 125%\nSpeed 104% -> 105%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.08,
        ""WeaponDamageMultiplier"": 1.08,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.04
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 3025,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 110% -> 112%\nArmor 110% -> 112%\nInfect Res. 10% -> 12%\nHacking 150% -> 160%\nTerminal Delay 75% -> 70%\nTool Power 125% -> 130%\nRepeller 125% -> 130%\nSpeed 105% -> 106%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.1,
        ""WeaponDamageMultiplier"": 1.1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.05
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 3975,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 112% -> 114%\nArmor 112% -> 114%\nInfect Res. 12% -> 14%\nHacking 160% -> 170%\nTerminal Delay 70% -> 65%\nTool Power 130% -> 135%\nRepeller 130% -> 135%\nSpeed 106% -> 107%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.12,
        ""WeaponDamageMultiplier"": 1.12,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.06
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 5100,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 114% -> 116%\nArmor 114% -> 116%\nInfect Res. 14% -> 16%\nHacking 170% -> 180%\nTerminal Delay 65% -> 60%\nTool Power 135% -> 140%\nRepeller 135% -> 140%\nSpeed 107% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.14,
        ""WeaponDamageMultiplier"": 1.14,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.07
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 6300,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 116% -> 118%\nArmor 116% -> 118%\nInfect Res. 16% -> 18%\nHacking 180% -> 190%\nTerminal Delay 60% -> 55%\nTool Power 140% -> 145%\nRepeller 140% -> 145%\nSpeed 108% -> 109%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.16,
        ""WeaponDamageMultiplier"": 1.16,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.08
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 7575,
        ""CustomLevelUpPopupText"": ""Lv Up!\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 118% -> 120%\nArmor 118% -> 120%\nInfect Res. 18% -> 20%\nHacking 190% -> 200%\nTerminal Delay 55% -> 50%\nTool Power 145% -> 150%\nRepeller 145% -> 150%\nSpeed 109% -> 110%\nJump -> Double Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.18,
        ""WeaponDamageMultiplier"": 1.18,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.09
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 8925,
        ""CustomLevelUpPopupText"": ""MAX LV!\n+Double Jump\n2% Ammo Refill\n2% Tool Refill\n4% Heal"",
        ""CustomLevelStatsText"": ""Class: Generalist\n{0}\nDamage 120%\nArmor 120%\nInfect Res. 20%\nHacking 200%\nTerminal Delay 50%\nTool Power 150%\nRepeller 150%\nSpeed 110%\nDouble Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.2,
        ""WeaponDamageMultiplier"": 1.2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.1
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.02
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.02
          }
        ]
      }
    ]
  },
  {
    ""Header"": ""Soldier"",
    ""GroupPersistentId"": 0,
    ""PersistentId"": 2,
    ""InfoText"": ""Specialized in ranged combat. Stronger guns with ammo refunds on each level up.\nMax LV 10 bonus: +35% HP Regen Speed\n\nBonuses Each LV up:\n+4% Gun Damage\n+4% Ammo Refill\n\nBonus Each 5 LVs:\n+6% Ammo Refill"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 100% -> 104%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 100,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 104% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.04,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 108% -> 112%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.08,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 112% -> 116%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.12,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 1900,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 116% -> 120%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.16,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 2700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n10% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 120% -> 124%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.2,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.1
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 3600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 124% -> 128%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.24,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 4600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 128% -> 132%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.28,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 5700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 132% -> 136%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.32,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 6900,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +4%\n4% Ammo Refill"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 136% -> 140%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.36,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.04
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.04
          }
        ]
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 8200,
        ""CustomLevelUpPopupText"": ""MAX LV!\nGun Damage +4%\n10% Ammo Refill\nRegen Speed +35%"",
        ""CustomLevelStatsText"": ""Class: Soldier\n{0}\nGun Damage 140%\nRegen Speed 135%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.4,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.1
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.1
          }
        ]
      }
    ]
  },
  {
    ""Header"": ""Marine"",
    ""GroupPersistentId"": 0,
    ""PersistentId"": 9,
    ""InfoText"": ""Specialized in ranged combat. Powerful weapons but with poor Armor.\n<color=red>Starting Debuff: -40% Armor</color>\nMax LV 10\n\nBonuses Each LV up:\n+8% Gun Damage\n+3% Armor"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 100% -> 108%\nArmor 60% -> 63%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 85,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 108% -> 116%\nArmor 63% -> 66%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.08,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 510,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 116% -> 124%\nArmor 66% -> 69%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.16,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1020,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 124% -> 132%\nArmor 69% -> 72%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.24,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 1615,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 132% -> 140%\nArmor 72% -> 75%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.32,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 2295,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 140% -> 148%\nArmor 75% -> 78%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.4,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 3060,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 148% -> 156%\nArmor 78% -> 81%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.48,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 3910,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 156% -> 164%\nArmor 81% -> 84%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.56,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 4845,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 164% -> 172%\nArmor 84% -> 87%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.64,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 5865,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 172% -> 180%\nArmor 87% -> 90%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.72,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 6970,
        ""CustomLevelUpPopupText"": ""MAX LV!\nGun Damage +8%\nArmor +3%"",
        ""CustomLevelStatsText"": ""Class: Marine\n{0}\nGun Damage 180%\nArmor 90%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1.8,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Hunter"",
    ""GroupPersistentId"": 0,
    ""PersistentId"": 7,
    ""InfoText"": ""Specialized in melee combat. Deal high melee damage while gaining light Armor for survivability.\nMax LV 5 bonus: Double Jump\nLV 1 bonus: 125% Melee Damage\n\nBonuses Each LV up:\n+4% Armor\n+4% Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Hunter\n{0}\nMelee 100% -> 225%\nArmor 100% -> 104%\nSpeed 100% -> 104%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.0,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee +125%\nArmor +4%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Hunter\n{0}\nMelee 225%\nArmor 104% -> 108%\nSpeed 104% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2.25,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.04
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +4%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Hunter\n{0}\nMelee 225%\nArmor 108% -> 112%\nSpeed 108% -> 112%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2.25,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.08
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +4%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Hunter\n{0}\nMelee 225%\nArmor 112% -> 116%\nSpeed 112% -> 116%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2.25,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.2
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +4%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Hunter\n{0}\nMelee 225%\nArmor 116% -> 120%\nSpeed 116% -> 120%\nJump -> Double Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2.25,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.16
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 5650,
        ""CustomLevelUpPopupText"": ""MAX LV!\nArmor +4%\nSpeed +4%\n+Double Jump"",
        ""CustomLevelStatsText"": ""Class: Hunter\n{0}\nMelee 225%\nArmor 120%\nSpeed 120%\nDouble Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2.25,
        ""WeaponDamageMultiplier"": 1.0,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.2
          }
        ],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Assassin"",
    ""GroupPersistentId"": 0,
    ""PersistentId"": 8,
    ""InfoText"": ""Specialized in melee combat. Devastating in stealth and combat but with very poor survivability.\n<color=red>Starting Debuff: -45% Armor</color>\nMax LV 5 bonus: Double Jump\nLV 1 bonus: 215% Melee Damage\n\nBonuses Each LV up:\n+5% Armor\n+4% Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Assassin\n{0}\nMelee 100% -> 315%\nArmor 55% -> 60%\nSpeed 100% -> 104%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.0,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.0
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee +215%\nArmor +5%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Assassin\n{0}\nMelee 315%\nArmor 60% -> 65%\nSpeed 104% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 3.15,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.04
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +5%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Assassin\n{0}\nMelee 315%\nArmor 65% -> 70%\nSpeed 108% -> 112%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 3.15,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.08
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +5%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Assassin\n{0}\nMelee 315%\nArmor 70% -> 75%\nSpeed 112% -> 116%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 3.15,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.12
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +5%\nSpeed +4%"",
        ""CustomLevelStatsText"": ""Class: Assassin\n{0}\nMelee 315%\nArmor 75% -> 80%\nSpeed 116% -> 120%\nJump -> Double Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 3.15,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.16
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 5650,
        ""CustomLevelUpPopupText"": ""MAX LV!\nArmor +5%\nSpeed +4%\n+Double Jump"",
        ""CustomLevelStatsText"": ""Class: Assassin\n{0}\nMelee 315%\nArmor 80%\nSpeed 120%\nDouble Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 3.15,
        ""WeaponDamageMultiplier"": 1.0,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.2
          }
        ],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Fighter"",
    ""GroupPersistentId"": 0,
    ""PersistentId"": 10,
    ""InfoText"": ""Specialized in general combat. Improved damage with all guns and melee.\nMax LV 10\n\nBonuses Each LV up:\n+3% Gun Damage\n+6% Melee Damage\n+1% Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 100% -> 103%\nMelee Damage 100% -> 106%\nSpeed 100% -> 101%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 100,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +6%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 103% -> 106%\nMelee Damage 106% -> 112%\nSpeed 101% -> 102%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.06,
        ""WeaponDamageMultiplier"": 1.03,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.01
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 106% -> 109%\nMelee Damage 112% -> 118%\nSpeed 102% -> 103%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.12,
        ""WeaponDamageMultiplier"": 1.06,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.02
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 109% -> 112%\nMelee Damage 118% -> 124%\nSpeed 103% -> 104%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.18,
        ""WeaponDamageMultiplier"": 1.09,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.03
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 1900,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 112% -> 115%\nMelee Damage 124% -> 130%\nSpeed 104% -> 105%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.24,
        ""WeaponDamageMultiplier"": 1.12,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.04
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 2700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 115% -> 118%\nMelee Damage 130% -> 136%\nSpeed 105% -> 106%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.3,
        ""WeaponDamageMultiplier"": 1.15,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.05
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 3600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 118% -> 121%\nMelee Damage 136% -> 142%\nSpeed 106% -> 107%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.36,
        ""WeaponDamageMultiplier"": 1.18,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.06
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 4600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 121% -> 124%\nMelee Damage 142% -> 148%\nSpeed 107% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.42,
        ""WeaponDamageMultiplier"": 1.21,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.07
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 5700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 124% -> 127%\nMelee Damage 148% -> 154%\nSpeed 108% -> 109%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.48,
        ""WeaponDamageMultiplier"": 1.24,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.08
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 6900,
        ""CustomLevelUpPopupText"": ""Lv Up!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 127% -> 130%\nMelee Damage 154% -> 160%\nSpeed 109% -> 110%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.54,
        ""WeaponDamageMultiplier"": 1.27,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.09
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 8200,
        ""CustomLevelUpPopupText"": ""MAX LV!\nGun Damage +3%\nMelee Damage +7%\nSpeed +1%"",
        ""CustomLevelStatsText"": ""Class: Fighter\n{0}\nGun Damage 130%\nMelee Damage 160%\nSpeed 110%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1.6,
        ""WeaponDamageMultiplier"": 1.3,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.1
          }
        ],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Survivalist"",
    ""GroupPersistentId"": 1,
    ""PersistentId"": 3,
    ""InfoText"": ""Increased odds of survival in extreme conditions. Endure any scenario.\nMax LV 15 bonus: Infect Immune\n\nBonuses Each LV up:\n+3% Armor\n+3% Infect Resist\n10% Heal"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 100% -> 103%\nInfect Res. 0% -> 3%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 100,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 103% -> 106%\nInfect Res. 0% -> 3%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 106% -> 109%\nInfect Res. 3% -> 6%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 109% -> 112%\nInfect Res. 6% -> 9%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 1850,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 112% -> 115%\nInfect Res. 9% -> 12%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 2550,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n20% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 115% -> 118%\nInfect Res. 12% -> 15%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.2
          }
        ]
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 3300,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 118% -> 121%\nInfect Res. 15% -> 18%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 4100,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 121% -> 124%\nInfect Res. 18% -> 21%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 4950,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 124% -> 127%\nInfect Res. 21% -> 24%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 5850,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 127% -> 130%\nInfect Res. 24% -> 27%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 6850,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n20% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 130% -> 133%\nInfect Res. 27% -> 30%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.2
          }
        ]
      },
      {
        ""LevelNumber"": 11,
        ""TotalXpRequired"": 7950,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 133% -> 136%\nInfect Res. 30% -> 33%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 12,
        ""TotalXpRequired"": 9150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 136% -> 139%\nInfect Res. 33% -> 36%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 13,
        ""TotalXpRequired"": 10450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 139% -> 142%\nInfect Res. 36% -> 39%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 14,
        ""TotalXpRequired"": 11850,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +3%\nInfection Res. +3%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 142% -> 145%\nInfect Res. 39% -> Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 15,
        ""TotalXpRequired"": 13350,
        ""CustomLevelUpPopupText"": ""MAX LV!\nArmor +3%\nInfection Res. +61%\n20% Heal"",
        ""CustomLevelStatsText"": ""Class: Survivalist\n{0}\nArmor 145%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.2
          }
        ]
      }
    ]
  },
  {
    ""Header"": ""Outlander"",
    ""GroupPersistentId"": 1,
    ""PersistentId"": 11,
    ""InfoText"": ""Specialized for surviving on the run. Greatly improved Projectile Armor and Infect Resist.\nMax LV 15\nLV 1 bonus: Infect Immune\n\nBonuses Each LV up:\n+2% Melee Armor\n+5% Projectile Armor\n10% Heal"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 100% -> 102%\nProjectile Armor 100% -> 105%\nInfect Res. 0% -> Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 100,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 102% -> 104%\nProjectile Armor 105% -> 110%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 600,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 104% -> 106%\nProjectile Armor 110% -> 115%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 106% -> 108%\nProjectile Armor 115% -> 120%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 1850,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 108% -> 110%\nProjectile Armor 120% -> 125%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 2550,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n20% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 110% -> 112%\nProjectile Armor 125% -> 130%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.2
          }
        ]
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 3300,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 112% -> 114%\nProjectile Armor 130% -> 135%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 4100,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 114% -> 116%\nProjectile Armor 135% -> 140%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 4950,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 116% -> 118%\nProjectile Armor 140% -> 145%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 5850,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 118% -> 120%\nProjectile Armor 145% -> 150%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 6850,        
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n20% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 120% -> 122%\nProjectile Armor 150% -> 155%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.2
          }
        ]
      },
      {
        ""LevelNumber"": 11,
        ""TotalXpRequired"": 7950,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 122% -> 124%\nProjectile Armor 155% -> 160%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 12,
        ""TotalXpRequired"": 9150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 124% -> 126%\nProjectile Armor 160% -> 165%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 13,
        ""TotalXpRequired"": 10450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 126% -> 128%\nProjectile Armor 165% -> 170%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 14,
        ""TotalXpRequired"": 11850,
        ""CustomLevelUpPopupText"": ""Lv Up!\nMelee Armor +2%\nProjectile Armor +5%\n10% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 128% -> 130%\nProjectile Armor 170% -> 175%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.1
          }
        ]
      },
      {
        ""LevelNumber"": 15,
        ""TotalXpRequired"": 13350,
        ""CustomLevelUpPopupText"": ""MAX LV!\nMelee Armor +2%\nProjectile Armor +5%\n20% Heal"",
        ""CustomLevelStatsText"": ""Class: Outlander\n{0}\nMelee Armor 130%\nProjectile Armor 175%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.2
          }
        ]
      }
    ]
  },
  {
    ""Header"": ""Doctor"",
    ""GroupPersistentId"": 1,
    ""PersistentId"": 4,
    ""InfoText"": ""Specialized in keeping the team alive. Ensures that the team recovers quickly in bad scenarios.\nMax LV 5 bonus: +15% Armor\n\nBonuses Each LV up:\n+25% Revive Speed\n+35% HP Regen Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Doctor\n{0}\nRevive 4 -> 3.2 sec.\nRegen Speed 100% -> 135%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.8 sec.\nRegen Speed +35%"",
        ""CustomLevelStatsText"": ""Class: Doctor\n{0}\nRevive 3.2 -> 2.7 sec.\nRegen Speed 135% -> 170%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.5 sec.\nRegen Speed +35%"",
        ""CustomLevelStatsText"": ""Class: Doctor\n{0}\nRevive 2.7 -> 2.3 sec.\nRegen Speed 170% -> 205%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.4 sec.\nRegen Speed +35%"",
        ""CustomLevelStatsText"": ""Class: Doctor\n{0}\nRevive 2.3 -> 2 sec.\nRegen Speed 205% -> 240%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.3 sec.\nRegen Speed +35%"",
        ""CustomLevelStatsText"": ""Class: Doctor\n{0}\nRevive 2 -> 1.8 sec.\nRegen Speed 240% -> 275%\nArmor 100% -> 115%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 5650,
        ""CustomLevelUpPopupText"": ""MAX LV!\nRevive -0.2 sec.\nRegen Speed +35%\nArmor +15%"",
        ""CustomLevelStatsText"": ""Class: Doctor\n{0}\nRevive 1.8 sec.\nRegen Speed 275%\nArmor 115%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Field Medic"",
    ""GroupPersistentId"": 1,
    ""PersistentId"": 12,
    ""InfoText"": ""Specialized in keeping the team alive. Great survivability and team support.\nMax LV 5 Bonus: +50% Infect Resist\n\nBonuses Each LV up:\n+10% Revive Speed\n+35% HP Regen Speed\n+4% Armor\n+5% Infect Resist\n+2% Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Field Medic\n{0}\nRevive 4 -> 3.6 sec.\nRegen Speed 100% -> 135%\nArmor 100% -> 104%\nInfect Res. 0% -> 5%\nSpeed 100% -> 102%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.4 sec.\nRegen Speed +35%\nArmor +4%\nInfect Res. +5%\n+2% Speed"",
        ""CustomLevelStatsText"": ""Class: Field Medic\n{0}\nRevive 3.6 -> 3.3 sec.\nRegen Speed 135% -> 170%\nArmor 104% -> 108%\nInfect Res. 5% -> 10%\nSpeed 102% -> 104%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.02
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.3 sec.\nRegen Speed +35%\nArmor +4%\nInfect Res. +5%\n+2% Speed"",
        ""CustomLevelStatsText"": ""Class: Field Medic\n{0}\nRevive 3.3 -> 3 sec.\nRegen Speed 170% -> 205%\nArmor 108% -> 112%\nInfect Res. 10% -> 15%\nSpeed 104% -> 106%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.04
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.3 sec.\nRegen Speed +35%\nArmor +4%\nInfect Res. +5%\n+2% Speed"",
        ""CustomLevelStatsText"": ""Class: Field Medic\n{0}\nRevive 3 -> 2.8 sec.\nRegen Speed 205% -> 240%\nArmor 112% -> 116%\nInfect Res. 15% -> 20%\nSpeed 106% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.06
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRevive -0.2 sec.\nRegen Speed +35%\nArmor +4%\nInfect Res. +5%\n+2% Speed"",
        ""CustomLevelStatsText"": ""Class: Field Medic\n{0}\nRevive 2.8 -> 2.7 sec.\nRegen Speed 240% -> 275%\nArmor 116% -> 120%\nInfect Res. 20% -> 75%\nSpeed 108% -> 110%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.08
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 5650,
        ""CustomLevelUpPopupText"": ""MAX LV!\nRevive -0.1 sec.\nRegen Speed +35%\nArmor +4%\nInfect Res. +55%\n+2% Speed"",
        ""CustomLevelStatsText"": ""Class: Field Medic\n{0}\nRevive 2.7 sec.\nRegen Speed 275%\nArmor 120%\nInfect Res. 75%\nSpeed 110%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.1
          }
        ],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Trailblazer"",
    ""GroupPersistentId"": 1,
    ""PersistentId"": 15,
    ""InfoText"": ""Specialized in leaving everyone else in the dust. Superior mobility ensures survival when all else fails.\nMax LV 5 Bonus: Infect Immune, Double Jump\n\nBonuses Each LV up:\n+20% HP Regen Speed\n+8% Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Trailblazer\n{0}\nRegen Speed 100% -> 120%\nSpeed 100% -> 108%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRegen Speed +20%\n+8% Speed"",
        ""CustomLevelStatsText"": ""Class: Trailblazer\n{0}\nRegen Speed 120% -> 140%\nSpeed 108% -> 116%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.08
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRegen Speed +20%\n+8% Speed"",
        ""CustomLevelStatsText"": ""Class: Trailblazer\n{0}\nRegen Speed 140% -> 160%\nSpeed 116% -> 124%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.16
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRegen Speed +20%\n+8% Speed"",
        ""CustomLevelStatsText"": ""Class: Trailblazer\n{0}\nRegen Speed 160% -> 180%\nSpeed 124% -> 132%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.24
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRegen Speed +20%\n+8% Speed"",
        ""CustomLevelStatsText"": ""Class: Trailblazer\n{0}\nRegen Speed 180% -> 200%\nInfect Resist 0% -> Immune\nSpeed 132% -> 140%\nJump -> Double Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.32
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 5650,
        ""CustomLevelUpPopupText"": ""MAX LV!\nRegen Speed +20%\nInfect Immune\n+8% Speed\nDouble Jump"",
        ""CustomLevelStatsText"": ""Class: Trailblazer\n{0}\nRegen Speed 200%\nInfect Immune\nSpeed 140%\nDouble Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.4
          }
        ],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Technician"",
    ""GroupPersistentId"": 2,
    ""PersistentId"": 5,
    ""InfoText"": ""Specialized in supporting the team and resourcing. Keeps the team informed in more scenarios.\nMax LV 5 bonus: EZ Hack, Instant Terminals\n\nBonuses Each LV up:\n+55% Hack Skill\n-20% Terminal Delay\n+15% Tool Power\n+20% Repeller Power\n+8% Tool Refill"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Technician\n{0}\nHacking 100% - > 155%\nTerminal Delay 100% -> 80%\nTool Power 100% -> 115%\nRepeller 100% -> 120%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 400,
        ""CustomLevelUpPopupText"": ""Lv Up!\nHacking +35%\nTerminal Delay -15%\nTool Power +15%\nRepeller +20%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Technician\n{0}\nHacking 155% - > 210%\nTerminal Delay 80% -> 60%\nTool Power 115% -> 130%\nRepeller 120% -> 140%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1000,
        ""CustomLevelUpPopupText"": ""Lv Up!\nHacking +35%\nTerminal Delay -15%\nTool Power +15%\nRepeller +20%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Technician\n{0}\nHacking 210% - > 265%\nTerminal Delay 60% -> 40%\nTool Power 130% -> 145%\nRepeller 140% -> 160%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1800,
        ""CustomLevelUpPopupText"": ""Lv Up!\nHacking +35%\nTerminal Delay -15%\nTool Power +15%\nRepeller +20%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Technician\n{0}\nHacking 265% - > 320%\nTerminal Delay 40% -> 20%\nTool Power 145% -> 160%\nRepeller 160% -> 180%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 2800,
        ""CustomLevelUpPopupText"": ""Lv Up!\nHacking +35%\nTerminal Delay -15%\nTool Power +15%\nRepeller +20%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Technician\n{0}\nHacking 320% - > EZ\nTerminal Delay 20% -> Instant\nTool Power 160% > 175%\nRepeller 180% -> 200%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 4000,
        ""CustomLevelUpPopupText"": ""MAX LV!\nEZ Hacking\nInstant Terminal Delay\n+15% Tool Power\n+20% Repeller\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Technician\n{0}\nEZ Hacking\nInstant Terminals\nTool Power 175%\nRepeller 200%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      }
    ]
  },
  {
    ""Header"": ""Gas Breather"",
    ""GroupPersistentId"": 2,
    ""PersistentId"": 16,
    ""InfoText"": ""Specialized in traversing infectious environments. Utilizes heavily modified fog repellers to devastating effect.\nMax LV 5 bonus: Global Fog Repeller\nLV 1 bonus: Infect Immune\n\nBonuses Each LV up:\n+15% Tool Power\n+60% Repeller Power\n+8% Tool Refill"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Gas Breather\n{0}\nTool Power 100% -> 115%\nRepeller 100% -> 160%\nInfect Resist 0% -> Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 400,
        ""CustomLevelUpPopupText"": ""Lv Up!\nTool Power +15%\nRepeller +60%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Gas Breather\n{0}\nTool Power 115% -> 130%\nRepeller 160% -> 220%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1000,
        ""CustomLevelUpPopupText"": ""Lv Up!\nTool Power +15%\nRepeller +60%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Gas Breather\n{0}\nTool Power 130% -> 145%\nRepeller 220% -> 280%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1800,
        ""CustomLevelUpPopupText"": ""Lv Up!\nTool Power +15%\nRepeller +60%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Gas Breather\n{0}\nTool Power 145% -> 160%\nRepeller 280% -> 340%\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 2800,
        ""CustomLevelUpPopupText"": ""Lv Up!\nTool Power +15%\nRepeller +60%\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Gas Breather\n{0}\nTool Power 160% > 175%\nRepeller 340% -> Global\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 4000,
        ""CustomLevelUpPopupText"": ""MAX LV!\n+15% Tool Power\nGlobal Fog Repeller\n8% Tool Refill"",
        ""CustomLevelStatsText"": ""Class: Gas Breather\n{0}\nTool Power 175%\nGlobal Fog Repeller\nInfect Immune"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionTool"",
            ""Value"": 0.08
          }
        ]
      }
    ]
  },
  {
    ""Header"": ""Masochist"",
    ""GroupPersistentId"": 0,
    ""PersistentId"": 6,
    ""InfoText"": ""Specialized in suffering. Struggles for a long time, then becomes the strongest.\n<color=red>Starting Debuff: -50% Armor</color>\nMax LV 5 bonus: +80% Damage,\n+50% Max HP +50% Med Eff.\n\nBonuses Each LV up:\n-4% Armor\n+50% HP Regen Speed"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Masochist\n{0}\nArmor 50% -> 46%\nRegen Speed 100% -> 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 440,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor -4%\nRegen Speed +50%"",
        ""CustomLevelStatsText"": ""Class: Masochist\n{0}\nArmor 46% -> 42%\nRegen Speed 150% -> 200%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1100,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor -4%\nRegen Speed +50%"",
        ""CustomLevelStatsText"": ""Class: Masochist\n{0}\nArmor 42% -> 38%\nRegen Speed 200% -> 250%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 1980,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor -4%\nRegen Speed +50%"",
        ""CustomLevelStatsText"": ""Class: Masochist\n{0}\nArmor 38% -> 34%\nRegen Speed 250% -> 300%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3080,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor -4%\nRegen Speed +50%"",
        ""CustomLevelStatsText"": ""Class: Masochist\n{0}\nArmor 34% -> 30%\nRegen Speed 300% -> 0%\nDamage 100% -> 180%\nMax HP 20 -> 30\nMed Eff. 100% -> 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 4400,
        ""CustomLevelUpPopupText"": ""MAX LV!\nDamage +80%\nArmor -4%\n+10 Max HP\n+50% Med Eff."",
        ""CustomLevelStatsText"": ""Class: Masochist\n{0}\nArmor 30%\nDamage 180%\nMax HP +50%\nMed Eff. 150%"",
        ""HealthMultiplier"": 1.5,
        ""MeleeDamageMultiplier"": 1.8,
        ""WeaponDamageMultiplier"": 1.8,
        ""CustomScaling"": [],
        ""LevelUpBonus"": []
      }
    ]
  },
  {
    ""Header"": ""Isolated"",
    ""GroupPersistentId"": 3,
    ""PersistentId"": 14,
    ""InfoText"": ""You are the last alive. Stay alive at all costs and complete the mission.\nLV 5 & Max LV 10 bonus: +40% Ammo Refill, +40% Tool Refill, +40% Heal\n\nPerks Each Level:\nLV1: Speed Demon\nLV2: Damage Amp\nLV3: Endurance\nLV4: Regeneration\nLV5: Technician\nLV6: Double Jump\nLV7: +50% Bioscan Speed\nLV8: Speed Demon II\nLV9: Gas Breather\nLV10: Godlike Regeneration"",
    ""Levels"": [
      {
        ""LevelNumber"": 0,
        ""TotalXpRequired"": 0,
        ""CustomLevelUpPopupText"": null,
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 100% -> 115%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 1,
        ""TotalXpRequired"": 450,
        ""CustomLevelUpPopupText"": ""Lv Up!\nSpeed +15%"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115%\nDamage 100% -> 200%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 1,
        ""WeaponDamageMultiplier"": 1,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 2,
        ""TotalXpRequired"": 1150,
        ""CustomLevelUpPopupText"": ""Lv Up!\nDamage +100%"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115%\nDamage 200%\nArmor 100% -> 150%\nInfect Res. 0% -> 50%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 3,
        ""TotalXpRequired"": 2200,
        ""CustomLevelUpPopupText"": ""Lv Up!\nArmor +50%\nInfect Res. +50%"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115%\nDamage 200%\nArmor 150%\nInfect Res. 50%\nRegen Speed 100% -> 200%\nRegen Cap 25 -> 50"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 4,
        ""TotalXpRequired"": 3700,
        ""CustomLevelUpPopupText"": ""Lv Up!\nRegen Speed +100%\nRegen Cap +25"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115%\nDamage 200%\nArmor 150%\nInfect Res. 50%\nRegen Speed 200%\nRegen Cap 50\nTool Power 100% -> 150%\nHacking 100% -> EZ\nTerminal Delay 100% -> Instant"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 5,
        ""TotalXpRequired"": 5650,
        ""CustomLevelUpPopupText"": ""LV Up!\n+50% Tool Power\nEZ Hack\nInstant Terminals\n40% Ammo Refill\n40% Tool Refill\n40% Heal"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115%\nDamage 200%\nArmor 150%\nInfect Res. 50%\nRegen Speed 200%\nRegen Cap 50\nTool Power 150%\nEZ Hack\nInstant Terminals\nJump -> Double Jump"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.4
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.4
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.4
          }
        ]
      },
      {
        ""LevelNumber"": 6,
        ""TotalXpRequired"": 8050,
        ""CustomLevelUpPopupText"": ""LV Up!\n+Double Jump"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115%\nDamage 200%\nArmor 150%\nInfect Res. 50%\nRegen Speed 200%\nRegen Cap 50\nTool Power 150%\nEZ Hack\nInstant Terminals\nDouble Jump\nBioscan Speed 100% -> 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 7,
        ""TotalXpRequired"": 10450,
        ""CustomLevelUpPopupText"": ""LV Up!\n+50% Bioscan Speed"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 115% -> 130%\nDamage 200%\nArmor 150%\nInfect Res. 50%\nRegen Speed 200%\nRegen Cap 50\nTool Power 150%\nEZ Hack\nInstant Terminals\nDouble Jump\nBioscan Speed 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.15
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 8,
        ""TotalXpRequired"": 12850,
        ""CustomLevelUpPopupText"": ""LV Up!\n+15% Speed"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 130%\nDamage 200%\nArmor 150%\nInfect Res. 50% -> Immune\nRegen Speed 200%\nRegen Cap 50\nTool Power 150%\nEZ Hack\nInstant Terminals\nDouble Jump\nBioscan Speed 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.3
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 9,
        ""TotalXpRequired"": 15250,
        ""CustomLevelUpPopupText"": ""LV Up!\nInfect Immune"",
        ""CustomLevelStatsText"": ""Class: Isolated\n{0}\nSpeed 130%\nDamage 200%\nArmor 150%\nInfect Immune\nRegen Speed 200% -> 350%\nRegen Cap 50\nTool Power 150%\nEZ Hack\nInstant Terminals\nDouble Jump\nBioscan Speed 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.3
          }
        ],
        ""LevelUpBonus"": []
      },
      {
        ""LevelNumber"": 10,
        ""TotalXpRequired"": 17650,
        ""CustomLevelUpPopupText"": ""MAX LV!\nGodlike Regeneration\n40% Ammo Refill\n40% Tool Refill\n40% Heal"",
        ""CustomLevelStatsText"": ""Class: Legendary\n{0}\nSpeed 130%\nDamage 200%\nArmor 150%\nInfect Immune\nRegen Speed 350%\nRegen Cap 50\nTool Power 150%\nEZ Hack\nInstant Terminals\nDouble Jump\nBioscan Speed 150%"",
        ""HealthMultiplier"": 1,
        ""MeleeDamageMultiplier"": 2,
        ""WeaponDamageMultiplier"": 2,
        ""CustomScaling"": [
          {
            ""CustomBuff"": ""MovementSpeedMultiplier"",
            ""Value"": 1.3
          }
        ],
        ""LevelUpBonus"": [
          {
            ""SingleBuff"": ""AmmunitionMain"",
            ""Value"": 0.4
          },
          {
            ""SingleBuff"": ""AmmunitionSpecial"",
            ""Value"": 0.4
          },
          {
            ""SingleBuff"": ""Heal"",
            ""Value"": 0.4
          }
        ]
      }
    ]
  }
]
";
    }
}
