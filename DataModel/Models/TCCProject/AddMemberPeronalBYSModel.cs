using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.TCCProject
{
    public class AddMemberPeronalBYSModel
    {
        public class PersonData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string RegisterNo { get; set; }
            public DateTime IssueDate { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
            public string Occupation { get; set; }
            public string ProductName { get; set; }
            public string ProductExportcountry { get; set; }
            public string BussinessType { get; set; }
            public string ProductNameExport { get; set; }
            public Address Address { get; set; }
            public List<Document> Document { get; set; }
        }

        public class Address
        {
            public string AddressNoTH { get; set; }
            public string MooTH { get; set; }
            public string BuildingTH { get; set; }
            public string VillageTH { get; set; }
            public string FloorTH { get; set; }
            public string RoomTH { get; set; }
            public string SoiTH { get; set; }
            public string LaneTH { get; set; }
            public string RoadTH { get; set; }
            public string TambolTH { get; set; }
            public string AmphurTH { get; set; }
            public string ProvinceTH { get; set; }
            public string CountryTH { get; set; }
            public string FullAddressTH { get; set; }
            public string AddressNoEN { get; set; }
            public string MooEN { get; set; }
            public string BuildingEN { get; set; }
            public string VillageEN { get; set; }
            public string FloorEN { get; set; }
            public string RoomEN { get; set; }
            public string SoiEN { get; set; }
            public string LaneEN { get; set; }
            public string RoadEN { get; set; }
            public string CountryEN { get; set; }
            public string FullAddressEN { get; set; }
            public string Zipcode { get; set; }
        }

        public class Document
        {
            public string DocumentType { get; set; }
            public string File { get; set; }
        }

    }
}


