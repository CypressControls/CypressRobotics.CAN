using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypressRobotics.CAN
{
    public delegate void OnCANMessageReceivedHandler(object sender, CANMessage e);

    public interface ICanInterface
    {
        byte Address { get; set; }

        /// <summary>
        /// Initialize any supporting hardware
        /// </summary>
        /// <returns>True if initialization succeeded, otherwise false.</returns>
        bool Initialize();

        Task<bool> InitializeAsync();

        /// <summary>
        /// Send bytes synchronously via CAN.
        /// </summary>
        /// <param name="address">Address to send bytes to.</param>
        /// <param name="payload">Bytes to send. Maximum 8 bytes.</param>
        /// <returns>True if send appears to have succeeded, otherwise false.</returns>
        bool SendRawMessage(uint address, byte[] payload);

        bool SendBytes(byte target, byte[] payload, byte messageType = 0);

        bool SendMessage(CANMessage message);

        /// <summary>
        /// Synchronously read from CAN device. Will block until data is received.
        /// </summary>
        /// <returns>Bytes received from CAN.</returns>
        CANMessage ReceiveMessage();

        event OnCANMessageReceivedHandler OnCANMessageReceived;
    }
}
