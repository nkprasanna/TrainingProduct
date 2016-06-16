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
            EventCommand = "list";
        }
        public string  EventCommand { get; set; }
        public List<TrainingProducts> Products { get; set; }
        public TrainingProducts SearchEntity { get; set; }

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
                //case "list":
                //    Get();
                //break;
                default:
                    break;
            }
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
