﻿using MachinesManagementCentral.Client.Services;
using MachinesManagementCentral.Shared;
using MachinesManagementCentral.Shared.Domains;
using Microsoft.AspNetCore.Components;
namespace MachinesManagementCentral.Client.Components
{
    public partial class DeviceList
    {
       

        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;
        //public Device Device { get; set; }

        [Inject]
        public IDeviceDataService? DeviceDataService { get; set; }

        public List<Device> DeviceLst { get; set; } = new List<Device>();


        protected override void OnInitialized()
        {
            DeviceLst = DeviceDataService.GetDevices();

            base.OnInitialized();


           

        }



    }
}
