using System;
using System.Numerics;

namespace SoulsMemory
{
    public class JunkCode
    {
        public static IntPtr BuildPointer(IntPtr BaseAddress, int[] Offsets)
        {
            IntPtr address = BaseAddress;

            for (int i = 0; i < Offsets.Length - 1; i++)
            {
                address = IntPtr.Add((IntPtr)Memory.ReadInt64(address), Offsets[i]);
                address = new IntPtr(Memory.ReadInt64(address));
            }

            address = IntPtr.Add((IntPtr)Memory.ReadInt64(address), Offsets[Offsets.Length - 1]);

            return address;
        }

        public static IntPtr BaseA()
        {
            var Base = new IntPtr(0x144768E78);
            return Base;
        }

        public static IntPtr BaseB()
        {
            var Base = new IntPtr(0x144768E78);
            return Base;
        }

        public static IntPtr BaseC()
        {
            var Base = new IntPtr(0x144743AB0);
            return Base;
        }

        public static IntPtr baseParam()
        {
            var Param = new IntPtr(0x7FF5A07E08C0);
            return Param;
        }

        public static IntPtr Param()
        {
            var Param = new IntPtr(0x144782838);
            return Param;
        }

        internal static IntPtr GetGameDataPtr()
        {
            var GetGameDataPtr_ = IntPtr.Add(Memory.BaseAddress, 0x4740178);
            GetGameDataPtr_ = new IntPtr(Memory.ReadInt64(GetGameDataPtr_));
            return GetGameDataPtr_;
        }

        internal static IntPtr GetPlayerParamPtr()
        {
            var PlayerParamPtr = GetGameDataPtr();

            PlayerParamPtr = IntPtr.Add(PlayerParamPtr, 0x10);
            PlayerParamPtr = new IntPtr(Memory.ReadInt64(PlayerParamPtr));
            return PlayerParamPtr;
        }

