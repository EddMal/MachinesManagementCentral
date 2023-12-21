using System.ComponentModel.DataAnnotations.Schema;

namespace MachinesManagementCentral.Client.Services
{
    public class Images
    {
        public string source = $"Images/pavilion.jpg";
        //    [NotMapped]
        //    public byte[]? ImageContent { get; set; }

        //    public string? ImageName { get; set; }

        //    public async Task AddImage()
        //    {
        //        if (selectedFile != null)
        //        {
        //            var file = selectedFile;
        //            Stream stream = file.OpenReadStream();
        //            MemoryStream ms = new MemoryStream();
        //            await stream.CopyToAsync(ms);
        //            stream.Close();

        //            ImageName = file.Name;
        //            ImageContent = ms.ToArray();
        //        }
        //    }

    }
}
