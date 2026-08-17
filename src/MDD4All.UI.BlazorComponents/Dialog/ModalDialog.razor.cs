using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MDD4All.UI.BlazorComponents.Dialog
{
    public partial class ModalDialog
    {
        [Inject]
        private IStringLocalizer<ModalDialog> L { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        [Parameter]
        public ModalDialogType DialogType { get; set; } = ModalDialogType.Ok;

        // Wording of the confirming button. Empty keeps the dialog type's own label.
        [Parameter]
        public string ConfirmText { get; set; } = "";

        [Parameter]
        public bool CanConfirm 
        { 
            get;
            
            set; 
        
        } = true;

        

        protected override void OnInitialized()
        {
            
        }

        private string ConfirmLabel(string defaultLabel)
        {
            string result = defaultLabel;

            if (!string.IsNullOrEmpty(ConfirmText))
            {
                result = ConfirmText;
            }

            return result;
        }

        private Task ModalCancel()
        {
            return OnClose.InvokeAsync(false);
        }

        private Task ModalOk()
        {
            return OnClose.InvokeAsync(true);
        }

        public enum ModalDialogType
        {
            Ok,
            OkCancel,
            DeleteCancel
        }
    }
}