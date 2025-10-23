using System.Windows.Controls.Primitives;

namespace LibraryManagment.Helpers
{
    public class PopupHelper
    {

        public static async Task ShowPopupAsync(Popup popup, int durationMs = 3000)
        {
            popup.IsOpen = true;
            await Task.Delay(durationMs);
            popup.IsOpen = false;
        }

    }
}
