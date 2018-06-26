using System.Threading.Tasks;
using DemoCluster.DAL.Models;
using Orleans;

namespace DemoCluster.GrainInterfaces
{
    public interface IDeviceWorkerGrain : IGrainWithGuidKey
    {
        Task<DeviceConfig> GetCurrentConfig();
        Task<bool> UpdateConfig(DeviceConfig config);
        Task<DeviceStateItem> GetCurrentStatus();
        Task<bool> UpdateCurrentStatus(DeviceStateItem state);
        Task Start();
        Task Stop();
    }
}