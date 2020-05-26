﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Texnomic.SecureDNS.Core;
using Texnomic.SecureDNS.Serialization;

namespace Texnomic.SecureDNS.Tests.Core
{
    [TestClass]
    public class Serialization
    {
        [TestMethod]
        public void DeserializeFast()
        {
            //api.fast.com A Record
            var ResponseBytes = new byte[]
            {
                0xc8, 0xe8, 0x81, 0x80, 0x00, 0x01, 0x00, 0x05,
                0x00, 0x00, 0x00, 0x00, 0x03, 0x61, 0x70, 0x69,
                0x04, 0x66, 0x61, 0x73, 0x74, 0x03, 0x63, 0x6f,
                0x6d, 0x00, 0x00, 0x01, 0x00, 0x01, 0xc0, 0x0c,
                0x00, 0x05, 0x00, 0x01, 0x00, 0x00, 0x07, 0xef,
                0x00, 0x13, 0x04, 0x66, 0x61, 0x73, 0x74, 0x03,
                0x67, 0x65, 0x6f, 0x07, 0x6e, 0x65, 0x74, 0x66,
                0x6c, 0x69, 0x78, 0xc0, 0x15, 0xc0, 0x2a, 0x00,
                0x05, 0x00, 0x01, 0x00, 0x00, 0x01, 0x57, 0x00,
                0x18, 0x04, 0x66, 0x61, 0x73, 0x74, 0x09, 0x65,
                0x75, 0x2d, 0x77, 0x65, 0x73, 0x74, 0x2d, 0x31,
                0x06, 0x70, 0x72, 0x6f, 0x64, 0x61, 0x61, 0xc0,
                0x33, 0xc0, 0x49, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x2e, 0x00, 0x04, 0x34, 0x11, 0xb5,
                0xdc, 0xc0, 0x49, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x2e, 0x00, 0x04, 0x34, 0x12, 0xe8,
                0xb3, 0xc0, 0x49, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x2e, 0x00, 0x04, 0x36, 0x9a, 0xca,
                0x23
            };

            var ResponseMessage = DnSerializer.Deserialize<Message>(in ResponseBytes);
        }

        [TestMethod]
        public void SerializeFast()
        {
            //api.fast.com A Record
            var ResponseBytes = new byte[]
            {
                0xc8, 0xe8, 0x81, 0x80, 0x00, 0x01, 0x00, 0x05,
                0x00, 0x00, 0x00, 0x00, 0x03, 0x61, 0x70, 0x69,
                0x04, 0x66, 0x61, 0x73, 0x74, 0x03, 0x63, 0x6f,
                0x6d, 0x00, 0x00, 0x01, 0x00, 0x01, 0xc0, 0x0c,
                0x00, 0x05, 0x00, 0x01, 0x00, 0x00, 0x07, 0xef,
                0x00, 0x13, 0x04, 0x66, 0x61, 0x73, 0x74, 0x03,
                0x67, 0x65, 0x6f, 0x07, 0x6e, 0x65, 0x74, 0x66,
                0x6c, 0x69, 0x78, 0xc0, 0x15, 0xc0, 0x2a, 0x00,
                0x05, 0x00, 0x01, 0x00, 0x00, 0x01, 0x57, 0x00,
                0x18, 0x04, 0x66, 0x61, 0x73, 0x74, 0x09, 0x65,
                0x75, 0x2d, 0x77, 0x65, 0x73, 0x74, 0x2d, 0x31,
                0x06, 0x70, 0x72, 0x6f, 0x64, 0x61, 0x61, 0xc0,
                0x33, 0xc0, 0x49, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x2e, 0x00, 0x04, 0x34, 0x11, 0xb5,
                0xdc, 0xc0, 0x49, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x2e, 0x00, 0x04, 0x34, 0x12, 0xe8,
                0xb3, 0xc0, 0x49, 0x00, 0x01, 0x00, 0x01, 0x00,
                0x00, 0x00, 0x2e, 0x00, 0x04, 0x36, 0x9a, 0xca,
                0x23
            };

            var ResponseMessage = DnSerializer.Deserialize<Message>(in ResponseBytes);

            var Bytes = DnSerializer.Serialize(ResponseMessage);

            for (var I = 0; I < Bytes.Length; I++)
            {
                Assert.AreEqual(ResponseBytes[I], Bytes[I]);
            }

            var Size = DnSerializer.SizeOf(ResponseMessage);

            Assert.AreEqual(ResponseBytes.Length, Size);
        }

        [TestMethod]
        public void DeserializeYouTube()
        {
            //www.youtube.com A Record
            var ResponseBytes = new byte[]
            {
                0x1d, 0xce, 0x81, 0x80, 0x00, 0x01, 0x00, 0x08,
                0x00, 0x00, 0x00, 0x00, 0x03, 0x77, 0x77, 0x77,
                0x07, 0x79, 0x6f, 0x75, 0x74, 0x75, 0x62, 0x65,
                0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00,
                0x01, 0xc0, 0x0c, 0x00, 0x05, 0x00, 0x01, 0x00,
                0x00, 0x53, 0xdc, 0x00, 0x16, 0x0a, 0x79, 0x6f,
                0x75, 0x74, 0x75, 0x62, 0x65, 0x2d, 0x75, 0x69,
                0x01, 0x6c, 0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c,
                0x65, 0xc0, 0x18, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x13, 0x2e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x13, 0x8e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0xab, 0xce, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0xab, 0xee, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xd8,
                0x3a, 0xc6, 0x4e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x12, 0x2e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x12, 0xee
            };

            var ResponseMessage = DnSerializer.Deserialize<Message>(in ResponseBytes);
        }

        [TestMethod]
        public void SerializeYouTube()
        {
            //www.youtube.com A Record
            var ResponseBytes = new byte[]
            {
                0x1d, 0xce, 0x81, 0x80, 0x00, 0x01, 0x00, 0x08,
                0x00, 0x00, 0x00, 0x00, 0x03, 0x77, 0x77, 0x77,
                0x07, 0x79, 0x6f, 0x75, 0x74, 0x75, 0x62, 0x65,
                0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00,
                0x01, 0xc0, 0x0c, 0x00, 0x05, 0x00, 0x01, 0x00,
                0x00, 0x53, 0xdc, 0x00, 0x16, 0x0a, 0x79, 0x6f,
                0x75, 0x74, 0x75, 0x62, 0x65, 0x2d, 0x75, 0x69,
                0x01, 0x6c, 0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c,
                0x65, 0xc0, 0x18, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x13, 0x2e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x13, 0x8e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0xab, 0xce, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0xab, 0xee, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xd8,
                0x3a, 0xc6, 0x4e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x12, 0x2e, 0xc0, 0x2d, 0x00, 0x01, 0x00,
                0x01, 0x00, 0x00, 0x01, 0x11, 0x00, 0x04, 0xac,
                0xd9, 0x12, 0xee
            };

            var ResponseMessage = DnSerializer.Deserialize<Message>(in ResponseBytes);

            var Bytes = DnSerializer.Serialize(ResponseMessage);

            for (var I = 0; I < Bytes.Length; I++)
            {
                Assert.AreEqual(ResponseBytes[I], Bytes[I]);
            }

            var Size = DnSerializer.SizeOf(ResponseMessage);

            Assert.AreEqual(ResponseBytes.Length, Size);
        }
    }
}
