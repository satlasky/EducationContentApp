﻿using EducationContentApp.ViewModels;

namespace EducationContentApp.Views;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}