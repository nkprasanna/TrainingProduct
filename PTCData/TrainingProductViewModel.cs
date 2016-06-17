using PTCCommon;
using System;
using System.Collections.Generic;

namespace PTCData
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel() : base()
        {

        }
        protected override void Init()
        {
            Products = new List<TrainingProducts>();
            SearchEntity = new TrainingProducts();
            Entity = new TrainingProducts();
            base.Init();
        }

        public TrainingProducts Entity { get; set; }

        public List<TrainingProducts> Products { get; set; }
        public TrainingProducts SearchEntity { get; set; }


        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "prasanna":
                    break;
                default:
                    break;
            }
            base.HandleRequest();
        }
        protected override void Save()
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

            base.Save();
        }
        protected override void Add()
        {
            IsValid = true;
            Entity = new TrainingProducts();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;
            base.Add();
        }
        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            base.Edit();
        }
        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProducts();
            Entity.ProductID = Convert.ToInt32(EventArgument);
            mgr.Delete(Entity);
            Get();
            base.Delete();
        }
        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProducts();
            base.ResetSearch();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
            base.Get();
        }
    }
}
