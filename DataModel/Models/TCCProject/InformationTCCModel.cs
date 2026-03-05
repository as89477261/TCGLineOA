using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.TCCProject
{
    public  partial class InformationTCCModel
    {
        public Guid ID { get; set; }
        public string TransID { get; set; }
        public string TypeFrom { get; set; }
        public DateTime CreatedDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string registerNo { get; set; }
        public string issueDate { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string occupation { get; set; }
        public string productName { get; set; }
        public string productExportcountry { get; set; }
        public string bussinessType { get; set; }
        public string productNameExport { get; set; }
        public string addressNoTH { get; set; }
        public string mooTH { get; set; }
        public string buildingTH { get; set; }
        public string villageTH { get; set; }
        public string floorTH { get; set; }
        public string roomTH { get; set; }
        public string soiTH { get; set; }
        public string laneTH { get; set; }
        public string roadTH { get; set; }
        public string tambolTH { get; set; }
        public string ampherTH { get; set; }
        public string provinceTH { get; set; }
        public string countryTH { get; set; }
        public string fullAddressTH { get; set; }
        public string zipcode { get; set; }
        public string doc_DC { get; set; }
        public string filePath_DC { get; set; }
        public string doc_DB { get; set; }
        public string filePath_DB { get; set; }
        public string doc_CH { get; set; }
        public string filePath_CH { get; set; }
        public string doc_PL { get; set; }
        public string filePath_PL { get; set; }
        public string companyType { get; set; }
        public string numberEmployee { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public string contactIDCard { get; set; }
        public string contactPosition { get; set; }
        public string contactMobile { get; set; }
        public string contactEmail { get; set; }
        public string directorFirstName { get; set; }
        public string directorLastName { get; set; }
        public string directorIDCard { get; set; }
        public string filePath_directorIDCopyDoc { get; set; }
        public string directorMobile { get; set; }
        public string directorEmail { get; set; }
        public string directorIDCopyDoc { get; set; }
        public string totalAsset { get; set; }
        public string doc_OJ { get; set; }
        public string filePath_OJ { get; set; }
        public string doc_PP { get; set; }
        public string filePath_PP { get; set; }
        public string doc_IS { get; set; }
        public string filePath_IS { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string companyName { get; set; }

    }
}
