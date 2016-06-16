using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public bool Validate(TrainingProducts entity)
        {
            ValidationErrors.Clear();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("Product Name", "Product Name must not be all lower case"));
                }
            }
            return (ValidationErrors.Count == 0);


        }
        public bool Insert(TrainingProducts entity)
        {
            bool ret = false;
            ret = Validate(entity);
            if(ret)
            {
                //TODO: Create INSERT code
            }
            return ret;
        }
        public List<TrainingProducts> Get(TrainingProducts entity)
        {
            List<TrainingProducts> ret = new List<TrainingProducts>();
            //TODO:Add your data access method here 
            ret = CreateMockData();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }
            return ret;
        }
        private List<TrainingProducts> CreateMockData()
        {
            List<TrainingProducts> ret = new List<TrainingProducts>();
            ret.Add(new TrainingProducts()
            {
                ProductID = 1,
                ProductName = "Extending BootStrap with CSS and JQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)


            });
            ret.Add(new TrainingProducts()
            {
                ProductID = 2,
                ProductName = "JQuery Basics",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)


            });
            ret.Add(new TrainingProducts()
            {
                ProductID = 3,
                ProductName = "CSS and JQuery",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(29.00)


            });
            ret.Add(new TrainingProducts()
            {
                ProductID = 4,
                ProductName = "MVC Fundamentals",
                IntroductionDate = Convert.ToDateTime("12/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(25.00)


            });
            ret.Add(new TrainingProducts()
            {
                ProductID = 5,
                ProductName = "JavaScript Fundamentals",
                IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(239.00)


            });
            ret.Add(new TrainingProducts()
            {
                ProductID = 6,
                ProductName = "Fundmentals of C#",
                IntroductionDate = Convert.ToDateTime("6/10/2014"),
                Url = "http://bit.ly/lSNzc0i",
                Price = Convert.ToDecimal(39.00)


            });

            return ret;
        }
    }
}
