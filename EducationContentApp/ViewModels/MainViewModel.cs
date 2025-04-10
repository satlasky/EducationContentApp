using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EducationContentApp.Models;
using EducationContentApp.Services;

namespace EducationContentApp.ViewModels;
public partial class MainViewModel : ObservableObject
{
    private readonly DatabaseService _dbService;

    [ObservableProperty]
    private List<ContentItem> contentItems;

    [ObservableProperty]
    private string newTitle;

    [ObservableProperty]
    private string newText;

    public MainViewModel()
    {
        _dbService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<DatabaseService>();
        ContentItems = _dbService.GetContentItems();
    }

    [RelayCommand]
    private void AddContent()
    {
        if (!string.IsNullOrWhiteSpace(NewTitle) && !string.IsNullOrWhiteSpace(NewText))
        {
            var newItem = new ContentItem
            {
                Title = NewTitle,
                Text = NewText,
                CreatedDate = DateTime.Now
            };
            _dbService.AddContentItem(newItem);
            ContentItems = _dbService.GetContentItems();
            NewTitle = string.Empty;
            NewText = string.Empty;
        }
    }

    [RelayCommand]
    private async Task Edit(ContentItem item)
    {
        await Application.Current.MainPage.DisplayAlert("Редактирование", $"Редактировать: {item.Title}", "OK");
    }
}