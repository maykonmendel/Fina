using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Client.Pages.Categories;

public partial class GetAllCategoriesPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public List<Category> Categories { get; set; } = [];
    
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IDialogService Dialog { get; set; } = null!;
    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllCategoriesRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Categories = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    public async void OnDeleteButtonClickedAsync(long id, string title)
    {
        var result = await Dialog.ShowMessageBox(
            "ATENÇÃO",
            $"Ao prosseguir a categoria {title} será removida. Deseja continuar?",
            yesText: "Excluir",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, title);

        StateHasChanged();
    }

    public async Task OnDeleteAsync(long id, string title)
    {
        try
        {
            var request = new DeleteCategoryRequest
            {
                Id = id
            };
            await Handler.DeleteAsync(request);
            Categories.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Categoria {title} removida", Severity.Info);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}