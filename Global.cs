using Blazored.Modal;
using Blazored.Modal.Services;
using Chronologie.Components.Modals;

namespace Chronologie
{
    public class Global
	{
		public static string ConnexionString = "";

		public static void ShowErrorPopup(string message, IModalService modal)
		{
			ModalParameters parameters = new ModalParameters();
            parameters.Add("Message", message);
            modal.Show<ErreurPopup>(parameters);
		}
	}
}