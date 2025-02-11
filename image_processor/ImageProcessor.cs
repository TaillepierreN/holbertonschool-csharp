using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


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
    private static byte[] InvertColors(byte[] imageData)
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

    /// <summary>
    /// Converts each image to grayscale.
    /// </summary>
    /// <param name="filenames"></param>
    public static void Grayscale(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] grayscaleData = ConvertToGrayscale(imageData);

                string outputFilename = $"{GetFileNameWithoutExtension(filename)}_grayscale{GetFileExtension(filename)}";
                File.WriteAllBytes(outputFilename, grayscaleData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    private static byte[] ConvertToGrayscale(byte[] imageData)
    {
        int rgbBytesPerPixel = 3;
        int stride = imageData.Length / rgbBytesPerPixel;
        byte[] grayscaleData = new byte[imageData.Length];

        for (int i = 0; i < imageData.Length; i += rgbBytesPerPixel)
        {
            if (i + rgbBytesPerPixel <= imageData.Length)
            {
                byte gray = (byte)(0.299 * imageData[i] + 0.587 * imageData[i + 1] + 0.114 * imageData[i + 2]);
                grayscaleData[i] = gray;
                grayscaleData[i + 1] = gray;
                grayscaleData[i + 2] = gray;
            }

        }
    }
}
