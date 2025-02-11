using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Processes images.
/// </summary>
class ImageProcessor
{
    /// <summary>
    /// Inverts the colors of the images.
    /// </summary>
    /// <param name="filenames"></param>
    public static void Inverse(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] invertedData = InvertColors(imageData);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_inverse{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, invertedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Inverts the colors of the images asynchronously.
    /// </summary>
    private byte[] InvertColors(byte[] imageData)
    {
        byte[] invertedData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;
            invertedData[x] ^= 0xFF;
            invertedData[x + 1] ^= 0xFF;
            invertedData[x + 2] ^= 0xFF;
            invertedData[x + 3] ^= 0xFF;
        }
        return invertedData;
    }
}
