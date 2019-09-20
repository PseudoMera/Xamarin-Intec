using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PaintCopy.Services
{
    public interface IPhoto
    {
        Task<Stream> PickPhotoAsync();

        Task<bool> SavePhotoAsync(byte[] data, string folder, string filename);
    }
}
