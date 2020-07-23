using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SoulsMemory
{
    public class BULLET_MAN
    {
        public static void GenerateBullet(int bulletId, bool IsSendNetMessage, Vector3 Pos)
        {
            var buffer = new byte[]
            {
                0x48, 0xBA, 0, 0, 0, 0, 0, 0, 0, 0, //mov rdx,Alloc
                0x48, 0xA1, 0x78, 0x2D, 0x77, 0x44, 0x01, 0x00, 0x00, 0x00, //mov rax,[144772D78]
                0x48, 0x8B, 0xC8, //mov rcx,rax
                0x4C, 0x8B, 0xC2, //mov r8d,rdx
                0x49, 0x83, 0xC0, 0x30, //add r8,30
                0x49, 0xBE, 0x00, 0x85, 0x97, 0x40, 0x01, 0x00, 0x00, 0x00,  //mov r14,0000000140978500
                0x48, 0x83, 0xEC, 0x58, //sub rsp,58
                0x41, 0xFF, 0xD6, //call r14
                0x48, 0x83, 0xC4, 0x58, //add rsp,58
                0xC3 //ret
            };

            int SpawnHandle = JunkCode.GetPlayerHandle();
            int magicId = 0;
            int goodsParamId = 0;
            int DummyPointId = 0;
            int TargetHandle = 0;
            bool isIgnoreSpawnHandle = false;
            bool isUseAutotarget = false;
            Vector3 AngleX = new Vector3(0, 0, 0);
            Vector3 AngleY = new Vector3(0, 0, 0);
            Vector3 AngleZ = new Vector3(0, 0, 0);



            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];

            Memory.ExecuteBufferFunction(buffer, ExtraArgument);
        }

        public static void GenerateBullet(int bulletId, bool IsSendNetMessage, Vector3 Pos, Vector3 AngleZ)
        {
            var buffer = new byte[]
            {
                0x48, 0xBA, 0, 0, 0, 0, 0, 0, 0, 0, //mov rdx,Alloc
                0x48, 0xA1, 0x78, 0x2D, 0x77, 0x44, 0x01, 0x00, 0x00, 0x00, //mov rax,[144772D78]
                0x48, 0x8B, 0xC8, //mov rcx,rax
                0x4C, 0x8B, 0xC2, //mov r8d,rdx
                0x49, 0x83, 0xC0, 0x30, //add r8,30
                0x49, 0xBE, 0x00, 0x85, 0x97, 0x40, 0x01, 0x00, 0x00, 0x00,  //mov r14,0000000140978500
                0x48, 0x83, 0xEC, 0x58, //sub rsp,58
                0x41, 0xFF, 0xD6, //call r14
                0x48, 0x83, 0xC4, 0x58, //add rsp,58
                0xC3 //ret
            };

            int SpawnHandle = JunkCode.GetPlayerHandle();
            int magicId = 0;
            int goodsParamId = 0;
            int DummyPointId = 0;
            int TargetHandle = 0;
            bool isIgnoreSpawnHandle = false;
            bool isUseAutotarget = false;
            Vector3 AngleX = new Vector3(0, 0, 0);
            Vector3 AngleY = new Vector3(0, 0, 0);


            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];

            Memory.ExecuteBufferFunction(buffer, ExtraArgument);
        }

        public static void GenerateBullet(int bulletId, bool IsSendNetMessage)
        {
            var buffer = new byte[]
            {
                0x48, 0xBA, 0, 0, 0, 0, 0, 0, 0, 0, //mov rdx,Alloc
                0x48, 0xA1, 0x78, 0x2D, 0x77, 0x44, 0x01, 0x00, 0x00, 0x00, //mov rax,[144772D78]
                0x48, 0x8B, 0xC8, //mov rcx,rax
                0x4C, 0x8B, 0xC2, //mov r8d,rdx
                0x49, 0x83, 0xC0, 0x30, //add r8,30
                0x49, 0xBE, 0x00, 0x85, 0x97, 0x40, 0x01, 0x00, 0x00, 0x00,  //mov r14,0000000140978500
                0x48, 0x83, 0xEC, 0x58, //sub rsp,58
                0x41, 0xFF, 0xD6, //call r14
                0x48, 0x83, 0xC4, 0x58, //add rsp,58
                0xC3 //ret
            };

            int SpawnHandle = JunkCode.GetPlayerHandle();
            int magicId = 0;
            int goodsParamId = 0;
            int DummyPointId = 0;
            int TargetHandle = 0;
            bool isIgnoreSpawnHandle = false;
            bool isUseAutotarget = false;
            Vector3 AngleX = new Vector3(0, 0, 0);
            Vector3 AngleY = new Vector3(0, 0, 0);
            Vector3 Pos = new Vector3(0, 0, 0);
            Vector3 AngleZ = new Vector3(0, 0, 0);



            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];

            Memory.ExecuteBufferFunction(buffer, ExtraArgument);
        }

        public static void GenerateBullet(int SpawnHandle, int magicId, int bulletId, int goodsParamId, int DummyPointId, int TargetHandle, bool isIgnoreSpawnHandle, bool isUseAutotarget, bool IsSendNetMessage, Vector3 Pos, Vector3 AngleX, Vector3 AngleY, Vector3 AngleZ)
        {
            var buffer = new byte[]
            {
                0x48, 0xBA, 0, 0, 0, 0, 0, 0, 0, 0, //mov rdx,Alloc
                0x48, 0xA1, 0x78, 0x2D, 0x77, 0x44, 0x01, 0x00, 0x00, 0x00, //mov rax,[144772D78]
                0x48, 0x8B, 0xC8, //mov rcx,rax
                0x4C, 0x8B, 0xC2, //mov r8d,rdx
                0x49, 0x83, 0xC0, 0x30, //add r8,30
                0x49, 0xBE, 0x00, 0x85, 0x97, 0x40, 0x01, 0x00, 0x00, 0x00,  //mov r14,0000000140978500
                0x48, 0x83, 0xEC, 0x58, //sub rsp,58
                0x41, 0xFF, 0xD6, //call r14
                0x48, 0x83, 0xC4, 0x58, //add rsp,58
                0xC3 //ret
            };

            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];

            Memory.ExecuteBufferFunction(buffer, ExtraArgument);
        }
    }

    public class GenerateBullet
    {
        Memory.ExecuteBufferFunctionStatic BulletSpawn = new Memory.ExecuteBufferFunctionStatic();

        public int SpawnHandle { get; set; }
        public int magicId { get; set; }
        public int bulletId { get; set; }
        public int goodsParamId { get; set; }
        public int DummyPointId { get; set; }
        public int TargetHandle { get; set; }
        public bool isIgnoreSpawnHandle { get; set; }
        public bool isUseAutotarget { get; set; }
        public bool IsSendNetMessage { get; set; }
        public Vector3 Pos { get; set; }
        public Vector3 AngleX { get; set; }
        public Vector3 AngleY { get; set; }
        public Vector3 AngleZ { get; set; }

        public GenerateBullet(int SpawnHandle, int magicId, int bulletId, int goodsParamId, int DummyPointId, int TargetHandle, bool isIgnoreSpawnHandle, bool isUseAutotarget, bool IsSendNetMessage, Vector3 Pos, Vector3 AngleX, Vector3 AngleY, Vector3 AngleZ)
        {
            this.SpawnHandle = SpawnHandle;
            this.magicId = magicId;
            this.bulletId = bulletId;
            this.goodsParamId = goodsParamId;
            this.DummyPointId = DummyPointId;
            this.TargetHandle = TargetHandle;
            this.isIgnoreSpawnHandle = isIgnoreSpawnHandle;
            this.isUseAutotarget = isUseAutotarget;
            this.IsSendNetMessage = IsSendNetMessage;
            this.Pos = Pos;
            this.AngleX = AngleX;
            this.AngleY = AngleY;
            this.AngleZ = AngleZ;

            var buffer = new byte[]
            {
                0x48, 0xBA, 0, 0, 0, 0, 0, 0, 0, 0, //mov rdx,Alloc
                0x48, 0xA1, 0x78, 0x2D, 0x77, 0x44, 0x01, 0x00, 0x00, 0x00, //mov rax,[144772D78]
                0x48, 0x8B, 0xC8, //mov rcx,rax
                0x4C, 0x8B, 0xC2, //mov r8d,rdx
                0x49, 0x83, 0xC0, 0x30, //add r8,30
                0x49, 0xBE, 0x00, 0x85, 0x97, 0x40, 0x01, 0x00, 0x00, 0x00,  //mov r14,0000000140978500
                0x48, 0x83, 0xEC, 0x58, //sub rsp,58
                0x41, 0xFF, 0xD6, //call r14
                0x48, 0x83, 0xC4, 0x58, //add rsp,58
                0xC3 //ret
            };

            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];

            BulletSpawn.WriteFunction(buffer, ExtraArgument, 0x100, 0x100);
        }

        public void SpawnBullet()
        {
            BulletSpawn.StartThread();
        }

        public void Disable()
        {
            BulletSpawn.FreeMemory();
        }

        public void SetAllArguments(int SpawnHandle, int magicId, int bulletId, int goodsParamId, int DummyPointId, int TargetHandle, bool isIgnoreSpawnHandle, bool isUseAutotarget, bool IsSendNetMessage, Vector3 Pos, Vector3 AngleX, Vector3 AngleY, Vector3 AngleZ)
        {
            #region PackArguments
            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];
            #endregion

            this.SpawnHandle = SpawnHandle;
            this.magicId = magicId;
            this.bulletId = bulletId;
            this.goodsParamId = goodsParamId;
            this.DummyPointId = DummyPointId;
            this.TargetHandle = TargetHandle;
            this.isIgnoreSpawnHandle = isIgnoreSpawnHandle;
            this.isUseAutotarget = isUseAutotarget;
            this.IsSendNetMessage = IsSendNetMessage;
            this.Pos = Pos;
            this.AngleX = AngleX;
            this.AngleY = AngleY;
            this.AngleZ = AngleZ;
            Memory.WriteBytes(BulletSpawn.BufferAddress, ExtraArgument);
        }

        public void SetBulletId(int bulletId)
        {
            #region PackArguments
            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];
            #endregion

            this.bulletId = bulletId;
            Memory.WriteBytes(BulletSpawn.BufferAddress, ExtraArgument);
        }

        public void SetPos(Vector3 Pos)
        {
            #region PackArguments
            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];
            #endregion

            this.Pos = Pos;
            Memory.WriteBytes(BulletSpawn.BufferAddress, ExtraArgument);
        }

        public void SetAngleZ(Vector3 AngleZ)
        {
            #region PackArguments
            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];
            #endregion

            this.AngleZ = AngleZ;
            Memory.WriteBytes(BulletSpawn.BufferAddress, ExtraArgument);
        }

        public void SetSpawnHandle(int SpawnHandle)
        {
            #region PackArguments
            var ExtraArgument = new byte[0x100];

            byte[] Bytes = new byte[4];

            Bytes = BitConverter.GetBytes(SpawnHandle);

            ExtraArgument[0x30] = Bytes[0];
            ExtraArgument[0x31] = Bytes[1];
            ExtraArgument[0x32] = Bytes[2];
            ExtraArgument[0x33] = Bytes[3];

            Bytes = BitConverter.GetBytes(magicId);

            ExtraArgument[0x38] = Bytes[0];
            ExtraArgument[0x39] = Bytes[1];
            ExtraArgument[0x3A] = Bytes[2];
            ExtraArgument[0x3B] = Bytes[3];

            Bytes = BitConverter.GetBytes(bulletId);

            ExtraArgument[0x40] = Bytes[0];
            ExtraArgument[0x41] = Bytes[1];
            ExtraArgument[0x42] = Bytes[2];
            ExtraArgument[0x43] = Bytes[3];

            Bytes = BitConverter.GetBytes(goodsParamId);

            ExtraArgument[0x44] = Bytes[0];
            ExtraArgument[0x45] = Bytes[1];
            ExtraArgument[0x46] = Bytes[2];
            ExtraArgument[0x47] = Bytes[3];

            Bytes = BitConverter.GetBytes(DummyPointId);

            ExtraArgument[0x48] = Bytes[0];
            ExtraArgument[0x49] = Bytes[1];
            ExtraArgument[0x4A] = Bytes[2];
            ExtraArgument[0x4B] = Bytes[3];

            var BoolTest = Convert.ToByte(isIgnoreSpawnHandle);
            var BoolTest2 = 2 * BoolTest;

            BoolTest = Convert.ToByte(isUseAutotarget);
            var BoolTest3 = 16 * BoolTest;

            BoolTest = Convert.ToByte(IsSendNetMessage);
            var BoolTest4 = 8 * BoolTest;

            BoolTest3 = BoolTest3 + BoolTest2 + BoolTest4;

            ExtraArgument[0x6C] = (byte)BoolTest3;

            Bytes = BitConverter.GetBytes(TargetHandle);

            Bytes = BitConverter.GetBytes(TargetHandle);

            ExtraArgument[0x4C] = Bytes[0];
            ExtraArgument[0x4D] = Bytes[1];
            ExtraArgument[0x4E] = Bytes[2];
            ExtraArgument[0x4F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.X);

            ExtraArgument[0x7C] = Bytes[0];
            ExtraArgument[0x7D] = Bytes[1];
            ExtraArgument[0x7E] = Bytes[2];
            ExtraArgument[0x7F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Y);

            ExtraArgument[0x8C] = Bytes[0];
            ExtraArgument[0x8D] = Bytes[1];
            ExtraArgument[0x8E] = Bytes[2];
            ExtraArgument[0x8F] = Bytes[3];

            Bytes = BitConverter.GetBytes(Pos.Z);

            ExtraArgument[0x9C] = Bytes[0];
            ExtraArgument[0x9D] = Bytes[1];
            ExtraArgument[0x9E] = Bytes[2];
            ExtraArgument[0x9F] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.X);

            ExtraArgument[0x70] = Bytes[0];
            ExtraArgument[0x71] = Bytes[1];
            ExtraArgument[0x72] = Bytes[2];
            ExtraArgument[0x73] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Y);

            ExtraArgument[0x80] = Bytes[0];
            ExtraArgument[0x81] = Bytes[1];
            ExtraArgument[0x82] = Bytes[2];
            ExtraArgument[0x83] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleX.Z);

            ExtraArgument[0x90] = Bytes[0];
            ExtraArgument[0x91] = Bytes[1];
            ExtraArgument[0x92] = Bytes[2];
            ExtraArgument[0x93] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.X);

            ExtraArgument[0x74] = Bytes[0];
            ExtraArgument[0x75] = Bytes[1];
            ExtraArgument[0x76] = Bytes[2];
            ExtraArgument[0x77] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Y);

            ExtraArgument[0x84] = Bytes[0];
            ExtraArgument[0x85] = Bytes[1];
            ExtraArgument[0x86] = Bytes[2];
            ExtraArgument[0x87] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleY.Z);

            ExtraArgument[0x94] = Bytes[0];
            ExtraArgument[0x95] = Bytes[1];
            ExtraArgument[0x96] = Bytes[2];
            ExtraArgument[0x97] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.X);

            ExtraArgument[0x78] = Bytes[0];
            ExtraArgument[0x79] = Bytes[1];
            ExtraArgument[0x7A] = Bytes[2];
            ExtraArgument[0x7B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Y);

            ExtraArgument[0x88] = Bytes[0];
            ExtraArgument[0x89] = Bytes[1];
            ExtraArgument[0x8A] = Bytes[2];
            ExtraArgument[0x8B] = Bytes[3];

            Bytes = BitConverter.GetBytes(AngleZ.Z);

            ExtraArgument[0x98] = Bytes[0];
            ExtraArgument[0x99] = Bytes[1];
            ExtraArgument[0x9A] = Bytes[2];
            ExtraArgument[0x9B] = Bytes[3];

            //Unknown
            Bytes = BitConverter.GetBytes(0xFFFFFFFF);

            ExtraArgument[0x34] = Bytes[0];
            ExtraArgument[0x35] = Bytes[1];
            ExtraArgument[0x36] = Bytes[2];
            ExtraArgument[0x37] = Bytes[3];

            ExtraArgument[0x50] = Bytes[0];
            ExtraArgument[0x51] = Bytes[1];
            ExtraArgument[0x52] = Bytes[2];
            ExtraArgument[0x53] = Bytes[3];

            ExtraArgument[0x54] = Bytes[0];
            ExtraArgument[0x55] = Bytes[1];
            ExtraArgument[0x56] = Bytes[2];
            ExtraArgument[0x57] = Bytes[3];

            Bytes = BitConverter.GetBytes((float)1.0);

            ExtraArgument[0x58] = Bytes[0];
            ExtraArgument[0x59] = Bytes[1];
            ExtraArgument[0x5A] = Bytes[2];
            ExtraArgument[0x5B] = Bytes[3];

            ExtraArgument[0x5C] = Bytes[0];
            ExtraArgument[0x5D] = Bytes[1];
            ExtraArgument[0x5E] = Bytes[2];
            ExtraArgument[0x5F] = Bytes[3];

            ExtraArgument[0x60] = Bytes[0];
            ExtraArgument[0x61] = Bytes[1];
            ExtraArgument[0x62] = Bytes[2];
            ExtraArgument[0x63] = Bytes[3];

            ExtraArgument[0x64] = Bytes[0];
            ExtraArgument[0x65] = Bytes[1];
            ExtraArgument[0x66] = Bytes[2];
            ExtraArgument[0x67] = Bytes[3];
            #endregion

            this.SpawnHandle = SpawnHandle;
            Memory.WriteBytes(BulletSpawn.BufferAddress, ExtraArgument);
        }
    }
}
