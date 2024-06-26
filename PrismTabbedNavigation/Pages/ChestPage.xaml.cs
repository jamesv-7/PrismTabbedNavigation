﻿using PrismTabbedNavigation.Interface;
using PrismTabbedNavigation.ViewModels;

namespace PrismTabbedNavigation.Pages;

public partial class ChestPage : BasePage, ITabRootPage
{

    public ChestPageViewModel ViewModel { get; private set; }

    public INavigationService NavigationService => ViewModel.NavigationService;

    public ChestPage(ChestPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;

        this.BindingContext = ViewModel;


    }
}
