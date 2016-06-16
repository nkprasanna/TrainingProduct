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
            }
        }

        private void AddMode()
        {
            IsDetailAreaVisible = true;
            IsListArearVisible = false;
            IsSearchArearVisible = false;
            Mode = "Add";
        }
        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProducts();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://www.google.com";
            Entity.Price = 0;
            AddMode();
        }

        private void ListMode()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListArearVisible = true;
            IsSearchArearVisible = true;
            Mode = "List";
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
