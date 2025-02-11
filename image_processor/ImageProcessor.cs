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
    /// <param name="filenames">Array of image filenames to process.</param>
    public static void Grayscale(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                using (Bitmap originalBitmap = new Bitmap(filename))
                {
                    Bitmap grayscaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        for (int x = 0; x < originalBitmap.Width; x++)
                        {
                            Color originalColor = originalBitmap.GetPixel(x, y);
                            int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                            Color grayColor = Color.FromArgb(originalColor.A, grayValue, grayValue, grayValue);
                            grayscaleBitmap.SetPixel(x, y, grayColor);
                        }
                    }

                    string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_grayscale{Path.GetExtension(filename)}";
                    grayscaleBitmap.Save(outputFilename, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }
}
