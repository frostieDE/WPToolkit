﻿using Microsoft.Phone.Controls;
using PhoneToolkitSample.Data;
using System;
using System.Windows.Navigation;

namespace PhoneToolkitSample.Samples
{
    public partial class ListViewSample : BasePage
    {
        private IncrementalLoadingPeople _people;

        public ListViewSample()
        {
            InitializeComponent();

            _people = (IncrementalLoadingPeople)Resources["People"];
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_people.Count == 0)
            {
                await _people.LoadMoreItemsAsync(20);
            }
        }

        private void List_ItemClick(object sender, ItemClickEventArgs e)
        {
            Person person = (Person)e.ClickedItem;
            NavigationService.Navigate(new Uri("/Samples/PersonDetail.xaml?ID=" + person.ID, UriKind.Relative));
        }
    }
}