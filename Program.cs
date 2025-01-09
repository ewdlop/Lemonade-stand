void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
{
    if (args.SelectedItem is NavigationViewItem selectedItem)
    {
        string pageName = selectedItem.Tag.ToString();
        switch (pageName)
        {
            case "home":
                ContentFrame.Navigate(typeof(HomePage));
                break;
            case "settings":
                ContentFrame.Navigate(typeof(SettingsPage));
                break;
        }
    }
}
