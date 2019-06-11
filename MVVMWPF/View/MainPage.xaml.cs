﻿using MVVMWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMWPF.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly UserViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new UserViewModel();
            FillUsers(_viewModel);
        }

        private void FillUsers(UserViewModel _viewModel)
        {
            this.DataContext = _viewModel;
        }

       
    }
}
