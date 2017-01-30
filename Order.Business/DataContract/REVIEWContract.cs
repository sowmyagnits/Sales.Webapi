using System;

namespace Order.Business.DataContract
{
    public class ReviewContract
    {
        public int ProductReviewID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<int> Ratings { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        public virtual ProductContract Product { get; set; }
    }
}