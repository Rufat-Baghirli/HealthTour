
namespace Hotel_management.Helpers
{
    public static class Exmethods
    {
      

        public static void DeleteFile(string path, string fileName)
        {
            string filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
