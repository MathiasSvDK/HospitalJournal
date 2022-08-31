using CurrieTechnologies.Razor.SweetAlert2;

namespace BlazorIdentityServerTest.Interfaces;

public interface ISwalService
{
    SweetAlertService Swal { get; set; }

    ///<summary>
    /// Show a alert with an error message
    ///<param name="text">Text to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    Task Error(string text);

    ///<summary>
    /// Show a alert with an error message
    ///<param name="text">Text to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    Task Warning(string text);

    ///<summary>
    /// Show a alert with an error message
    ///<param name="text">Text to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    Task Success(string text);

    ///<summary>
    /// Show a alert with an message and custom warning
    ///<param name="title">Title of the alert</param>
    ///<param name="text">Message to display</param>
    ///<param name="type">The type of the alert to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>  
    Task<bool> Ask(string title, string text, SweetAlertIcon type);

    ///<summary>
    /// Show a alert with an message and custom warning
    ///<param name="title">Title of the alert</param>
    ///<param name="text">Message to display</param>
    ///<param name="confirmBtn">Text of the confirm button</param>
    ///<param name="cancelBtn">Text of the cancel button</param>
    ///<param name="type">The type of the alert to show</param>
    /// <returns>Displays a alert with a message on the users screen</returns>
    /// </summary>
    Task<bool> Ask(string title, string text, string confirmBtn, string cancelBtn, SweetAlertIcon type);
}