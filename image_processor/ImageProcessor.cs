using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

class ImageProcessor
{
    public static void Inverse(string[] filenames)
    {
        Task[] tasks = new Task[filenames.Length];

        for (int i = 0; i < filenames.Length; i++)
        {
            string filename = filenames[i];

            tasks[i] = Task.Run(() =>{
                try
                {
                    using (Bitmap bitmap = new Bitmap(filename))
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            for (int x = 0; x < bitmap.Width; x++)
                            {
                                Color originalPixel = bitmap.GetPixel(x, y);
                                Color invertedPixel = Color.FromArgb(255 - originalPixel.R, 255 - originalPixel.G, 255 - originalPixel.B);
                                bitmap.SetPixel(x, y, invertedPixel);
                            }
                        }
                        string directory = Path.GetDirectoryName(filename);
                        string originalFilename = Path.GetFileNameWithoutExtension(filename);
                        string extension = Path.GetExtension(filename);
                        string invertedFilename = Path.Combine(directory, originalFilename + "_inverted" + extension);

                        bitmap.Save(invertedFilename);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing {0}: {1}", filename, ex.Message);
                }
            });
        }
        Task.WaitAll(tasks);
    }
}

