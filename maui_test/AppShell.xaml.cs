﻿using maui_test.Pages;

namespace maui_test
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(FilteredNewsPage), typeof(FilteredNewsPage));
        }
    }
}
