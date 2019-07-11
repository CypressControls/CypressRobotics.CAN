using System;
using System.Collections.Generic;
using System.Text;

namespace CypressRobotics.CAN
{
    public interface IReceiveCANMessages
    {
        byte Address { get; }

        void ReceiveMessage(CANMessage message);
    }
}
