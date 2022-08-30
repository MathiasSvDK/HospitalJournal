using CurrieTechnologies.Razor.SweetAlert2;

namespace BlazorIdentityServerTest.Services;

public class SwalService
{
    public SweetAlertService Swal { get; set; }
    public SwalService(SweetAlertService swal)
    {
        Swal = swal;
    }

    public async Task Error(string text)
    {
        await Swal.FireAsync("Oops...", text, "error");
    }
    public async Task Warning(string text)
    {
        await Swal.FireAsync("Advarsel", text, "warning");
    }
    public async Task Success(string text)
    {
        await Swal.FireAsync("Fuldført", text, "success");
    }
    
    
    public async Task<bool> Ask(string title, string text, SweetAlertIcon type)
    {
        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = title,
            Html = text,
            Icon = type,
            ShowCancelButton = true,
            ConfirmButtonText = "Ja",
            CancelButtonText = "Annuller"
        });
        if (!string.IsNullOrEmpty(result.Value))
        {
            return true;
        }
        return false;
    }
    
    
    public async Task<bool> Ask(string title, string text, string confirmBtn, string cancelBtn, SweetAlertIcon type)
    {
        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = title,
            Html = text,
            Icon = type,
            ShowCancelButton = true,
            ConfirmButtonText = confirmBtn,
            CancelButtonText = cancelBtn
        });
        if (!string.IsNullOrEmpty(result.Value))
        {
            return true;
        }
        return false;
    }
}