using System;

namespace DataModel.Models.CustomerHealthModel.EventsModel
{
    public class EventBannerModel
    {
        public Guid ID { get; set; }

        public string UID { get; set; }

        public string Status { get; set; }

        public string Channel { get; set; }

        public string RefCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}