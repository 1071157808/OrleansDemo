using DemoCluster.GrainInterfaces.States;

namespace DemoCluster.GrainInterfaces.Commands
{
    public class DeviceStatusCommand : DeviceCommand
    {
        public DeviceStatusCommand(int deviceStatusId, string name)
        {
            DeviceStateId = deviceStatusId;
            Name = name;
        }

        public int DeviceStateId { get; private set; }
        public string Name { get; private set; }
    }
}