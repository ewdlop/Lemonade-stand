using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;

namespace ModernWinUI
{
    // Main window class
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Modern WinUI App";
        }
    }

    // Main page XAML
    /*
    <Window
        x:Class="ModernWinUI.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:ModernWinUI">

        <Grid>
            <NavigationView x:Name="NavView"
                           IsSettingsVisible="True"
                           IsBackButtonVisible="Auto"
                           SelectionChanged="NavView_SelectionChanged"
                           BackRequested="NavView_BackRequested">

                <NavigationView.MenuItems>
                    <NavigationViewItem Icon="Home" Content="Home" Tag="home"/>
                    <NavigationViewItem Icon="Document" Content="Documents" Tag="documents"/>
                    <NavigationViewItem Icon="People" Content="Users" Tag="users"/>
                    <NavigationViewItem Icon="Download" Content="Downloads" Tag="downloads"/>
                </NavigationView.MenuItems>

                <Frame x:Name="ContentFrame" Padding="12">
                    <Frame.ContentTransitions>
                        <TransitionCollection>
                            <NavigationThemeTransition/>
                        </TransitionCollection>
                    </Frame.ContentTransitions>
                </Frame>

            </NavigationView>
        </Grid>
    </Window>
    */

    // Home page with modern controls
    public sealed partial class HomePage : Page
    {
        public ObservableCollection<NewsItem> NewsItems { get; } = new ObservableCollection<NewsItem>();
        public ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();

        public HomePage()
        {
            this.InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Sample news items
            NewsItems.Add(new NewsItem { Title = "New Feature Released", Description = "Check out our latest update!", Date = DateTime.Now });
            NewsItems.Add(new NewsItem { Title = "System Update", Description = "Important security patches", Date = DateTime.Now.AddDays(-1) });

            // Sample projects
            Projects.Add(new Project { Name = "Project Alpha", Progress = 75, Status = "In Progress" });
            Projects.Add(new Project { Name = "Project Beta", Progress = 30, Status = "Planning" });
        }
    }

    public class HomePageViewModel
    {
      public ObservableCollection<NewsItem> NewsItems { get; }
      public ObservableCollection<Project> Projects { get; }

      public HomePageViewModel()
      {
          NewsItems = new ObservableCollection<NewsItem>();
          Projects = new ObservableCollection<Project>();
          LoadData();
      }
    }
    
    // Home page XAML
    /*
    <Page
        x:Class="ModernWinUI.HomePage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

        <Grid>
            <ScrollViewer>
                <StackPanel Spacing="20" Padding="20">
                    <!-- Welcome section -->
                    <InfoBar Title="Welcome Back!"
                            Message="Here's your daily summary"
                            Severity="Informational"
                            IsOpen="True"/>

                    <!-- Quick actions -->
                    <CommandBar DefaultLabelPosition="Right">
                        <AppBarButton Icon="Add" Label="New Project"/>
                        <AppBarButton Icon="Mail" Label="Messages"/>
                        <AppBarButton Icon="Calendar" Label="Schedule"/>
                    </CommandBar>

                    <!-- News section -->
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>

                        <TextBlock Text="Latest News"
                                 Style="{StaticResource SubtitleTextBlockStyle}"
                                 Margin="0,0,0,12"/>

                        <ItemsRepeater Grid.Row="1"
                                      ItemsSource="{x:Bind NewsItems}">
                            <ItemsRepeater.ItemTemplate>
                                <DataTemplate>
                                    <InfoBar Title="{Binding Title}"
                                            Message="{Binding Description}"
                                            IsOpen="True"
                                            IsCloseable="False"
                                            Margin="0,0,0,8"/>
                                </DataTemplate>
                            </ItemsRepeater.ItemTemplate>
                        </ItemsRepeater>
                    </Grid>

                    <!-- Projects section -->
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>

                        <TextBlock Text="Active Projects"
                                 Style="{StaticResource SubtitleTextBlockStyle}"
                                 Margin="0,0,0,12"/>

                        <ItemsRepeater Grid.Row="1"
                                      ItemsSource="{x:Bind Projects}">
                            <ItemsRepeater.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel Margin="0,0,0,16">
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="*"/>
                                                <ColumnDefinition Width="Auto"/>
                                            </Grid.ColumnDefinitions>
                                            <TextBlock Text="{Binding Name}"
                                                     Style="{StaticResource BodyTextBlockStyle}"/>
                                            <TextBlock Grid.Column="1"
                                                     Text="{Binding Status}"
                                                     Style="{StaticResource CaptionTextBlockStyle}"/>
                                        </Grid>
                                        <ProgressBar Value="{Binding Progress}"
                                                   Maximum="100"
                                                   Margin="0,4,0,0"/>
                                    </StackPanel>
                                </DataTemplate>
                            </ItemsRepeater.ItemTemplate>
                        </ItemsRepeater>
                    </Grid>

                    <!-- Settings card -->
                    <ExpanderCard Header="Settings">
                        <StackPanel Spacing="8">
                            <ToggleSwitch Header="Dark Mode"/>
                            <ToggleSwitch Header="Notifications"/>
                            <Slider Header="Animation Speed"
                                   Minimum="0"
                                   Maximum="100"
                                   Value="50"/>
                        </StackPanel>
                    </ExpanderCard>
                </StackPanel>
            </ScrollViewer>
        </Grid>
    </Page>
    */

    // Data models
    public class NewsItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    public class Project
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; }
    }

    // Settings page
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }
    }

    // Settings page XAML
    /*
    <Page
        x:Class="ModernWinUI.SettingsPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

        <StackPanel Spacing="10" Padding="20">
            <SettingsExpander Header="Display">
                <SettingsExpander.Items>
                    <SettingsExpanderItem Content="Theme">
                        <SettingsExpanderItem.IconSource>
                            <SymbolIconSource Symbol="Brightness"/>
                        </SettingsExpanderItem.IconSource>
                        <ComboBox SelectedIndex="0">
                            <ComboBoxItem Content="System"/>
                            <ComboBoxItem Content="Light"/>
                            <ComboBoxItem Content="Dark"/>
                        </ComboBox>
                    </SettingsExpanderItem>

                    <SettingsExpanderItem Content="Font Size">
                        <SettingsExpanderItem.IconSource>
                            <SymbolIconSource Symbol="FontSize"/>
                        </SettingsExpanderItem.IconSource>
                        <Slider Width="200" Value="14" Minimum="8" Maximum="24"/>
                    </SettingsExpanderItem>
                </SettingsExpander.Items>
            </SettingsExpander>

            <SettingsExpander Header="Notifications">
                <SettingsExpander.Items>
                    <SettingsExpanderItem Content="Enable Notifications">
                        <ToggleSwitch IsOn="True"/>
                    </SettingsExpanderItem>

                    <SettingsExpanderItem Content="Sound">
                        <ToggleSwitch IsOn="True"/>
                    </SettingsExpanderItem>
                </SettingsExpander.Items>
            </SettingsExpander>

            <SettingsExpander Header="Privacy">
                <SettingsExpander.Items>
                    <SettingsExpanderItem Content="Send Usage Data">
                        <ToggleSwitch IsOn="False"/>
                    </SettingsExpanderItem>
                </SettingsExpander.Items>
            </SettingsExpander>

            <SettingsExpander Header="About">
                <StackPanel Spacing="8">
                    <TextBlock Text="Modern WinUI App"/>
                    <TextBlock Text="Version 1.0.0"/>
                    <HyperlinkButton Content="Check for Updates"/>
                </StackPanel>
            </SettingsExpander>
        </StackPanel>
    </Page>
    */
}
