using System.Collections.Generic;

namespace PTCCommon
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Init();
        }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListArearVisible { get; set; }
        public bool IsSearchArearVisible { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }
        public string EventCommand { get; set; }

        protected virtual void ListMode()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListArearVisible = true;
            IsSearchArearVisible = true;
            Mode = "List";
        }

        protected virtual void Init()
        {
            EventCommand = "list";
            ListMode();
            ValidationErrors = new List<KeyValuePair<string, string>>();
            EventArgument = string.Empty;
        }
        protected virtual void AddMode()
        {
            IsDetailAreaVisible = true;
            IsListArearVisible = false;
            IsSearchArearVisible = false;
            Mode = "Add";
        }
        protected virtual void EditMode()
        {
            IsDetailAreaVisible = true;
            IsListArearVisible = false;
            IsSearchArearVisible = false;
            Mode = "Edit";
        }
        protected virtual void Get()
        {

        }
        protected virtual void ResetSearch()
        {

        }
        protected virtual void Add()
        {
            AddMode();
        }
        protected virtual void Edit()
        {
            EditMode();
        }
        protected virtual void Delete()
        {
            ListMode();
        }
        protected virtual void Save()
        {

            if (ValidationErrors.Count > 0)
            {
                IsValid = false;

            }
            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }
        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;
                case "edit":
                    IsValid = true;
                    Edit();
                    break;
                case "delete":
                    ResetSearch();
                    Delete();
                    break;
                case "add":
                    Add();
                    break;
                case "cancel":
                    ListMode();
                    Get();
                    break;
                default:
                    break;
            }
        }
    }

}
