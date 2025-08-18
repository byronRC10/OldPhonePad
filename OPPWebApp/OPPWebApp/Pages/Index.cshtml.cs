using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OPPClassLibrary;
using OPPWebApp.Services;

namespace OPPWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOldPhonePadService _oldPhonePadService;
        public IndexModel(IOldPhonePadService oldPhonePadService)
        {
            _oldPhonePadService = oldPhonePadService;
        }

        [BindProperty]
        public string UserInput { get; set; } = "";
        public string Message { get; private set; } = "";

        public void OnPost()
        {
            try
            {
                // Llamada al servicio que procesa la entrada
                Message = _oldPhonePadService.ProcessInput(UserInput);
            }
            catch (ArgumentNullException ex)
            {
                Message = $"Error: Input cannot be null. ({ex.Message})";
            }
            catch (ArgumentException ex)
            {
                Message = $"Error: Invalid input. ({ex.Message})";
            }
            catch (IndexOutOfRangeException ex)
            {
                Message = $"Error: Key sequence out of range. ({ex.Message})";
            }
            catch (Exception ex)
            {
                Message = $"Unexpected error: {ex.Message}";
            }
        }// onPost

    }// class

}// namespace
