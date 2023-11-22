using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace AuthRegApp
{
    public static class MyNavigation
    {
        public static MainWindow mainWindow;

        public static void NextPage(PageComponent pageComponent)
        {
            Update(pageComponent);
        }

        private static void Update(PageComponent pageComponent)
        {
            mainWindow.TitleTb.Text = pageComponent.Title;
            mainWindow.MainFrame.Navigate(pageComponent.Page);
        }
    }

    public class PageComponent
    {
        public Page Page { get; set; }
        public string Title { get; set; }

        public PageComponent(Page page, string title)
        {
            Page = page;
            Title = title;
        }
    }
}