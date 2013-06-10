﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace PhoneToolkitSample.Samples
{
    public partial class CustomMessageBoxSample : PhoneApplicationPage
    {
        public CustomMessageBoxSample()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays a CustomMessageBox with no content.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event information.</param>
        private async void BasicMessageBox_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {                
                Caption = "Do you like this sample?",
                Message = "There are tons of things you can do using custom message boxes. To learn more, be sure to check out the source code at Codeplex.",
                LeftButtonContent = "yes",
                RightButtonContent = "no",
                IsFullScreen = (bool)FullScreenCheckBox.IsChecked
            };

            switch (await messageBox.ShowAsync())
            {
                case CustomMessageBoxResult.LeftButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.RightButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.None:
                    // Do something.
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays a CustomMessageBox with a HyperlinkButton as content.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event information.</param>
        private async void MessageBoxWithHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton hyperlinkButton = new HyperlinkButton()
            {
                Content = "Privacy Statement",
                HorizontalAlignment = HorizontalAlignment.Left,
                NavigateUri = new Uri("http://phone.codeplex.com/", UriKind.Absolute)
            };

            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Caption = "Allow this application to access and use your location?",
                Message = "Sharing this information helps us provide and improve the location-based services offered for this phone. We won't use the information to identify or contact you.",
                Content = hyperlinkButton,
                LeftButtonContent = "allow",
                RightButtonContent = "cancel",
                IsFullScreen = (bool)FullScreenCheckBox.IsChecked
            };

            switch (await messageBox.ShowAsync())
            {
                case CustomMessageBoxResult.LeftButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.RightButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.None:
                    // Do something.
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays a CustomMessageBox with a CheckBox as content.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event information.</param>
        private async void MessageBoxWithCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = new CheckBox()
            {
                Content = "Do not ask me again",
                Margin = new Thickness(0, -16, 0, 16)
            };

            TiltEffect.SetIsTiltEnabled(checkBox, true);

            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Caption = "Would you like to rate and review this application?",
                Message = 
                    "Thank you for trying out the Windows Phone Toolkit."
                    + Environment.NewLine + Environment.NewLine 
                    + "We would really like to hear what you think about it. Would you mind spending a couple of minutes to rate and review this application in the Marketplace?",
                Content = checkBox,
                LeftButtonContent = "ok",
                RightButtonContent = "cancel",
                IsFullScreen = (bool)FullScreenCheckBox.IsChecked
            };

            switch (await messageBox.ShowAsync())
            {
                case CustomMessageBoxResult.LeftButton:
                    // Launch Marketplace review task.
                    // Do not ask again.
                    break;
                case CustomMessageBoxResult.RightButton:
                case CustomMessageBoxResult.None:
                    if ((bool)checkBox.IsChecked)
                    {
                        // Do not launch Marketplace review task.
                        // Do not ask again.
                    }
                    else
                    {
                        // Do not launch Marketplace review task.
                        // Ask again later.
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays a CustomMessageBox with a ListPicker as content.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event information.</param>
        private async void MessageBoxWithListPicker_Click(object sender, RoutedEventArgs e)
        {
            ListPicker listPicker = new ListPicker()
            {
                Header = "Snooze for",
                ItemsSource = new string[] { "5 minutes", "10 minutes", "1 hour", "4 hours", "1 day" },
                Margin = new Thickness(0, 30, 12, 24)
            };

            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Title = "CALENDAR",
                Caption = "Annual Company Product Fair 2012",
                Message = "Soccer Fields" + Environment.NewLine + "May 4, 2012 4:30-6:30 PM",
                Content = listPicker,
                LeftButtonContent = "snooze",
                RightButtonContent = "dismiss",
                IsFullScreen = (bool)FullScreenCheckBox.IsChecked
            };

            messageBox.Dismissing += (s1, e1) =>
                {
                    if (listPicker.IsExpanded)
                    {
                        e1.Cancel = true;
                    }
                };

            switch (await messageBox.ShowAsync())
            {
                case CustomMessageBoxResult.LeftButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.RightButton:
                case CustomMessageBoxResult.None:
                    // Do something.
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Displays a CustomMessageBox with a Pivot as content 
        /// by getting its ContentTemplate from a DataTemplate
        /// stored as a resource.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event information.</param>
        private async void MessageBoxWithPivot_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                ContentTemplate = (DataTemplate)this.Resources["PivotContentTemplate"],
                LeftButtonContent = "speak",
                RightButtonContent = "read it",
                IsFullScreen = true, // Pivots should always be full-screen.
                Margin = new Thickness()
            };

            messageBox.Dismissing += (s1, e1) =>
            {
                if (e1.Result == CustomMessageBoxResult.RightButton)
                {
                    e1.Cancel = true;
                }
            };

            switch (await messageBox.ShowAsync())
            {
                case CustomMessageBoxResult.LeftButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.RightButton:
                    // Do something.
                    break;
                case CustomMessageBoxResult.None:
                    // Do something.
                    break;
                default:
                    break;
            }
        }
    }
}