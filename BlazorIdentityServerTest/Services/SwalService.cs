using CurrieTechnologies.Razor.SweetAlert2;
using BlazorIdentityServerTest.Interfaces;

namespace BlazorIdentityServerTest.Services;

public class SwalService : ISwalService
{
    public SweetAlertService Swal { get; set; }

    public SwalService(SweetAlertService swal)
    {
        Swal = swal;
    }


    ///<summary>
    /// Show a alert with an error message
    ///<param name="text">Text to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    public async Task Error(string text)
    {
        await Swal.FireAsync("Oops...", text, "error");
    }

    ///<summary>
    /// Show a alert with an error message
    ///<param name="text">Text to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    public async Task Warning(string text)
    {
        await Swal.FireAsync("Advarsel", text, "warning");
    }

    ///<summary>
    /// Show a alert with an error message
    ///<param name="text">Text to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    public async Task Success(string text)
    {
        await Swal.FireAsync("Fuldført", text, "success");
    }

    ///<summary>
    /// Show a alert with an message and custom warning
    ///<param name="title">Title of the alert</param>
    ///<param name="text">Message to display</param>
    ///<param name="type">The type of the alert to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>  
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

    ///<summary>
    /// Show a alert with an message and custom warning
    ///<param name="title">Title of the alert</param>
    ///<param name="text">Message to display</param>
    ///<param name="confirmBtn">Text of the confirm button</param>
    ///<param name="cancelBtn">Text of the cancel button</param>
    ///<param name="type">The type of the alert to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
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