using System.Windows.Controls;

namespace LibraryManagment.Services
{
    public class UserControlHelper
    {
        public static void AddToGrid(Grid grid, UserControl control)
        {
            if (grid.Children.Count > 0)
            {
                grid.Children.Clear();
                grid.Children.Add(control);
            }
            else
            {
                grid.Children.Add(control);
            }
        }
    }
}
