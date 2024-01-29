using System.IO;

namespace Heinekamp.Application.Extensions
{
    public static class StreamExtensions
    {
        /// <summary>
        /// convert Stream to byte array
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            using var memoryStream = new MemoryStream();

            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