        public static void WriteAnimationId(int AnimId)
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x58);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x20);

            Memory.WriteInt32(Adress, AnimId);
        }

        public static int GetCurrentAnimationId()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x10);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x20);

            return Memory.ReadInt32(Adress);
        }

        public static int GetCurrentAnimationIdRE()
        {
            IntPtr baseAddress = BaseB();
            int[] offsets = { 0x80, 0x1F90, 0x10, 0x20 };

            IntPtr address = BuildPointer(baseAddress, offsets);

            return Memory.ReadInt32(address);
        }

        public static string GetCurrentAnimationString()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x28);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x898);

            return Memory.ReadString(Adress, 40, "UNICODE");
        }

        public static float GetCurrentAnimationTime()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x10);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x24);

            return Memory.ReadFloat(Adress);
        }

        public static float GetCurrentAnimationMaxTime()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x10);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x2C);

            return Memory.ReadFloat(Adress);
        }

        public static int GetCurrentAnriAnimation()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x580);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x8);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x0);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x58);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xC8);

            return Memory.ReadInt32(Adress);
        }

        public static void ShowErrorMessage(string Text)
        {
            var buffer = new byte[]
            {
                0x48, 0xB8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x48, 0x83, 0xEC, 0x48,
                0x48, 0x89, 0x44, 0x24, 0x30,
                0x48, 0x8D, 0x4C, 0x24, 0x30,
                0x49, 0xBE, 0x70, 0xBC, 0x75, 0x40, 0x01, 0x00, 0x00, 0x00,
                0x41, 0xFF, 0xD6,
                0x48, 0x83, 0xC4, 0x48,
                0xC3
            };

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(Text);

            Memory.ExecuteBufferFunction(buffer, bytes);
        }

        public static void DisconnectFunc(int PlayerSlot)
        {
            byte[] buffer =
            {
                0x48, 0xA1, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x4d, 0x31, 0xc0,
                0x41, 0xfe, 0xc0,
                0x48, 0xbb, 0xb0, 0x3a, 0x74, 0x44, 0x01, 0x00, 0x00, 0x00,
                0x48, 0x8b, 0x0b,
                0x48, 0x8b, 0x89, 0x60, 0x0c, 0x00, 0x00,
                0x48, 0x8b, 0xd0,
                0x48, 0x83, 0xec, 0x28,
                0x49, 0xbe, 0x64, 0x2a, 0x68, 0x40, 0x01, 0x00, 0x00, 0x00,
                0x41, 0xff, 0xd6,
                0x48, 0x83, 0xc4, 0x28,
                0xc3
            };

            int[] maxhp = JunkCode.GetOnlinePlayersMaxHP();
            int playerhandle = 0x10068001;

            if (PlayerSlot == 1)
            {
                playerhandle = 0x10068001;
            }

            if (PlayerSlot == 2)
            {
                playerhandle = 0x10068002;
            }

            if (PlayerSlot == 3)
            {
                playerhandle = 0x10068003;
            }

            if (PlayerSlot == 4)
            {
                playerhandle = 0x10068004;
            }

            if (PlayerSlot == 5)
            {
                playerhandle = 0x10068005;
                //10068005
            }

            byte[] bytes = BitConverter.GetBytes(playerhandle);

            Memory.ExecuteBufferFunction(buffer, bytes);
        }

        public static Vector3 BulletAhead(bool IsChrLocal, bool IsAngle, float Angle, Vector3 ChrLocal,
            double XOffsetPos, double ZOffsetPos, double Height)

        {
            if (IsChrLocal)
            {
                ChrLocal = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
            }

            if (IsAngle)
            {
                Angle = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosAngle();
            }

            double newXOffsetPos = Math.Cos(Angle) * XOffsetPos - Math.Sin(Angle) * -ZOffsetPos;
            double newZOffsetPos = Math.Sin(Angle) * XOffsetPos + Math.Cos(Angle) * -ZOffsetPos;

            XOffsetPos = -newXOffsetPos + ChrLocal.X;
            ZOffsetPos = newZOffsetPos + ChrLocal.Z;
            Vector3 NewBulletPos = new Vector3((float)XOffsetPos, ChrLocal.Y + (float)Height, (float)ZOffsetPos);

            return NewBulletPos;
        }

        public static int GetPlayerHandle()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x8);

            return Memory.ReadInt32(Adress);
        }

        public static Vector3[] GetOnlinePlayersPositions()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            Vector3[] Positions = new Vector3[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x18);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x28);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                var AdressPosX = IntPtr.Add(Adress, 0x80);
                var AdressPosY = IntPtr.Add(Adress, 0x84);
                var AdressPosZ = IntPtr.Add(Adress, 0x88);

                Positions[i] = new Vector3(Memory.ReadFloat(AdressPosX), Memory.ReadFloat(AdressPosY),
                    Memory.ReadFloat(AdressPosZ));
            }

            return Positions;
        }

        public static Vector3 GetOnlinePlayersPositions(int i)
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            Vector3 Positions = new Vector3(0, 0, 0);

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x28);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            var AdressPosX = IntPtr.Add(Adress, 0x80);
            var AdressPosY = IntPtr.Add(Adress, 0x84);
            var AdressPosZ = IntPtr.Add(Adress, 0x88);

            Positions = new Vector3(Memory.ReadFloat(AdressPosX), Memory.ReadFloat(AdressPosY),
                Memory.ReadFloat(AdressPosZ));


            return Positions;
        }


        public static float[] GetOnlinePlayersAngle()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            float[] Positions = new float[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x18);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x28);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x74);

                Positions[i] = Memory.ReadFloat(Adress);
            }

            return Positions;
        }

        public static string[] GetOnlinePlayersSteamID()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            string[] Names = new string[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x7D8);

                Names[i] = Memory.ReadString(Adress, 32, "UNICODE");
            }

            return Names;
        }

        public static int GetOnlinePlayerSteamID(int PlayerNo)
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int Names = 0;

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, PlayersOffsets[PlayerNo]);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1FA0);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x7D8);

            Names = Memory.ReadInt32(Adress);


            return Names;
        }

        public static string[] GetOnlinePlayersNames()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            string[] Names = new string[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x88);

                Names[i] = Memory.ReadUnicodeString(Adress, 64);
            }

            return Names;
        }

        public static int[,] GetOnlinePlayersWeapons()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] WeaponSlotsOffsets = { 0x330, 0x338, 0x340, 0x32C, 0x334, 0x33C };
            var Weapons = new int[5, 6];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                for (int Slot = 0; Slot < WeaponSlotsOffsets.Length; Slot++)
                {
                    var LastAdress = IntPtr.Add(Adress, WeaponSlotsOffsets[Slot]);
                    Weapons[i, Slot] = Memory.ReadInt32(LastAdress);
                }
            }

            return Weapons;
        }

        public static int[,] GetOnlinePlayersRings()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] RingsSlotsOffsets = { 0x370, 0x374, 0x378, 0x37C };
            var Rings = new int[5, 6];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                for (int Slot = 0; Slot < RingsSlotsOffsets.Length; Slot++)
                {
                    var LastAdress = IntPtr.Add(Adress, RingsSlotsOffsets[Slot]);
                    Rings[i, Slot] = Memory.ReadInt32(LastAdress);
                }
            }

            return Rings;
        }

        public static int[,] GetOnlinePlayersArmor()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] ArmorOffsets = { 0x35C, 0x360, 0x364, 0x368 };
            var Rings = new int[5, 6];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                for (int Slot = 0; Slot < ArmorOffsets.Length; Slot++)
                {
                    var LastAdress = IntPtr.Add(Adress, ArmorOffsets[Slot]);
                    Rings[i, Slot] = Memory.ReadInt32(LastAdress);
                }
            }

            return Rings;
        }

        public static int[] GetAllWeaponVariations(int WeaponId)
        {
            int[] WeaponInfusions =
                {0, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500};
            int[] WeaponReinforces = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var Weapons = new int[WeaponReinforces.Length * WeaponInfusions.Length];
            int BufferWeaponId = WeaponId;
            int BufferWeaponId2 = WeaponId;
            for (int reinforce = 0; reinforce < WeaponReinforces.Length; reinforce++)
            {
                BufferWeaponId = WeaponId;
                BufferWeaponId = BufferWeaponId + WeaponReinforces[reinforce];

                for (int infusion = 0; infusion < WeaponInfusions.Length; infusion++)
                {
                    BufferWeaponId2 = BufferWeaponId;
                    BufferWeaponId2 = BufferWeaponId2 + WeaponInfusions[infusion];
                    Weapons[reinforce * WeaponInfusions.Length + infusion] = BufferWeaponId2;
                }
            }

            return Weapons;
        }

        public static void GetBasicWeaponInfusionReinforce(int WeaponId, out int WeaponBase, out int WeaponReinforce,
            out int WeaponInfusion)
        {
            WeaponBase = (WeaponId / 10000) * 10000;
            WeaponReinforce = WeaponId % 100;
            WeaponInfusion = WeaponId % 10000 - WeaponReinforce;
        }

        public static void GetBasicWeaponInfusionReinforce1(int WeaponId, out int WeaponBase, out int WeaponReinforce)
        {
            WeaponBase = (WeaponId / 100) * 100;
            WeaponReinforce = WeaponId % 100;
        }

        public static int GetPlayerMaxHp()
        {
            int Health = 0;
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xDC);

            Health = Memory.ReadInt32(Adress);

            return Health;
        }

        public static int GetPlayerMaxFp()
        {
            int Fp = 0;
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xE0);

            Fp = Memory.ReadInt32(Adress);

            return Fp;
        }

        public static int GetPlayerHp()
        {
            int Health = 0;
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xD8);

            Health = Memory.ReadInt32(Adress);

            return Health;
        }

        public static int GetPlayerFp()
        {
            int Fp = 0;
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xE4);

            Fp = Memory.ReadInt32(Adress);

            return Fp;
        }

        public static void WritePlayerHp(int Health)
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xD8);

            Memory.WriteInt32(Adress, Health);
        }

        public static void WritePlayerFp(int Fp)
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1F90);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0xE4);

            Memory.WriteInt32(Adress, Fp);
        }

        public static int?[] GetOnlinePlayersHP()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int?[] Health = new int?[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x18);

                Health[i] = Memory.ReadInt32(Adress);
            }

            return Health;
        }

        public static int GetOnlinePlayersHP(int i)
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int Health;

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1FA0);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x18);

            Health = Memory.ReadInt32(Adress);

            return Health;
        }

        public static int[,] GetOnlinePlayersStats()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] StatsOffsets = { 0x44, 0x48, 0x4C, 0x6C, 0x50, 0x54, 0x58, 0x5C, 0x60 };
            int[,] Stats = new int[5, 9];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                for (int Slot = 0; Slot < StatsOffsets.Length; Slot++)
                {
                    var LastAdress = IntPtr.Add(Adress, StatsOffsets[Slot]);
                    Stats[i, Slot] = Memory.ReadInt32(LastAdress);
                }
            }

            return Stats;
        }

        public static bool[] StatChecker(int[,] PlayersStats, int[] PlayersSl)
        {
            var IsStatsMatch = new bool[5];
            for (var i = 0; i < 5; i++)
            {
                var StatsSumm = -89;
                IsStatsMatch[i] = true;

                if (PlayersSl[i] < 1 || PlayersSl[i] > 802)
                {
                    IsStatsMatch[i] = false;
                    continue;
                }

                var minLevels = new int[] { 9, 6, 9, 7, 7, 8, 7, 7, 7 };
                for (var j = 0; j < 9; j++)
                {
                    if (PlayersStats[i, j] >= minLevels[j] && PlayersStats[i, j] <= 99) StatsSumm += PlayersStats[i, j];
                    else
                    {
                        IsStatsMatch[i] = false;
                        break;
                    }
                }

                if (IsStatsMatch[i] && PlayersSl[i] != StatsSumm)
                    IsStatsMatch[i] = false;
            }

            return IsStatsMatch;
        }

        public static double SaveParam(int SpParamOffset, int ObjectOffset, int ParamOffset, string ValueType)
        {
            {
                double ParamValue = 0;
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(Param()), SpParamOffset);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x68);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x68);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, ObjectOffset + ParamOffset);

                if (ValueType == "Byte")
                    ParamValue = Memory.ReadInt8(Adress);

                if (ValueType == "2Byte")
                    ParamValue = Memory.ReadInt16(Adress);

                if (ValueType == "4Byte")
                    ParamValue = Memory.ReadInt32(Adress);

                if (ValueType == "Float")
                    ParamValue = Memory.ReadFloat(Adress);

                if (ValueType == "Double")
                    ParamValue = Memory.ReadDouble(Adress);

                return ParamValue;
            }
        }

        public enum ValueType : int
        {
            Byte = 0,
            Bytes2 = 1,
            Bytes4 = 2,
            Float = 3,
            Double = 4
        }

        public static void WriteParam(int SpParamOffset, int ObjectOffset, int ParamOffset, ValueType valueType,
            double Value)
        {
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(Param()), SpParamOffset);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x68);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x68);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, ObjectOffset + ParamOffset);

                if (valueType == ValueType.Byte)
                    Memory.WriteInt8(Adress, (byte)Value);

                if (valueType == ValueType.Bytes2)
                    Memory.WriteInt16(Adress, (short)Value);

                if (valueType == ValueType.Bytes4)
                    Memory.WriteInt32(Adress, (int)Value);

                if (valueType == ValueType.Float)
                    Memory.WriteFloat(Adress, (float)Value);

                if (valueType == ValueType.Double)
                    Memory.WriteDouble(Adress, Value);
            }
        }

        public static string GetLastBonfire()
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseC()), 0xACC);
            var BonfireID = Memory.ReadInt32(Adress);
            return BonfireID.ToString();
        }

        public static void SetLastBonfire(int BonfireID)
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseC()), 0xACC);
            Memory.WriteInt32(Adress, BonfireID);
        }

        public static int RealSl(int[,] PlayersStats, int playerNo)
        {
            int StatsSumm = -89;
            int Lvl = 0;

            for (var i = 0; i < 9; i++)
                StatsSumm += PlayersStats[playerNo, i];

            Lvl = StatsSumm;
            return Lvl;
        }

        public static bool[] BadMule(int[,] PlayersStats, int[] PlayersSl)
        {
            bool[] IsStatsMatch = new bool[5];
            //int[,] PlayerRings = GetOnlinePlayersRings();            
            for (int i = 0; i < 5; i++)
            {
                int StatsSumm = -89;
                int Lvl = 0;

                IsStatsMatch[i] = true;

                if (PlayersSl[i] < 1 || PlayersSl[i] > 802) //SoulLvL
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 0] < 9 || PlayersStats[i, 0] > 99) //Vgr
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 1] < 6 || PlayersStats[i, 0] > 99) //Att
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 2] < 9 || PlayersStats[i, 0] > 99) //End
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 3] < 7 || PlayersStats[i, 0] > 99) //Vit
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 4] < 7 || PlayersStats[i, 0] > 99) //Str
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 5] < 8 || PlayersStats[i, 0] > 99) //Dex
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 6] < 7 || PlayersStats[i, 0] > 99) //Int
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 7] < 7 || PlayersStats[i, 0] > 99) //Fth
                    IsStatsMatch[i] = false;

                if (PlayersStats[i, 8] < 7 || PlayersStats[i, 0] > 99) //Luck
                    IsStatsMatch[i] = false;

                if (IsStatsMatch[i])
                {
                    for (int j = 0; j < 9; j++)
                    {
                        StatsSumm = StatsSumm + PlayersStats[i, j];
                    }
                }


                if (PlayersSl[i] == StatsSumm + 1 || PlayersSl[i] == StatsSumm - 1)
                    IsStatsMatch[i] = false;
            }

            return IsStatsMatch;
        }


        public static int[] GetOnlinePlayersLvl()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] Lvl = new int[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x70);

                Lvl[i] = Memory.ReadInt32(Adress);
            }

            return Lvl;
        }


        public static int[] GetOnlinePlayersMaxHP()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] Health = new int[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1C);

                Health[i] = Memory.ReadInt32(Adress);
            }

            return Health;
        }

        public static int?[] GetOnlinePlayersAnimation()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int?[] AnimationsIds = new int?[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1F90);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x80);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0xC8);

                AnimationsIds[i] = Memory.ReadInt32(Adress);
            }

            return AnimationsIds;
        }

        public static string[] GetOnlinePlayersAnimationStrings()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            string[] AnimationsIds = new string[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1F90);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x28);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x898);


                AnimationsIds[i] = Memory.ReadString(Adress, 40, "UNICODE");
            }

            return AnimationsIds;
        }

        public static int?[] RandomAnimations()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int?[] AnimationsIds = new int?[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1F90);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x80);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0xC8);

                AnimationsIds[i] = Memory.ReadInt32(Adress);
            }

            return AnimationsIds;
        }

        public static int[] GetOnlinePlayersTeam()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] TeamIds = new int[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x74);

                TeamIds[i] = Memory.ReadInt32(Adress);
            }

            return TeamIds;
        }

        public static void KickPlayer(int PlayerNo)
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, PlayersOffsets[PlayerNo]);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x70);

            Memory.WriteInt32(Adress, 1);
        }

        public static int[] GetOnlinePlayersNo()
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int[] PlayersNo = new int[5];
            for (int i = 0; i < PlayersOffsets.Length; i++)
            {
                var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, PlayersOffsets[i]);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x1FA0);
                Adress = new IntPtr(Memory.ReadInt64(Adress));
                Adress = IntPtr.Add(Adress, 0x10);

                PlayersNo[i] = Memory.ReadInt32(Adress);
            }

            return PlayersNo;
        }

        public static int GetOnlinePlayerNo(int playerno)
        {
            int[] PlayersOffsets = { 0x38, 0x70, 0xA8, 0xE0, 0x118 };
            int PlayerNo = 0;

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x40);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, PlayersOffsets[playerno]);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x1FA0);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x10);

            PlayerNo = Memory.ReadInt32(Adress);

            return PlayerNo;
        }

        public static bool IsKeysPressed(int[] KeysList)
        {
            bool IsPressed = false;
            int KeysState = 0;
            if (KeysList[0] != 0)
            {
                for (int i = 0; i < KeysList.Length; i++)
                {
                    short[] state = new short[KeysList.Length];
                    state[i] = Kernel32.GetAsyncKeyState(KeysList[i]);
                    if (state[i] != 0)
                    {
                        KeysState++;
                    }
                    else if (state[i] == 0)
                    {
                        KeysState--;
                    }

                    if (KeysState == KeysList.Length)
                    {
                        IsPressed = true;
                    }
                }
            }

            return IsPressed;
        }

        public static int GetReversPlayerNo()
        {
            int PlayerNo = 0;

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseA()), 0x10);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x10);

            PlayerNo = Memory.ReadInt32(Adress);

            return PlayerNo;
        }

        public static int GetForwardPlayerNo()
        {
            int PlayerNo = 0;

            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x78);

            PlayerNo = Memory.ReadInt32(Adress);

            return PlayerNo;
        }

        public static void WriteReversPlayerNo(int PlayerNo)
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseA()), 0x10);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x10);

            Memory.WriteInt32(Adress, PlayerNo);
        }

        public static void WriteForwardPlayerNo(int PlayerNo)
        {
            var Adress = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseB()), 0x80);
            Adress = new IntPtr(Memory.ReadInt64(Adress));
            Adress = IntPtr.Add(Adress, 0x78);

            Memory.WriteInt32(Adress, PlayerNo);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static IntPtr BulletParam(int Offset)
        {
            var Param = baseParam();
            var BulletParam = IntPtr.Add((IntPtr)Memory.ReadInt64(Param), 0x388);
            BulletParam = new IntPtr(Memory.ReadInt64(BulletParam));
            BulletParam = IntPtr.Add(BulletParam, 0x68);
            BulletParam = new IntPtr(Memory.ReadInt64(BulletParam));
            BulletParam = IntPtr.Add(BulletParam, 0x68);
            BulletParam = new IntPtr(Memory.ReadInt64(BulletParam));
            BulletParam = IntPtr.Add(BulletParam, Offset); //Адрес буллета

            return BulletParam;
        }

        public static bool GetEmberState()
        {
            var PlayerParamPtr = GetPlayerParamPtr();

            PlayerParamPtr = IntPtr.Add(PlayerParamPtr, 0x100);
            return Memory.ReadBoolean(PlayerParamPtr);
        }

        public static void SetEmberState(bool state)
        {
            var PlayerParamPtr = GetPlayerParamPtr();

            Memory.WriteBoolean(PlayerParamPtr + 0x100, state);
        }

        public static void SetPlayerCount(int value)
        {
            var PlayersCount = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseC()), 0xD38);
            Memory.WriteInt32(PlayersCount, value);
        }

        public static int GetPlayerCount()
        {
            var PlayersCount = IntPtr.Add((IntPtr)Memory.ReadInt64(BaseC()), 0xD3C);
            return Memory.ReadInt32(PlayersCount);
        }
    }
}