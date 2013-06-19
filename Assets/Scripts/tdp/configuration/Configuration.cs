using System.Collections.Generic;
using Assets.Scripts.tdp.constants;
using UnityEngine;

namespace Assets.Scripts.tdp.configuration {
    public static class Configuration {
        // Настройки экрана
        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;

        // Настройки игрового поля
        public static int LinesCount = 2;
        public static int TowerSlotsCount = 4;

        public static float FirstTowerSlotPositionX = -300;
        public static float FirstTowerSlotPositionY = 100;
        public static float TowerSlotWidth = 64;
        public static float TowerSlotHeight = 64;

        public static float FirstEnemyPositionX = 350;
        public static float FirstEnemyPositionY = 100;

        public static float FirstLinePositionX = 0;
        public static float FirstLinePositionY = 100;
        public static float CellWidth = 35;
        public static float LineHeight = 200;

        public static int CellsCount = 20;

        public static int LeftGameFieldBorderX = -350;
        public static int RightGameFieldBorderX = 350;

        // Настройки типов башен
        public static int TowerTypesCount = 3;
        public static Vector3 TowerSize = new Vector3(64, 64);

        public static Dictionary<TowerType, TowerConfiguration> Towers =
            new Dictionary<TowerType, TowerConfiguration> {
                {
                    TowerType.Type1,
                    new TowerConfiguration {
                        ShootsPerSecond = 1.0f,
                        Damage = 20,
                        AttackRange = 4,
                        SpriteFrame = new Rect(704, 134, 64, 64)
                    }
                },
                {
                    TowerType.Type2,
                    new TowerConfiguration {
                        ShootsPerSecond = 0.5f,
                        Damage = 50,
                        AttackRange = 3,
                        SpriteFrame = new Rect(704, 68, 64, 64)
                    }
                },
                {
                    TowerType.Type3,
                    new TowerConfiguration {
                        ShootsPerSecond = 0.25f,
                        Damage = 125,
                        AttackRange = 2,
                        SpriteFrame = new Rect(704, 2, 64, 64)
                    }
                }
            };

        // Настройки типов врагов
        public static int EnemyTypesCount = 3;
        public static Vector3 EnemySize = new Vector3(64, 64);
        public static float EnemyAppearsInterval = 3.0f;

        public static Dictionary<EnemyType, EnemyConfiguration> Enemies =
            new Dictionary<EnemyType, EnemyConfiguration> {
                {
                    EnemyType.Type1,
                    new EnemyConfiguration {
                        MaxHealth = 50,
                        Speed = 1.0f,
                        SpriteFrame = new Rect(770, 134, 64, 64)
                    }
                }, {
                    EnemyType.Type2,
                    new EnemyConfiguration {
                        MaxHealth = 100,
                        Speed = 0.5f,
                        SpriteFrame = new Rect(770, 68, 64, 64)
                    }
                }, {
                    EnemyType.Type3,
                    new EnemyConfiguration {
                        MaxHealth = 200,
                        Speed = 0.25f,
                        SpriteFrame = new Rect(770, 2, 64, 64)
                    }
                },
            };

        // Геймплей
        public static float SecondsToEndGame = 300.0f;
        public static int EnemiesPassesCountToLoose = 5;

        // Настройка снаряда
        public static Vector3 BulletSize = new Vector3(32, 32);
        public static float BulletMovementSpeed = 2.0f;

        // Графика
        public static Rect LineFrame = new Rect(2, 2, 700, 200);
        public static Rect BulletFrame = new Rect(2, 204, 32, 32);
    }
}