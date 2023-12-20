using MachinesManagementCentral.Shared.Domains;

namespace DeviceAPI.Endpoints
{
    public class Devices
    {
        public static void RegisterUserEndpoint(IEndpointRouteBuilder routes)
        {
            var devices = routes.MapGroup("device");

            devices.MapGet("/device", ()=> "Simple text from API");

            devices.MapGet("/devices", () => Collections.Devices.DeviceList);

            devices.MapGet("/devices/{DeviceId}", (int DeviceId) => Collections.Devices.DeviceList
            .FirstOrDefault(device=> device.DeviceId == DeviceId));

            devices.MapPost("/device/add", (MachinesManagementCentral.Shared.Domains.Device device) => Collections.Devices.DeviceList.Add(device));

            devices.MapPut("/device/edith/{DeviceId}", (int DeviceId, Device device) =>
            {
                Device currentDevice = Collections.Devices.DeviceList.FirstOrDefault(device => device.DeviceId == DeviceId);
                if (currentDevice != null)
                {
                    currentDevice.Location = device.Location;
                    currentDevice.Status = device.Status;
                    currentDevice.DeviceType = device.DeviceType;
                    currentDevice.Date = device.Date;
                    return Results.Ok("Device updated");
                }
                else
                {
                    return Results.Ok("Device not found");
                }
            });

            devices.MapDelete("/device/delete/{DeviceId}", (int DeviceId) =>
            { 
                var Device = Collections.Devices.DeviceList.FirstOrDefault(device => device.DeviceId == DeviceId);
                if (Device != null)
                {
                    Collections.Devices.DeviceList.Remove(Device);
                    return Results.Ok("Device removed");
                }
                else
                {
                    return Results.Ok("Device not found");
                }
            });
        }
    }
}
