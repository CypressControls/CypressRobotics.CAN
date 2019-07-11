using System;
using System.Collections.Generic;
using System.Text;

namespace CypressRobotics.CAN
{
    public delegate void CANMessageReceivedHandler(object sender, CANMessage e);

    public struct CANMessage
    {
        public uint ID;
        public byte[] Data;
        public byte DataLength;
        //TODO: we should have an error type as well

        public CANMessage(uint id, byte[] data, byte dataLength)
        {
            ID = id;
            Data = data;
            DataLength = dataLength;
        }


        public byte Sender { get => (byte)(ID & 0x000000FF); }
        public byte Target { get => (byte)((ID & 0x0000FF00) >> 8); }
        public byte MessageType { get => (byte)((ID & 0xFF000000) >> 24); }
    }
}
