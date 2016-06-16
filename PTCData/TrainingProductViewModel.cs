using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            Products = new List<TrainingProducts>();
            SearchEntity = new TrainingProducts();
            Entity = new TrainingProducts();
            Init();
        }

        private void Init()
        {
            EventCommand = "list";
            ListMode();
            ValidationErrors = new List<KeyValuePair<string, string>>();
            EventArgument = string.Empty;
        }

        public TrainingProducts Entity { get; set; }
        public string EventCommand { get; set; }
        public List<TrainingProducts> Products { get; set; }
        public TrainingProducts SearchEntity { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListArearVisible { get; set; }
        public bool IsSearchArearVisible { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        public void HandleRequest()
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

        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;

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

        private void AddMode()
        {
            IsDetailAreaVisible = true;
            IsListArearVisible = false;
            IsSearchArearVisible = false;
            Mode = "Add";
        }
        private void EditMode()
        {
            IsDetailAreaVisible = true;
            IsListArearVisible = false;
            IsSearchArearVisible = false;
            Mode = "Edit";
        }
        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProducts();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;
            AddMode();
        }
        private void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            EditMode();
        }

        private void ListMode()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListArearVisible = true;
            IsSearchArearVisible = true;
            Mode = "List";
        }
        private void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProducts();
            Entity.ProductID = Convert.ToInt32(EventArgument);
            mgr.Delete(Entity);
            Get();
            ListMode();
        }


        private void ResetSearch()
        {
            SearchEntity = new TrainingProducts();
        }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }
    }
}
