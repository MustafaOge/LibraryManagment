using LibraryManagment.Enums;
using System.Media;

namespace LibraryManagment.Helpers
{
    public class SoundHelper
    {
        public static void Play(SoundType type)
        {
            try
            {
                string path = GetSoundFilePath(type);
                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }
            catch
            {
                // Exception alert
            }
        }

        private static readonly string basePath = "Assets/Music/";

        private static string GetSoundFilePath(SoundType type)
        {
            return type switch
            {
                SoundType.Popup => basePath + "popup.wav",
            };
        }
    }
}
