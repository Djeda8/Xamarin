﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchBarMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBar : ContentPage
    {
        public SearchBar()
        {
            InitializeComponent();
        }
    }
}